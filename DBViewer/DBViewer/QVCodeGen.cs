using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBS
{
	class QVCodeGen
	{
		public string QVCodeString { get; set; }
		private Options options;
		private DatabaseUtils dbUtils;
		private List<ForeignKeyItem> foreignKeys = new List<ForeignKeyItem>();

		public QVCodeGen()
		{
			options = new Options();
		}
		/// <summary>
		/// Build QlikView LOAD and SQL SELECT statements based on the results of the search
		/// </summary>
		/// <param name="queryStrings">List of search strings with results</param>
		/// <param name="db">Reference to DatabaseUtils class</param>
		public void BuildQVLoadStatements(List<SearchItem> queryStrings, DatabaseUtils db)
		{
			QVCodeString = string.Empty;
			this.dbUtils = db;
			string currentTable = "";
			bool first = true;
			StringBuilder sbLoad = new StringBuilder();
			StringBuilder sbSelect = new StringBuilder();

			if (dbUtils.IsClarityDB)
				QVCodeString += BuildMappingTableScript(queryStrings);

			foreach (SearchItem si in queryStrings)
			{
				// Don't include fields that are always null
				if (!si.HasRows)
				{
					if (options.IncludeNullFields)
					{
						sbLoad.AppendLine("// " + si.Columns);
						sbSelect.AppendLine("// " + si.Columns);
					}
					continue;
				}

				if (si.TableName != currentTable)
				{
					if (sbLoad.Length != 0)
						AddQVLoadToResults(sbLoad, sbSelect, currentTable);
					sbLoad.Clear();
					sbSelect.Clear();
					sbLoad.AppendLine("/* " + si.TableName + " */");
					sbLoad.Append("LOAD");
					first = true;
					sbSelect.AppendLine("SQL");
					sbSelect.Append("SELECT");
					currentTable = si.TableName;
				}
				if (first)
				{
					sbLoad.AppendLine(" " + si.Columns);
					sbSelect.AppendLine(" " + si.Columns);
					first = false;
				}
				else
				{
					sbLoad.AppendLine("    ," + si.Columns);
					if (dbUtils.IsClarityDB)
						BuildApplyMap(sbLoad, si);
					sbSelect.AppendLine("      ," + si.Columns);
				}
			}
			if (sbLoad.Length != 0)
			{
				AddQVLoadToResults(sbLoad, sbSelect, currentTable);
			}
			sbLoad.Clear();
			sbSelect.Clear();
		}

		/// <summary>
		/// Build the ApplyMap() code for the QV Load Script
		/// </summary>
		/// <param name="sbLoad">StringBuilder containing the QVLoad statements</param>
		/// <param name="si">Current SearchItem object</param>
		/// <remarks>Only called if dbUtils.IsClarityDB == true</remarks>
		private void BuildApplyMap(StringBuilder sbLoad, SearchItem si)
		{
			if (si.Columns.EndsWith("_C") || si.Columns.EndsWith("_ID"))
			{
				// Validate there is a mapping table built for this field
				var fkQuery = from f in foreignKeys
											where f.SourceColumnName.Equals(si.Columns)
											select f;
				if (fkQuery.FirstOrDefault() != null)
				{
					string replaceWith = (si.Columns.EndsWith("_C") ? "_C" : "_ID");
					if (si.Columns.EndsWith("_C") && options.MapCFields)
					{
						sbLoad.AppendLine(string.Format("    ,ApplyMap('{0}{3}', {0}) AS {1}_{2}", si.Columns, si.Columns.Replace(replaceWith, ""), options.ExpandedFieldName, options.MapName));
					}
					if (si.Columns.EndsWith("_ID") && options.MapIDFields)
					{
						sbLoad.AppendLine(string.Format("    ,ApplyMap('{0}{3}', {0}) AS {1}_{2}", si.Columns, si.Columns.Replace(replaceWith, ""), options.ExpandedFieldName, options.MapName));
					}
				}
				else
					sbLoad.AppendLine(string.Format("\t\t// No entry found in CLARITY_TBL_FK_ALL table for {0}. No map defined", si.Columns));
			}
			if (si.Columns.EndsWith("_DATETIME"))
			{
				if (options.DateFromDATETIME)
				{
					sbLoad.AppendLine(string.Format("    ,MakeDate(Year({0}), Month({0}), Day({0})) AS {0}_DATE", si.Columns));
				}
				if (options.TimeFromDATETIME)
				{
					sbLoad.AppendLine(string.Format("    ,MakeTime(Hour({0}), Minute({0}), Second({0})) AS {0}_TIME", si.Columns));
				}
			}
			if (si.Columns.EndsWith("_DTTM"))
			{
				if (options.DateFromDTTM)
				{
					sbLoad.AppendLine(string.Format("    ,MakeDate(Year({0}), Month({0}), Day({0})) AS {0}_DATE", si.Columns));
				}
				if (options.TimeFromDTTM)
				{
					sbLoad.AppendLine(string.Format("    ,MakeTime(Hour({0}), Minute({0}), Second({0})) AS {0}_TIME", si.Columns));
				}
			}
		}

		/// <summary>
		/// Assemble the current QV Load and SQL SELECT statements together and add to the QVCodeString public property
		/// </summary>
		/// <param name="sbLoad">QV LOAD statement</param>
		/// <param name="sbSelect">QV SQL SELECT statement</param>
		/// <param name="tableName">Name of the table the LOAD and SQL SELECT is for</param>
		private void AddQVLoadToResults(StringBuilder sbLoad, StringBuilder sbSelect, string tableName)
		{
			sbSelect.Append(";");
			string load = ReplaceLastOccurrence(sbLoad.ToString(), "\r\n", ";\r\n");
			string select = ReplaceLastOccurrence(sbSelect.ToString(), "\r\n;", "\r\n  FROM " + tableName + ";");
			QVCodeString += load + select + "\r\n\r\n";
		}

		/// <summary>
		/// For a given string, replace the last occurrence of one string with another
		/// </summary>
		/// <param name="Source">Starting string</param>
		/// <param name="Find">What to find in string</param>
		/// <param name="Replace">What to replace it with</param>
		/// <returns>String after replacement completed</returns>
		private string ReplaceLastOccurrence(string Source, string Find, string Replace)
		{
			int Place = Source.LastIndexOf(Find);
			string result = Source.Remove(Place, Find.Length).Insert(Place, Replace);
			return result;
		}
		/// <summary>
		/// Build the code for the "Mapping Tables" tab of the QV Load Script
		/// </summary>
		/// <param name="queryStrings"></param>
		/// <remarks>Only called if dbUtils.IsClarityDB == true</remarks>
		private string BuildMappingTableScript(List<SearchItem> queryStrings)
		{
			StringBuilder sbMapping = new StringBuilder();
			foreignKeys.Clear();
			// Step 1: Determine how many tables are included in queryStrings
			var tableQuery = (from q in queryStrings
												where q.HasRows == true
												select q.TableName).Distinct();
			foreach (string table in tableQuery)
			{
				string tableName = table.Substring(table.LastIndexOf('.')+1).Replace("[", "").Replace("]", "");
				// Step 2: Get the TABLE_ID from CLARITY_TBL for the current table
				string selectStatement = string.Format("SELECT TABLE_ID FROM [{0}].[dbo].[CLARITY_TBL] WHERE IS_EXTRACTED_YN = 'Y' AND TABLE_ID LIKE 'E%' AND TABLE_NAME = '{1}'", dbUtils.CurrentDatabase, tableName);
				dbUtils.GetForeignKeys(foreignKeys, queryStrings, selectStatement, tableName);
			}
			// Step 4: Build the mapping select code for the tables
			string currentTable = string.Empty;
			foreach (ForeignKeyItem item in foreignKeys)
			{
				if (currentTable != item.TableName)
				{
					currentTable = item.TableName;
					sbMapping.AppendLine(string.Format("/* Mapping Tables for {0} */", item.TableName));
				}
				if (item.SourceColumnName.EndsWith("_C") && options.MapCFields)
				{
					sbMapping.AppendLine(string.Format("{0}{1}:", item.SourceColumnName, options.MapName));
					sbMapping.AppendLine(string.Format("Mapping SELECT {0}, NAME FROM [{1}].[dbo].[{2}];", item.DestinationColumnName, dbUtils.CurrentDatabase, item.DestinationTableName));
					sbMapping.AppendLine();
				}
				if (item.SourceColumnName.EndsWith("_ID") && options.MapIDFields)
				{
					string fkName = dbUtils.GetFKNameField(item.DestinationTableName);
					sbMapping.AppendLine(string.Format("{0}{1}:", item.SourceColumnName, options.MapName));
					sbMapping.AppendLine(string.Format("Mapping SELECT {0}, {1} FROM [{2}].[dbo].[{3}];", item.DestinationColumnName, fkName, dbUtils.CurrentDatabase, item.DestinationTableName));
					sbMapping.AppendLine();
				}
			}
			// Step 5: Add to textbox
			return sbMapping.ToString();
		}
	}
}


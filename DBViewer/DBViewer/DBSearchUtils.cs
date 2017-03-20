using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBS
{
	class DBSearchUtils
	{
		private DatabaseUtils dbUtils;
		private QVCodeGen qvCodeGen;
		private List<SearchItem> queryStrings = new List<SearchItem>();
		private SearchParams searchParams;

		private MainForm mainForm;
		public DBSearchUtils(DatabaseUtils db)
		{
			this.dbUtils = db;
		}

		internal void PerformSearch(SearchParams sp, MainForm mf)
		{
			qvCodeGen = new QVCodeGen();
			searchParams = sp;
			mainForm = mf;
			BuildSelectStringDispatcher();
			DoSearch();
		}

		/// <summary>
		/// Loops through each SearchItem and calls dbUtils.DoSQLCommand for each
		/// </summary>
		/// <remarks>As the searches take place, fields in the SearchItem object are updated with results</remarks>
		private void DoSearch()
		{
			int x = 0;

			foreach (SearchItem si in queryStrings)
			{
				x++;
				SetStatus(String.Format("Search {0} of {1}...", x, queryStrings.Count()));

				mainForm.UpdateLabels(si);

				dbUtils.DoSQLCommand(si, searchParams);

				if (si.HasRows && !searchParams.IsNull)
				{
					mainForm.UpdateTextResults(MainForm.TextResultsHandling.Append, String.Format("\r\n {0:N0} - {1}", si.NumRows, si.SqlSelect));
				}
				if (!si.HasRows && searchParams.IsNull && !searchParams.IsQVScript)
				{
					// Show list of null fields
					mainForm.UpdateTextResults(MainForm.TextResultsHandling.Append, String.Format("\r\n {0} - {1}", si.TableName, si.Columns));
				}
			} // foreach()
			if (searchParams.IsQVScript)
			{
				qvCodeGen.BuildQVLoadStatements(queryStrings, dbUtils);
				mainForm.UpdateTextResults(MainForm.TextResultsHandling.Append, qvCodeGen.QVCodeString);
			}
		}

		/// <summary>
		/// Based on form selections, calls routines to build the necessary SQL SELECT strings
		/// to search DB for the search string
		/// </summary>
		private void BuildSelectStringDispatcher()
		{
			if (searchParams.IsRecordCount)
			{
				BuildRecordCountStrings();
			}
			else
			{
				if (searchParams.IsNull)
					BuildNullSelectStrings();
				else
					BuildSelectStrings();
			}
		}

		/// <summary>
		/// Builds SQL SELECT strings that will search all appropriate fields in each selected table for the search term
		/// If a Numeric search is required, then non-char fields are selected
		/// If a String search (default) is required, then all char-type fields are selected
		/// </summary>
		/// <example>
		/// The format of the SQL SELECT statement produced is similar to this:
		/// SELECT * FROM [ServiceDeskPlus].[dbo].[AaaLogin] WHERE [DOMAINNAME] like '%Mark%' OR [NAME] like '%Mark%';
		/// </example>
		private void BuildSelectStrings()
		{
			
			// Consider columns only if some columns are passed in
			bool considerColumns = searchParams.ColumnNames.Count != 0;
			string selectedColumns = string.Empty;
			string selectString = "DATA_TYPE " + (searchParams.IsNumeric ? "NOT" : "") + " like '%char%'";
			if (considerColumns)
			{
				foreach (ColumnItem item in searchParams.ColumnNames)
				{
					selectedColumns += "'" + item.ColumnName + "',";
				}
				selectedColumns = selectedColumns.Remove(selectedColumns.LastIndexOf(','), 1);
				selectString += " AND COLUMN_NAME IN (" + selectedColumns + ")";
			}
			DataRow[] stringRows = dbUtils.SchemaDataSet.Tables["TableColumns"].Select(selectString, "TABLE_NAME ASC");

			queryStrings = new List<SearchItem>();
			StringBuilder sb = new StringBuilder();

			int x = 0;
			string currentTable = "";
			string columns = "";
			foreach (DataRow row in stringRows)
			{
				// Check to see if the name of the table matches one of the tables selected on the form
				if (!searchParams.TableNames.Contains(row["TABLE_NAME"]))
					continue;

				if ((string) row["TABLE_NAME"] != currentTable)
				{
					// If a SQL SELECT statement has been built, store it in the list of searches
					CompleteSelectString(sb, currentTable, ref columns);
					// Update the StatusStrip on the form every 16 searches. Why 16? No reason. :)
					x++;
					if (x % 16 == 0)
						SetStatus("Searches = " + queryStrings.Count().ToString());

					// Start a new SQL SELECT statement
					currentTable = (string) row["TABLE_NAME"];
					sb.Clear();
					// Only consider actual tables - no views, stored procedures or other SQL DB objects are considered
					DataRow[] tableRow = dbUtils.SchemaDataSet.Tables["Tables"].Select(String.Format("TABLE_NAME like '{0}'", row["TABLE_NAME"]));
					if (tableRow.Count() == 1 && ((string) tableRow[0]["TABLE_TYPE"]).Equals("BASE TABLE"))
					{
						sb.Append(String.Format("SELECT * FROM [{0}].[{1}].[{2}] WHERE ",
																		row["TABLE_CATALOG"], row["TABLE_SCHEMA"], row["TABLE_NAME"]));
					}
					else
						continue;
				}
				if (searchParams.IsNumeric)
				{
					sb.Append(String.Format("[{0}] = {1} OR ", row["COLUMN_NAME"], searchParams.SearchFor));
					// Append the name of the current column to the list of columns searched
					columns += row["COLUMN_NAME"] + " ";
				}
				else
				{
					// Only search char-type columns where the length of the field is able to hold the search string
					// Ex: Searching for "ABC Motorsports" would not search any column less than 15 chars wide
					if ((int) row["CHARACTER_MAXIMUM_LENGTH"] >= searchParams.SearchFor.Length)
					{
						sb.Append(String.Format("[{0}] like '%{1}%' OR ", row["COLUMN_NAME"], searchParams.SearchFor));
						// Append the name of the current column to the list of columns searched
						columns += row["COLUMN_NAME"] + " ";
					}
				}
			}
			// If a SQL SELECT statement has been built, store it in the list of searches
			CompleteSelectString(sb, currentTable, ref columns);

			SetStatus("Searches = " + queryStrings.Count().ToString());
		}
		/// <summary>
		/// Completes the SQL SELECT string and adds the SearchItem to the queryStrings List
		/// </summary>
		/// <param name="sb">StringBuilder containing the built SQL SELECT statement</param>
		/// <param name="currentTable">Name of the current table in the DB</param>
		/// <param name="columns">Space separated list of columns that will be searched</param>
		private void CompleteSelectString(StringBuilder sb, string currentTable, ref string columns)
		{
			if (sb.ToString().StartsWith("SELECT * FROM ") && sb.ToString().EndsWith("OR "))
			{
				SearchItem si = new SearchItem
				{
					Columns = columns.Trim(),
					TableName = currentTable,
					SqlSelect = sb.ToString().Substring(0, sb.Length - 4) + ";"   // Chop the " OR " from the end
				};
				queryStrings.Add(si);
				columns = "";
			}
		}

		/// <summary>
		/// Builds SQL SELECT strings that will search all appropriate fields in each selected table for non-NULL values
		/// Note this routine builds one SQL SELECT for each column in the table which means for a table like 
		/// PATIENT in Epic's Clarity DB, 136 SQL SELECTs (Epic version 2014) will be generated which seems at first
		/// glance would take forever to execute. In practice, however, the SQL SELECT statements genereated
		/// execute very quickly and only take a few seconds for large rowcount tables with fields that are always NULL
		/// </summary>
		/// <example>
		/// The format of the SQL SELECT statement produced is similar to this:
		/// SELECT TOP 1 [PAT_ID] FROM [CLARITY_PROD].[dbo].[PATIENT] 
		/// </example>
		private void BuildNullSelectStrings()
		{
			// stringRows is a list of all columns in each table
			DataRow[] stringRows = dbUtils.SchemaDataSet.Tables["TableColumns"].Select();

			queryStrings = new List<SearchItem>();

			int x = 0;
			foreach (DataRow row in stringRows)
			{
				if (!searchParams.TableNames.Contains(row["TABLE_NAME"]))
					continue;

				string tableName = String.Format("[{0}].[{1}].[{2}]", row["TABLE_CATALOG"], row["TABLE_SCHEMA"], row["TABLE_NAME"]);
				string columnName = row["COLUMN_NAME"].ToString();
				string search = String.Format("SELECT TOP 1 {0} FROM [{1}].[{2}].[{3}] WHERE {0} IS NOT NULL;",
																row["COLUMN_NAME"], row["TABLE_CATALOG"], row["TABLE_SCHEMA"], row["TABLE_NAME"]);

				SearchItem si = new SearchItem
				{
					Columns = columnName,
					TableName = tableName,
					SqlSelect = search
				};
				queryStrings.Add(si);

				x++;
				if (x % 16 == 0)
					SetStatus("Searches = " + queryStrings.Count().ToString());
			}
			SetStatus("Searches = " + queryStrings.Count().ToString());
		}

		/// <summary>
		/// Builds SQL SELECT strings that return count of all rows in each selected table
		/// </summary>
		/// <example>
		/// The format of the SQL SELECT statement produced is similar to this:
		/// SELECT COUNT(*) FROM [CLARITY_PROD].[dbo].[CLARITY_DEP] 
		/// </example>
		private void BuildRecordCountStrings()
		{
			DataRow[] stringRows = dbUtils.SchemaDataSet.Tables["Tables"].Select();
			queryStrings = new List<SearchItem>();
			StringBuilder sb = new StringBuilder();

			int x = 0;
			foreach (DataRow row in stringRows)
			{
				if (!searchParams.TableNames.Contains(row["TABLE_NAME"]))
					continue;
				sb.Append(String.Format("SELECT COUNT(*) FROM [{0}].[{1}].[{2}];",
																row["TABLE_CATALOG"], row["TABLE_SCHEMA"], row["TABLE_NAME"]));

				SearchItem si = new SearchItem
				{
					Columns = "",
					TableName = (string) row["TABLE_NAME"],
					SqlSelect = sb.ToString()
				};
				queryStrings.Add(si);
				x++;
				if (x % 16 == 0)
					SetStatus("Searches = " + queryStrings.Count().ToString());
				sb.Clear();
			}
			SetStatus("Searches = " + queryStrings.Count().ToString());
		}

		private void SetStatus(string t)
		{
			((StatusStrip) mainForm.Controls["ssStatus"]).Items[0].Text = t;
			((StatusStrip) mainForm.Controls["ssStatus"]).Refresh();
		}

	}
}
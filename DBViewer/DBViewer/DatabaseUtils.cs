using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace DBS
{
	public class DatabaseUtils
	{
		//DataSet schemaDataSet = new DataSet();
		//List<ForeignKeyItem> foreignKeys = new List<ForeignKeyItem>();
		//string currentDatabase = string.Empty;
		//string connectionString = string.Empty;
		//bool isClarity = false;
		public DataSet SchemaDataSet { get; set; }
		public List<ForeignKeyItem> ForeignKeys { get; set; }
		public string CurrentDatabase { get; set; }
		public string ConnectionString { get; set; }
		public bool IsClarityDB { get; set; }

		public DataTable ExclusionData { get; set; }
		public List<ExclusionItem> ExclusionList { get; set; }
		private StatusStrip ss;
		public DatabaseUtils()
		{
			SchemaDataSet = new DataSet();
			ForeignKeys = new List<ForeignKeyItem>();
			CurrentDatabase = string.Empty;
			ConnectionString = string.Empty;
			IsClarityDB = false;
			InitializeExclusionData();
		}

		private void InitializeExclusionData()
		{
			ExclusionData = new DataTable();
			ExclusionData.Columns.Add("Row", typeof(int));
			ExclusionData.Columns.Add("SourceTableName", typeof(string));
			ExclusionData.Columns.Add("SourceColumnName", typeof(string));
			ExclusionData.Columns.Add("DestinationTableName", typeof(string));
			ExclusionData.Columns.Add("DestinationColumnName", typeof(string));
			ExclusionList = new List<ExclusionItem>();
		}

		public void OpenDatabase(string connString, StatusStrip sstrip)
		{
			ss = sstrip;
			ConnectionString = connString.Replace("TAG=Clarity", "");
			IsClarityDB = connString.ToUpper().Contains("TAG=CLARITY") ? true : false;
			SchemaDataSet = new DataSet();
			try
			{
				using (SqlConnection connection = new SqlConnection(ConnectionString))
				{
					// Connect to the database to retrieve schema information
					connection.Open();
					CurrentDatabase = connection.Database;

					SetStatus("Tables");
					SchemaDataSet.Tables.Add(GetTables(connection));
					SetStatus("Columns");
					SchemaDataSet.Tables.Add(GetColumns(connection));
				}
			}
			catch (SqlException se)
			{
				SetStatus(se.Message);
				return;
			}
			catch (Exception exc)
			{
				SetStatus(exc.Message);
				Console.WriteLine("Generic Exception Handler: {0}", exc.ToString());
				return;
			}
		}

		private void SetStatus(string t)
		{
			ss.Items[0].Text = t;
			ss.Refresh();
		}

		/// <summary>
		/// Build a DataTable containing all the Columns in the database
		/// </summary>
		/// <param name="connection">Currently open SqlConnection object</param>
		/// <returns>DataTable object</returns>
		private DataTable GetColumns(SqlConnection connection)
		{
			//DataTable gs = connection.GetSchema();

			DataTable table = connection.GetSchema("Columns");

			table.TableName = "TableColumns";
			return table;
		}

		/// <summary>
		/// Build a DataTable containing all the Tables in the database
		/// </summary>
		/// <param name="connection">Currently open SqlConnection object</param>
		/// <returns>DataTable object</returns>
		private DataTable GetTables(SqlConnection connection)
		{
			DataTable table = new DataTable("Tables");
			table.PrimaryKey = new DataColumn[]
																 {
																	 table.Columns["TABLE_CATALOG"],
																	 table.Columns["TABLE_SCHEMA"],
																	 table.Columns["TABLE_NAME"]
																 };
			table = connection.GetSchema("Tables");
			// Remove all rows that are not "BASE TABLE"
			List<DataRow> rowsToDelete = new List<DataRow>();
			foreach (DataRow row in table.Rows)
			{
				if (!row["TABLE_TYPE"].Equals("BASE TABLE"))
					rowsToDelete.Add(row);
			}
			foreach (DataRow row in rowsToDelete)
			{
				table.Rows.Remove(row);
			}
			return table;
		}

		public void DoSQLCommand(SearchItem si, SearchParams sp)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(ConnectionString))
				{
					// Connect to the database to run the search
					connection.Open();
					using (SqlCommand cmd = new SqlCommand(si.SqlSelect, connection))
					{
						cmd.CommandTimeout = 300;     // 5 minutes should be sufficient
						if (sp.IsRecordCount)
						{
							si.HasRows = true;
							si.NumRows = (int) cmd.ExecuteScalar();
						}
						else
						{
							SqlDataReader sdr = cmd.ExecuteReader();
							si.HasRows = sdr.HasRows;
							if (sdr.HasRows && !sp.IsNull)
							{
								int rows = 0;
								while (sdr.Read())
								{
									rows++;
								}
								si.NumRows = rows;
							}
						}
					}
				}
			}
			catch (SqlException se)
			{
				SetStatus(se.Message);
			}
			catch (Exception exc)
			{
				SetStatus(exc.Message);
				Console.WriteLine("Generic Exception Handler: {0}", exc.ToString());
			}
		}

		internal string GetFKNameField(string destinationTableName)
		{
			string selectStatement = string.Format("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}' AND ORDINAL_POSITION = 2;", destinationTableName);
			string fieldName = string.Empty;
			try
			{
				using (SqlConnection connection = new SqlConnection(ConnectionString))
				{
					// Connect to the database to get the table ID
					connection.Open();
					using (SqlCommand cmd = new SqlCommand(selectStatement, connection))
					{
						cmd.CommandTimeout = 30;     // 30 seconds should be more than sufficient
						SqlDataReader sdr = cmd.ExecuteReader();
						if (sdr.HasRows)
						{
							if (sdr.Read())
							{
								fieldName = sdr.GetString(0);
							}
						}
						sdr.Close();
					}
				}
			}
			catch (SqlException se)
			{
				SetStatus(se.Message);
				MessageBox.Show(se.Message);
			}
			catch (Exception exc)
			{
				SetStatus(exc.Message);
				MessageBox.Show(exc.Message);
				Console.WriteLine("Generic Exception Handler: {0}", exc.ToString());
			}
			return fieldName;
		}

		public void GetForeignKeys(List<ForeignKeyItem> foreignKeys, List<SearchItem> queryStrings, string selectStatement, string tableName)
		{
			string tableID = string.Empty;
			// Load Exclusion data if necessary
			if(ExclusionList.Count == 0)
			{
				if(!LoadExclusionData())
				{
					MessageBox.Show("Unable to load Exclusion Data! Cannot continue Loading Foreign Keys", "Database Utils GetForeignKeys", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
			}

			try
			{
				using (SqlConnection connection = new SqlConnection(ConnectionString))
				{
					// Connect to the database to get the table ID
					connection.Open();
					using (SqlCommand cmd = new SqlCommand(selectStatement, connection))
					{
						cmd.CommandTimeout = 30;     // 30 seconds should be more than sufficient
						SqlDataReader sdr = cmd.ExecuteReader();
						if (sdr.HasRows)
						{
							if (sdr.Read())
							{
								tableID = sdr.GetString(0);
							}
						}
						sdr.Close();
					}
					// Step 3: Get the foreign key records for this table
					selectStatement = string.Format("SELECT [TABLE_ID],[SOURCE_COLUMN_NAME],[DEST_TABLE_NAME],[DEST_COLUMN_NAME] FROM [{0}].[dbo].[CLARITY_TBL_FK_ALL] WHERE [TABLE_ID] = '{1}'", CurrentDatabase, tableID);
					using (SqlCommand cmd = new SqlCommand(selectStatement, connection))
					{
						cmd.CommandTimeout = 30;     // 30 seconds should be more than sufficient
						SqlDataReader sdr = cmd.ExecuteReader();
						if (sdr.HasRows)
						{
							while (sdr.Read())
							{
								ForeignKeyItem fki = new ForeignKeyItem();
								fki.TableName = tableName;
								fki.SourceColumnName = sdr.GetString(1);
								fki.DestinationTableName = sdr.GetString(2);
								fki.DestinationColumnName = sdr.GetString(3);
								
								// Disregard if this found in exclusion list
								var exclusionQuery = from e in ExclusionList
																		 where e.SourceTableName == fki.TableName
																				&& e.SourceColumnName == fki.SourceColumnName
																		 select e;
								if (exclusionQuery.FirstOrDefault() != null)
									continue;

								// Add if in queryStrings
								var searchQuery = from q in queryStrings
																	where q.Columns.Equals(fki.SourceColumnName)
																	select q;
								SearchItem si = searchQuery.FirstOrDefault();
								if (si != null)
								{
									if (si.HasRows)
									{
										// Add if not there already and source column contains data
										var fkQuery = from f in foreignKeys
																	where f.SourceColumnName.Equals(fki.SourceColumnName)
																	select f;
										if (fkQuery.FirstOrDefault() == null)
											foreignKeys.Add(fki);
									}
								}
							}
						}
						sdr.Close();
					}
				}
			}
			catch (SqlException se)
			{
				SetStatus(se.Message);
			}
			catch (Exception exc)
			{
				SetStatus(exc.Message);
				Console.WriteLine("Generic Exception Handler: {0}", exc.ToString());
			}
		}
		internal void SaveExclusionData(DataGridViewRow[] gridRows, string fileName)
		{
			ExclusionData.Clear();
			ExclusionList.Clear();
			foreach (DataGridViewRow row in gridRows)
			{
				if (row.IsNewRow)
					continue;
				DataRow dataRow = ExclusionData.NewRow();
				ExclusionItem ei = new ExclusionItem();

				dataRow["Row"] = (int) row.Cells[0].Value;
				dataRow["SourceTableName"]				= (string) row.Cells[1].Value;
				dataRow["SourceColumnName"]				= (string) row.Cells[2].Value;
//				dataRow["DestinationTableName"]		= (string) row.Cells[3].Value;
//				dataRow["DestinationColumnName"]	= (string) row.Cells[4].Value;
				ExclusionData.Rows.Add(dataRow);

				ei.Row										= (int) row.Cells[0].Value;
				ei.SourceTableName				= (string) row.Cells[1].Value;
				ei.SourceColumnName				= (string) row.Cells[2].Value;
//				ei.DestinationTableName		= (string) row.Cells[3].Value;
//				ei.DestinationColumnName	= (string) row.Cells[4].Value;
				ExclusionList.Add(ei);
			}
			DataView view = new DataView(ExclusionData);
			view.Sort = "SourceTableName ASC, SourceColumnName ASC";
			DataTable dt = view.ToTable();
			dt.TableName = "ExclusionData";
			dt.WriteXml(fileName, XmlWriteMode.WriteSchema);
			dt.Dispose();
			view.Dispose();
		}

		internal bool LoadExclusionData()
		{
			string fileName = Application.ExecutablePath.ToUpper().Replace("DBS2QVLS.EXE", "Exclusions.xml");

			ExclusionData.Clear();
			ExclusionList.Clear();
			ExclusionData.TableName = "ExclusionData";

			if(File.Exists(fileName))
			{
				ExclusionData.ReadXml(fileName);
			}
			else
			{
				return false;
			}

			foreach (DataRow row in ExclusionData.Rows)
			{
				ExclusionItem ei = new ExclusionItem();
				ei.Row = (int) row["Row"];
				ei.SourceTableName				= Convert.IsDBNull(row["SourceTableName"]) ? ""				: (string) row["SourceTableName"];
				ei.SourceColumnName				= Convert.IsDBNull(row["SourceColumnName"]) ? ""			: (string) row["SourceColumnName"];
//				ei.DestinationTableName		= Convert.IsDBNull(row["DestinationTableName"]) ? ""	: (string) row["DestinationTableName"];
//				ei.DestinationColumnName	= Convert.IsDBNull(row["DestinationColumnName"]) ? ""	: (string) row["DestinationColumnName"];
				ExclusionList.Add(ei);
			}
			return true;
		}
	}
}

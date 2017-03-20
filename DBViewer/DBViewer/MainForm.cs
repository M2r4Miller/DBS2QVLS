using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using XCrypt;

namespace DBS
{
	public partial class MainForm : Form
	{
		XCryptEngine xe = new XCryptEngine();
		XCryptEngine.AlgorithmType chosenAlgorithm = XCryptEngine.AlgorithmType.TripleDES;

		DatabaseUtils dbUtils;
		DBSearchUtils dbSearch;
		Options currentOptions = new Options();
		List<string> tablesList = new List<string>();
		List<string> filteredTablesList = new List<string>();
		List<string> columnsList = new List<string>();
		List<string> filteredColumnsList = new List<string>();

		public MainForm()
		{
			InitializeComponent();
			dbUtils = new DatabaseUtils();
			dbSearch = new DBSearchUtils(dbUtils);

			xe.InitializeEngine(chosenAlgorithm);
		}

		//private void LoadConnections()
		//{
		//	string[] lines = File.ReadAllLines("Connections.txt");
		//	cboConnString.Items.AddRange(lines);
		//	cboConnString.Refresh();
		//}

		/// <summary>
		/// Open the database, loads the schema into the dataset
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <exception>Throws SqlException or a general Exception</exception>
		private void btnOpenDatabase_Click(object sender, EventArgs e)
		{
			if(string.IsNullOrEmpty(cboConnString.Text))
			{
				MessageBox.Show("Enter or select an existing connection string before clicking \"Open\"!", "Open Database Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}

			// Collapse the columns list box
			splitContainer3.SuspendLayout();
			splitContainer3.Panel2Collapsed = true;
			btnShowColumns.Text = ">";
			splitContainer3.ResumeLayout();

			tablesList.Clear();
			TablesListBox.DataSource = null;
			TablesListBox.Refresh();

			ssStatus.Items[0].Text = "";
			txtResults.Text = "Opening Database - for Clarity and other very large schemas, this may take some time. Be patient." +
												"\r\nFor example, Clarity takes over 30 seconds to load";
			txtResults.Refresh();

			DateTime start = DateTime.Now;

			string connString = cboConnString.Text.Trim();
			dbUtils.OpenDatabase(connString, ssStatus);
			foreach (DataRow row in dbUtils.SchemaDataSet.Tables["Tables"].Rows)
			{
				tablesList.Add(row["TABLE_NAME"].ToString());
			}
			TablesListBox.DataSource = tablesList;
			TablesListBox.Refresh();
			TimeSpan elapsed = DateTime.Now - start;
			SetStatus(String.Format("Database Loaded: {0} in {1:D2} hours, {2:D2} minutes, {3:D2} seconds and {4:D2} milliseconds",
																							dbUtils.CurrentDatabase, elapsed.Hours,
																							elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds));
			btnSearch.Enabled = true;
			btnSelectAllTables.Enabled = true;
		}

		/// <summary>
		/// Updates the StatusStrip control
		/// </summary>
		/// <param name="t">String to display</param>
		private void SetStatus(string t)
		{
			ssStatus.Items[0].Text = t;
			ssStatus.Refresh();
		}

		/// <summary>
		/// Performs pre-search functions and then kicks off the actual search process on the selected tables
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSearch_Click(object sender, EventArgs e)
		{
			if (!rdoNullSearch.Checked)
			{
				if (String.IsNullOrEmpty(txtSearchString.Text) && !chkRecordCountsOnly.Checked)
				{
					txtResults.Text = "Nothing to search for!";
					txtResults.Refresh();
					return;
				}
			}
			DateTime startTime = DateTime.Now;
			SearchParams sp = new SearchParams
			{
				IsNull = rdoNullSearch.Checked,
				IsNumeric = rdoNumericSearch.Checked,
				IsString = rdoStringSearch.Checked,
				IsRecordCount = chkRecordCountsOnly.Checked,
				IsQVScript = chkBuildQVLoad.Checked,
				SearchFor = txtSearchString.Text.Trim(),
				TableNames = new List<string>(),
				ColumnNames = new List<ColumnItem>()
			};

			// Add selected tables to SearchParams object
			foreach (string item in TablesListBox.SelectedItems)
			{
				sp.TableNames.Add(item);
			}
			if (!splitContainer3.Panel2Collapsed)
			{
				string tableName = string.Empty;
				foreach (string item in ColumnsListBox.SelectedItems)
				{
					if (!item.StartsWith("  "))
					{
						tableName = item;
					}
					sp.ColumnNames.Add(new ColumnItem { TableName = tableName, ColumnName = item.TrimStart() });
				}
			}

			txtResults.Text = sp.IsNull && !sp.IsQVScript ? "Null Columns ..." : "";
			txtResults.Refresh();

			dbSearch.PerformSearch(sp, this);

			txtResults.Refresh();
			TimeSpan elapsed = DateTime.Now - startTime;
			if (!String.IsNullOrEmpty(txtResults.Text))
			{
				Clipboard.SetText(txtResults.Text);
				SetStatus(string.Format("Search complete in {0:D2} hours, {1:D2} minutes, {2:D2} seconds and {3:D2} milliseconds. Results copied to Clipboard", elapsed.Hours, elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds));
			}
			else
				SetStatus(string.Format("Search complete in {0:D2} hours, {1:D2} minutes, {2:D2} seconds and {3:D2} milliseconds.", elapsed.Hours, elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds));
		}

		public void UpdateLabels(SearchItem si)
		{
			lblTableName.Text = si.TableName;
			lblTableName.Refresh();
			lblColumnName.Text = si.Columns;
			lblColumnName.Refresh();
		}

		public enum TextResultsHandling
		{
			Clear,
			Append
		}

		public void UpdateTextResults(TextResultsHandling action, string txt)
		{
			if (action == TextResultsHandling.Append)
			{
				txtResults.Text += txt;
				txtResults.Refresh();
			}
			else
			{
				txtResults.Clear();
				txtResults.Text = txt;
				txtResults.Refresh();
			}

		}

		/// <summary>
		/// Toggles form elements based on Record Counts Only Check Box state
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void chkRecordCountsOnly_CheckedChanged(object sender, EventArgs e)
		{
			txtSearchString.Enabled = !chkRecordCountsOnly.Checked;
			rdoStringSearch.Checked = chkRecordCountsOnly.Checked;
			if (chkRecordCountsOnly.Checked)
				chkBuildQVLoad.Checked = false;
		}

		/// <summary>
		/// Selects all tables in the database schema for searching
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSelectAllTables_Click(object sender, EventArgs e)
		{
			TablesListBox.SuspendLayout();
			ColumnsListBox.SuspendLayout();
			for (int i = 0; i < TablesListBox.Items.Count; i++)
			{
				TablesListBox.SetSelected(i, true);
			}
			TablesListBox.TopIndex = 0;
			RefreshColumnList();
			TablesListBox.ResumeLayout();
			ColumnsListBox.ResumeLayout();
		}

		/// <summary>
		/// Show the Database Connection Maintenance form as a modal dialog
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnConnections_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(xe.Key))
			{
				DBConnMaint dbcm = new DBConnMaint();
				dbcm.XE = xe;
				dbcm.ShowDialog();
			}
			else
			{
				if(!string.IsNullOrEmpty(txtPassword.Text))
				{
					DBConnMaint dbcm = new DBConnMaint();
					xe.Key = txtPassword.Text.Trim();
					dbcm.XE = xe;
					dbcm.ShowDialog();
				}
				else
				{
					MessageBox.Show("Must enter the password before attempting Connection Maintenance.", "Connection Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				}
			}
		}

		/// <summary>
		/// Very simple method of loading the encrypted Connections file
		/// Does trap CryptographicException which occurs if the file cannot be decrypted which 
		/// most likely is caused by a bad password, but could be due to a corrupted Connections file
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnLoadConnections_Click(object sender, EventArgs e)
		{
			cboConnString.Items.Clear();
			if (!string.IsNullOrEmpty(txtPassword.Text))
			{
				try
				{
					xe.Key = txtPassword.Text;
					// Open file and read strings into array, decrypt them one by one
					string[] encConnections = File.ReadAllLines("Connections.txt");
					foreach (string item in encConnections)
					{
						cboConnString.Items.Add(xe.Decrypt(item));
					}
					MessageBox.Show("Connections loaded!", "Connection Loader", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (FileNotFoundException)
				{
					MessageBox.Show("Connections File Not Found!\n\nCreate one by clicking Connections button.", "Connection Loader", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				}
				catch (CryptographicException)
				{
					MessageBox.Show("Bad Password or corrupted Connections file!\n\nConnections NOT loaded!", "Connection Loader", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				}
				cboConnString.Refresh();
			}
			else
			{
				MessageBox.Show("Must enter the password before Loading Connections!", "Connection Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			About about = new About();
			about.ShowDialog();
		}

		private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ExclusionMaint em = new ExclusionMaint(dbUtils);
			em.Show();
		}

		private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OptionsMaint om = new OptionsMaint();
			om.ShowDialog();
			currentOptions.LoadOptions();
		}

		private void txtFilter_Enter(object sender, EventArgs e)
		{
			txtFilter.SelectAll();
		}

		private void txtFilter_TextChanged(object sender, EventArgs e)
		{
			SetTableFilter();
		}

		private void SetTableFilter()
		{
			if (txtFilter.Text.Equals("Filter..."))
				return;

			filteredTablesList.Clear();
			TablesListBox.DataSource = null;
			if (rdoContains.Checked)
			{
				var filterQuery = from t in tablesList
													where t.Contains(txtFilter.Text.Trim())
													select t;
				filteredTablesList.AddRange(filterQuery.ToList<string>());
			}
			else
			{
				var filterQuery = from t in tablesList
													where t.StartsWith(txtFilter.Text.Trim())
													select t;
				filteredTablesList.AddRange(filterQuery.ToList<string>());
			}
			TablesListBox.DataSource = filteredTablesList;
			TablesListBox.Refresh();
			RefreshColumnList();
		}

		private void txtFilter_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtFilter.Text))
			{
				txtFilter.Text = "Filter...";
				txtFilter.Refresh();
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnShowColumns_Click(object sender, EventArgs e)
		{
			splitContainer3.SuspendLayout();
			if(splitContainer3.Panel2Collapsed)
			{
				btnShowColumns.Text = "<";
				splitContainer3.Panel2Collapsed = false;
				toolTip1.SetToolTip(btnShowColumns, "Hide Columns");
				splitContainer3.SplitterDistance = splitContainer3.Width / 2;
				LoadColumns();
			}
			else
			{
				btnShowColumns.Text = ">";
				splitContainer3.Panel2Collapsed = true;
				toolTip1.SetToolTip(btnShowColumns, "Show Columns");
			}
			splitContainer3.ResumeLayout();
		}

		private void LoadColumns()
		{
			// If no database currently open, don't do anything
			if (string.IsNullOrEmpty(dbUtils.CurrentDatabase))
				return;
			ColumnsListBox.SuspendLayout();
			columnsList.Clear();
			ColumnsListBox.DataSource = null;
			string selectedTables = string.Empty;
			foreach (string item in TablesListBox.SelectedItems)
			{
				selectedTables += item + ",";
			}
			var columnQuery = from c in dbUtils.SchemaDataSet.Tables["TableColumns"].AsEnumerable()
												where selectedTables.Contains(c.Field<string>("TABLE_NAME"))
												select c;

			columnsList = PopulateTheColumnList(columnQuery);
			ColumnsListBox.DataSource = columnsList;
			ColumnsListBox.ResumeLayout();
		}

		private List<string> PopulateTheColumnList(EnumerableRowCollection<DataRow> columnQuery)
		{
			List<string> tempList = new List<string>();
			string currentTable = string.Empty;
			foreach (DataRow row in columnQuery)
			{
				string tableName = row["TABLE_NAME"].ToString();
				string columnName = "  " + row["COLUMN_NAME"].ToString();
				if (!currentTable.Equals(tableName))
				{
					tempList.Add(tableName);
					currentTable = tableName;
				}
				tempList.Add(columnName);
			}
			return tempList;
		}

		private void RefreshColumnList()
		{
			if (!splitContainer3.Panel2Collapsed)
			{
				LoadColumns();
			}
		}

		private void TablesListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			RefreshColumnList();
		}

		private void txtColumnFilter_TextChanged(object sender, EventArgs e)
		{
			SetColumnFilter();
		}

		private void SetColumnFilter()
		{
			if (txtColumnFilter.Text.Equals("Filter..."))
				return;

			ColumnsListBox.SuspendLayout();
			filteredColumnsList.Clear();
			ColumnsListBox.DataSource = null;
			EnumerableRowCollection<DataRow> filterQuery;
			if (rdoColumnContains.Checked)
			{
				filterQuery = from c in dbUtils.SchemaDataSet.Tables["TableColumns"].AsEnumerable()
											where c.Field<string>("COLUMN_NAME").Contains(txtColumnFilter.Text.Trim())
											select c;
			}
			else
			{
				filterQuery = from c in dbUtils.SchemaDataSet.Tables["TableColumns"].AsEnumerable()
											where c.Field<string>("COLUMN_NAME").StartsWith(txtColumnFilter.Text.Trim())
											select c;
			}
			filteredColumnsList = PopulateTheColumnList(filterQuery);

			ColumnsListBox.DataSource = filteredColumnsList;
			ColumnsListBox.ResumeLayout();
		}

		private void txtColumnFilter_Enter(object sender, EventArgs e)
		{
			txtColumnFilter.SelectAll();
		}

		private void txtColumnFilter_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtColumnFilter.Text))
			{
				txtColumnFilter.Text = "Filter...";
				txtColumnFilter.Refresh();
			}
		}

		private void rdoColumnStartsWith_CheckedChanged(object sender, EventArgs e)
		{
			SetColumnFilter();
		}

		private void rdoColumnContains_CheckedChanged(object sender, EventArgs e)
		{
			SetColumnFilter();
		}

		private void rdoStartsWith_CheckedChanged(object sender, EventArgs e)
		{
			SetTableFilter();
		}

		private void rdoContains_CheckedChanged(object sender, EventArgs e)
		{
			SetTableFilter();
		}

		private void rdoNumericSearch_CheckedChanged(object sender, EventArgs e)
		{
			if (rdoNumericSearch.Checked)
				chkBuildQVLoad.Checked = false;
		}

		private void rdoStringSearch_CheckedChanged(object sender, EventArgs e)
		{
			if (rdoStringSearch.Checked)
				chkBuildQVLoad.Checked = false;
		}

		/// <summary>
		/// Toggles form elements based on Null Search Radio Button state
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rdoNullSearch_CheckedChanged(object sender, EventArgs e)
		{
			txtSearchString.Enabled = !rdoNullSearch.Checked;
			chkBuildQVLoad.Enabled = rdoNullSearch.Checked;
		}
	}
}

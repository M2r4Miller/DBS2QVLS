using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBS
{
	public partial class ExclusionMaint : Form
	{
		public DatabaseUtils DBUtils { get; set; }

		public ExclusionMaint(DatabaseUtils dbUtils)
		{
			InitializeComponent();
			DBUtils = dbUtils;
		}
		private void ExclusionMaint_Load(object sender, EventArgs e)
		{
			LoadExclusions();
		}

		private void FillGrid()
		{
			ExclusionGrid.Rows.Clear();
			// Start with 1 row in the table or existing Exclusion records
			if(DBUtils.ExclusionList.Count > 0)
			{
				int rowCount = 0;
				ExclusionGrid.Rows.Add(DBUtils.ExclusionList.Count);
				foreach (ExclusionItem item in DBUtils.ExclusionList)
				{
					DataGridViewRow row = ExclusionGrid.Rows[rowCount];
					row.Cells[0].Value = rowCount + 1;
					row.Cells[1].Value = item.SourceTableName;
					row.Cells[2].Value = item.SourceColumnName;
					//row.Cells[3].Value = item.DestinationTableName;
					//row.Cells[4].Value = item.DestinationColumnName;
					rowCount++;
				}
				ExclusionGrid.Rows[rowCount].Cells[0].Value = rowCount + 1;
			}
			else
			{
				ExclusionGrid.Rows[0].Cells[0].Value = 1;
			}
		}

		private void ExclusionGrid_Enter(object sender, EventArgs e)
		{
			ExclusionGrid.CurrentCell = ExclusionGrid.Rows[0].Cells[0];
		}

		private void ExclusionGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			ExclusionGrid.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
			if (e.RowIndex > 0)
			{
				ExclusionGrid.Rows[e.RowIndex].Cells[1].Value = ExclusionGrid.Rows[e.RowIndex - 1].Cells[1].Value;
			}
		}

		private void ExclusionGrid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			int rowIndex = 0;
			foreach (DataGridViewRow row in ExclusionGrid.Rows)
			{
				rowIndex++;
				row.Cells[0].Value = rowIndex;
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveExclusions();
		}

		private void SaveExclusions()
		{
			DataGridViewRow[] gridRows = new DataGridViewRow[ExclusionGrid.Rows.Count];
			ExclusionGrid.Rows.CopyTo(gridRows, 0);
			//string execPath = Application.ExecutablePath.ToUpper().Replace("DBS2QVLS.EXE", "Searches");
			string savePath = Application.ExecutablePath.ToUpper().Replace("DBS2QVLS.EXE", "Exclusions.xml");
			DBUtils.SaveExclusionData(gridRows, savePath);
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoadExclusions();
		}

		private void LoadExclusions()
		{
			if (DBUtils.LoadExclusionData())
			{
				FillGrid();
			}
			else
			{
				MessageBox.Show("Unable to load Exclusion Data", "Exclusin Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void ExclusionGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if(e.ColumnIndex == 1 && e.RowIndex > 0)
			{
				if(ExclusionGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null ||
					 ExclusionGrid.Rows[e.RowIndex].IsNewRow && (string) ExclusionGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != currentTable)
				{
					ExclusionGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = currentTable;
				}
			}
		}
		string currentTable = "";
		private void ExclusionGrid_CellLeave(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void ExclusionGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 1)
			{
				currentTable = (string) ExclusionGrid.Rows[e.RowIndex].Cells[1].Value;
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveExclusions();
			this.Close();
		}
	}
}

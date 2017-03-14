using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBS
{
	public partial class OptionsMaint : Form
	{
		private Options currentOptions;

		public OptionsMaint()
		{
			InitializeComponent();
		}

		private void OptionsMaint_Load(object sender, EventArgs e)
		{
			currentOptions = new Options();
			chkMapC.Checked							= currentOptions.MapCFields;
			chkMapID.Checked						= currentOptions.MapIDFields;
			chkDTTMDate.Checked					= currentOptions.DateFromDTTM;
			chkDTTMTime.Checked					= currentOptions.TimeFromDTTM;
			chkDATETIMEDate.Checked			= currentOptions.DateFromDATETIME;
			chkDATETIMETime.Checked			= currentOptions.TimeFromDATETIME;
			chkIncludeNulls.Checked			= currentOptions.IncludeNullFields;
			txtMapName.Text							= currentOptions.MapName;
			txtExpandedFieldName.Text		= currentOptions.ExpandedFieldName;
			this.Refresh();
		}

		private void btnAccept_Click(object sender, EventArgs e)
		{
			SetOptions();
			currentOptions.SaveOptions();
			this.Close();
		}


		private void btnApply_Click(object sender, EventArgs e)
		{
			SetOptions();
		}

		private void SetOptions()
		{
			currentOptions.MapCFields = chkMapC.Checked;
			currentOptions.MapIDFields = chkMapID.Checked;
			currentOptions.DateFromDTTM = chkDTTMDate.Checked;
			currentOptions.TimeFromDTTM = chkDTTMTime.Checked;
			currentOptions.DateFromDATETIME = chkDATETIMEDate.Checked;
			currentOptions.TimeFromDATETIME = chkDATETIMETime.Checked;
			currentOptions.IncludeNullFields = chkIncludeNulls.Checked;
			currentOptions.MapName = txtMapName.Text;
			currentOptions.ExpandedFieldName = txtExpandedFieldName.Text;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}

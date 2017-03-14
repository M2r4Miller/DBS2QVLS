using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBS
{
	public class Options
	{
		public bool MapCFields { get; set; }
		public bool MapIDFields { get; set; }
		public bool DateFromDTTM { get; set; }
		public bool TimeFromDTTM { get; set; }
		public bool DateFromDATETIME { get; set; }
		public bool TimeFromDATETIME { get; set; }
		public string MapName { get; set; }
		public string ExpandedFieldName { get; set; }
		public bool IncludeNullFields { get; set; }

		private class OptionLine
		{
			public string OptionItem { get; set; }
			public string OptionValue { get; set; }
		}

		public Options()
		{
			LoadOptions();
		}
		public void LoadOptions()
		{
			string fileName = Application.ExecutablePath.ToUpper().Replace("DBS2QVLS.EXE", "Options.txt");
			string[] lines = File.ReadAllLines(fileName);

			foreach (string line in lines)
			{
				OptionLine ol = DecodeOption(line);
				if (ol.OptionItem.Equals("MapC"))
				{
					MapCFields = (ol.OptionValue == "Yes" ? true : false);
				}
				if (ol.OptionItem.Equals("MapID"))
				{
					MapIDFields = (ol.OptionValue == "Yes" ? true : false);
				}
				if (ol.OptionItem.Equals("DateFromDTTM"))
				{
					DateFromDTTM = (ol.OptionValue == "Yes" ? true : false);
				}
				if (ol.OptionItem.Equals("TimeFromDTTM"))
				{
					TimeFromDTTM = (ol.OptionValue == "Yes" ? true : false);
				}
				if (ol.OptionItem.Equals("DateFromDATETIME"))
				{
					DateFromDATETIME = (ol.OptionValue == "Yes" ? true : false);
				}
				if (ol.OptionItem.Equals("TimeFromDATETIME"))
				{
					TimeFromDATETIME = (ol.OptionValue == "Yes" ? true : false);
				}
				if (ol.OptionItem.Equals("IncludeNullFields"))
				{
					IncludeNullFields = (ol.OptionValue == "Yes" ? true : false);
				}
				if (ol.OptionItem.Equals("MapName"))
				{
					MapName = ol.OptionValue;
				}
				if (ol.OptionItem.Equals("ExpandedFieldName"))
				{
					ExpandedFieldName = ol.OptionValue;
				}
			}
		}

		public void SaveOptions()
		{
			string fileName = Application.ExecutablePath.ToUpper().Replace("DBS2QVLS.EXE", "Options.txt");
			StringBuilder sb = new StringBuilder();

			sb.AppendLine(string.Format("MapC : {0}",								MapCFields ? "Yes" : "No"));
			sb.AppendLine(string.Format("MapID : {0}",							MapIDFields ? "Yes" : "No"));
			sb.AppendLine(string.Format("DateFromDTTM : {0}",				DateFromDTTM ? "Yes" : "No"));
			sb.AppendLine(string.Format("TimeFromDTTM : {0}",				TimeFromDTTM ? "Yes" : "No"));
			sb.AppendLine(string.Format("DateFromDATETIME : {0}",		DateFromDATETIME ? "Yes" : "No"));
			sb.AppendLine(string.Format("TimeFromDATETIME : {0}",		TimeFromDATETIME ? "Yes" : "No"));
			sb.AppendLine(string.Format("IncludeNullFields : {0}",	IncludeNullFields ? "Yes" : "No"));
			sb.AppendLine(string.Format("MapName : {0}",						string.IsNullOrEmpty(MapName) ? "Map" : MapName));
			sb.AppendLine(string.Format("ExpandedFieldName : {0}",	string.IsNullOrEmpty(ExpandedFieldName) ? "NAME" : ExpandedFieldName));

			File.WriteAllText(fileName, sb.ToString());
		}

		private OptionLine DecodeOption(string line)
		{
			OptionLine ol = new OptionLine();
			string[] parts = line.Split(':');
			ol.OptionItem = parts[0].Trim();
			ol.OptionValue = parts[1].Trim();
			return ol;
		}

	}
}

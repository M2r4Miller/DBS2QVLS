using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBS
{
	public class SearchParams
	{
		public bool IsString { get; set; }
		public bool IsNumeric { get; set; }
		public bool IsRecordCount { get; set; }
		public bool IsNull { get; set; }
		public bool IsQVScript { get; set; }
		public string SearchFor { get; set; }
		public List<string> TableNames { get; set; }
		public List<ColumnItem> ColumnNames { get; set; }
	}
}

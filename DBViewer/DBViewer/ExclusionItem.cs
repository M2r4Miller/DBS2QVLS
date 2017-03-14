using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBS
{
	public class ExclusionItem
	{
		public int Row { get; set; }
		public string SourceTableName { get; set; }
		public string SourceColumnName { get; set; }
		public string DestinationTableName { get; set; }
		public string DestinationColumnName { get; set; }
	}
}

namespace DBS
{
	public class SearchItem
	{
		public string TableName { get; set; }
		public string Columns { get; set; }
		public string SqlSelect { get; set; }
		public int NumRows { get; set; }
		public bool HasRows { get; set; }
	}
}

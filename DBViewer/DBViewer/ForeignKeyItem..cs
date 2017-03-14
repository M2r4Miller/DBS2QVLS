namespace DBS
{
	public class ForeignKeyItem
	{
		public string TableName { get; set; }
		public string SourceColumnName { get; set; }
		public string DestinationTableName { get; set; }
		public string DestinationColumnName { get; set; }
	}
}

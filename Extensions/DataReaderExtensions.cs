using System.Data;
using System.Linq;

namespace dpTools
{
	public static class DataReaderExtensions
	{
		public static bool ColumnExists(this IDataReader dr, string colName)
		{
			return Enumerable.Range(0, dr.FieldCount).Select(dr.GetName).ToList().Exists(t => t == colName);
		}
	}
}

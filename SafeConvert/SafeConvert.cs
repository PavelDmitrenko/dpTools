using System;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace dpTools
{
	public static class SafeConvert
	{
		 
		#region ToBool

		public static bool ToBool(object s)
		{

			if (s is bool?)
			{
				var v = (bool?) s;
				return v == true;
			}

			if (s is int)
			{
				int i = (int) s;
				return i != 0 && (i == 1 ? true : false);
			}
			if (s is DBNull)
			{
				return false;
			}
			throw new Exception("Неизвестный тип Bool");
		}

		#endregion

		#region BoolToInt

		public static int BoolToInt(bool pVal)
		{
			return pVal ? 1 : 0;
		}

		#endregion

		#region ToInt

		public static int ToInt(object val)
		{
			if (val is int)
				return (int) val;

			if (val is long || val is byte || val is short || val is decimal || val is double)
				return Convert.ToInt32(val);
		
			if (val is string)
			{
				int res;
				int.TryParse((string) val, out res);
				return res;
			}
			if (val is bool)
			{
				bool res = (bool)val;
				return res?1:0;
			}
			if (val is JValue)
			{
				var jv = (JValue) val;
				return int.Parse(jv.ToString());
			}

			if (val is DBNull)
				return 0;

			if (val == null)
				return 0;

			throw new Exception("Unknow INT");
		}

		#endregion

		#region ToDecimal

		public static decimal ToDecimal(object val)
		{
			if (val is decimal)
				return (decimal) val;

			if (val is double)
				return Convert.ToDecimal(val);

			if (val is DBNull)
				return 0;

			if (val is string)
			{
				char separator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
				decimal outVal;

				if (decimal.TryParse(((string)val).Replace('.', separator).Replace(',', separator), out outVal))
					return outVal;
			}

			if (val is int)
				return Convert.ToDecimal(val);

			throw new Exception("Unknown DECIMAL");
		}

		#endregion

		#region ToGuid

		public static Guid ToGuid(object s)
		{
			Guid val;

			if (s is Guid)
				return (Guid)s;
			
			if (s is string)
			{
				if (!Guid.TryParse((string) s, out val)) return default(Guid);
				return val;
			}

			if (s is JValue)
			{
				var jv = (JValue) s;
				if (!Guid.TryParse((string) jv.Value, out val)) return default(Guid);
				return val;
			}

			throw new Exception("Неизвестный тип Guid");
		}

		#endregion

		#region ToString

		public static string ToString(object val)
		{
			if (val is string)
				return (string) val;

			if (val is DBNull)
				return string.Empty;

			if (val == null)
				return "";

			return val.ToString();

		}

		#endregion

		#region ToNullable
		public static T? ToNullable<T>(object val) where T : struct

		{
			if (val is DBNull)
				return null;

			return val as T?;
		}
		#endregion

	}
}

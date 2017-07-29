using System;
using System.Globalization;

namespace dpTools
{

	public static class DateTimeExtention
	{

		#region GetStartOfWeek
		/// <summary>
		/// Возвращает дату начала текущей недели
		/// </summary>
		public static DateTime GetStartOfWeek(this DateTime date, CultureInfo ci = null)
		{
			if (ci == null)
				ci = new CultureInfo("ru-RU");

			var firstDayOfWeek = ci.DateTimeFormat.FirstDayOfWeek;

			while (date.DayOfWeek != firstDayOfWeek)
				date = date.AddDays(-1);

			return date;
		} 
		#endregion

	}
}

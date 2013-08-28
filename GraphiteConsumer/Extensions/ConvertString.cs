using System;

namespace GraphiteConsumer.Extensions
{
	static internal class ConvertString
	{
		public static float? ToNullableFloat(this string input)
		{
			float output;
			return Single.TryParse(input, out output) ? output : (float?) null;
		}

		public static DateTime ToDateTime(this string input)
		{
			return _epochStart.AddSeconds(Int64.Parse(input));
		}

		private static DateTime _epochStart = new DateTime(1970, 1, 1, 0, 0, 0, 0);

		public static int ToInt(this string s)
		{
			return Int32.Parse(s);
		}
	}
}
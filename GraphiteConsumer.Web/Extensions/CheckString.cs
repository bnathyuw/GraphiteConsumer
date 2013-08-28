using System;

namespace GraphiteConsumer.Web.Extensions
{
	static internal class CheckString
	{
		public static bool HasValue(this string input)
		{
			return !String.IsNullOrWhiteSpace(input);
		}
	}
}
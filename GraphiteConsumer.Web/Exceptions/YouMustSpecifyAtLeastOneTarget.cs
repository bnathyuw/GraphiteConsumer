using System;

namespace GraphiteConsumer.Web.Exceptions
{
	internal class YouMustSpecifyAtLeastOneTarget : Exception
	{
		public YouMustSpecifyAtLeastOneTarget()
			: base("You must specify a target in the query string")
		{

		}
	}
}
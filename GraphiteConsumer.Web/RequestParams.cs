using System;
using System.Collections.Generic;
using System.Web;
using GraphiteConsumer.Graphite;
using GraphiteConsumer.Web.Exceptions;

namespace GraphiteConsumer.Web
{
	public class RequestParams
	{
		private RequestParams() { }

		private IEnumerable<string> _targets;
		private string _from;
		private string _until;

		public static RequestParams FromHttpRequest(HttpRequest httpRequest)
		{
			var targets = ParseTargets(httpRequest);
			var from = httpRequest.QueryString["from"] ?? "-48hours";
			var until = httpRequest.QueryString["until"] ?? "-";
			return new RequestParams {_targets = targets, _from = from, _until = until};
		}

		private static IEnumerable<string> ParseTargets(HttpRequest request)
		{
			var targetsFromQueryString = request.QueryString["target"];
			
			if (String.IsNullOrWhiteSpace(targetsFromQueryString)) throw new YouMustSpecifyAtLeastOneTarget();

			return new[] {targetsFromQueryString};
		}

		public GraphiteParams ToGraphiteParams()
		{
			return new GraphiteParams(_targets, _from, _until);
		}
	}
}
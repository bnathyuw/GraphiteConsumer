using System.Configuration;
using System.Net;
using GraphiteConsumer.Web.Extensions;
using GraphiteConsumer.Web.Model;

namespace GraphiteConsumer.Web.Graphite
{
	public static class GraphiteDataRetriever
	{
		private static readonly string GraphiteServerName = ConfigurationManager.AppSettings["GraphiteServerName"];

		public static string GetRawData(RequestParams requestParams)
		{
			var graphiteParams = requestParams.ToGraphiteParams();

			var webResponse = CallGraphite(graphiteParams);

			return webResponse.ReadBody();
		}

		private static WebResponse CallGraphite(GraphiteParams graphiteParams)
		{
			var url = MakeGraphiteUrl(graphiteParams);

			var webRequest = WebRequest.Create(url);

			return webRequest.GetResponse();
		}

		private static string MakeGraphiteUrl(GraphiteParams graphiteParams)
		{
			return string.Format("http://{0}/render?{1}", GraphiteServerName, graphiteParams);
		}
	}
}
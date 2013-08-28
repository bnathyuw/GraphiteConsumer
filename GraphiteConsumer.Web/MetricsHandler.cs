using System;
using System.Web;
using GraphiteConsumer.Graphite;
using GraphiteConsumer.Model;

namespace GraphiteConsumer.Web
{
	public class MetricsHandler:IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			try
			{
				var requestParams = RequestParams.FromHttpRequest(context.Request);

				var graphiteParams = requestParams.ToGraphiteParams();

				var rawData = GraphiteDataRetriever.GetRawData(graphiteParams);

				var data = Data.FromRawData(rawData);

				context.Response.WriteOkResponse(data);
			}
			catch (Exception exception)
			{
				context.Response.WriteErrorResponse(exception);
			}
		}

		public bool IsReusable
		{
			get { return false; }
		}
	}
}
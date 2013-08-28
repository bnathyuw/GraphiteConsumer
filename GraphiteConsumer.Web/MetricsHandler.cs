using System;
using System.Web;
using GraphiteConsumer.Web.Graphite;
using GraphiteConsumer.Web.Model;

namespace GraphiteConsumer.Web
{
	public class MetricsHandler:IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			try
			{
				var requestParams = RequestParams.FromHttpRequest(context.Request);

				var rawData = GraphiteDataRetriever.GetRawData(requestParams);

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
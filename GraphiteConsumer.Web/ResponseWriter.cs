using System;
using System.Net;
using System.Web;
using GraphiteConsumer.Web.Model;

namespace GraphiteConsumer.Web
{
	static internal class ResponseWriter
	{
		public static void WriteOkResponse(this HttpResponse httpResponse, Data data)
		{
			httpResponse.Write(data);
			httpResponse.ContentType = "text/plain";
			httpResponse.StatusCode = (int) HttpStatusCode.OK;
		}

		public static void WriteErrorResponse(this HttpResponse httpResponse, Exception exception)
		{
			httpResponse.Write(exception.Message);
			httpResponse.ContentType = "text/plain";
			httpResponse.StatusCode = (int) HttpStatusCode.InternalServerError;
		}
	}
}
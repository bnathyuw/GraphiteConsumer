using System.IO;
using System.Net;

namespace GraphiteConsumer.Extensions
{
	public static class WebResponseExtensions
	{
		public static string ReadBody(this WebResponse webResponse)
		{
			var responseBody = "";
			using (var responseStream = webResponse.GetResponseStream())
				if (responseStream != null)
					using (var streamReader = new StreamReader(responseStream))
						responseBody = streamReader.ReadToEnd();
			return responseBody;
		}
	}
}
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphiteConsumer.Extensions;

namespace GraphiteConsumer.Model
{
	public class Data
	{
		private Data() { }

		private IEnumerable<Metric> _metrics;

		public static Data FromRawData(string responseBody)
		{
			var metrics = responseBody.Split('\n').Where(CheckString.HasValue).Select(Metric.FromRawData);
			return new Data {_metrics = metrics};
		}

		public override string ToString()
		{
			var stringBuilder = new StringBuilder();
			foreach (var metric in _metrics)
			{
				stringBuilder.Append(metric);
			}
			return stringBuilder.ToString();
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphiteConsumer.Graphite
{
	public class GraphiteParams
	{
		public GraphiteParams(IEnumerable<string> targets, string @from, string until)
		{
			Targets = targets;
			From = @from;
			Until = until;
		}

		private IEnumerable<string> Targets { get; set; }
		private string From { get; set; }
		private string Until { get; set; }

		public override string ToString()
		{
			var parameters = Targets.ToDictionary(target => "target");
			parameters.Add("from", From);
			parameters.Add("until", Until);
			parameters.Add("format", "raw");
			return parameters.Aggregate("", ToParameter);
		}

		private static string ToParameter(string currentValue, KeyValuePair<string, string> parameterPair)
		{
			return String.Format("{0}{1}={2}&", currentValue, parameterPair.Key, parameterPair.Value);
		}
	}
}
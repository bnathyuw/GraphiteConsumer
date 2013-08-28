using System;
using GraphiteConsumer.Graphite;
using GraphiteConsumer.Model;

namespace GraphiteConsumer.App
{
	static class Program
	{
		static void Main(string[] args)
		{
			var graphiteParams = new GraphiteParams(new[] {"summarize(stats_counts.Prod.PaymentsApi.AddCard.Results.*,\"1hour\")"}, "-2d", "-");

			var rawData = GraphiteDataRetriever.GetRawData(graphiteParams);

			var data = Data.FromRawData(rawData);

			Console.Write(data);

			Console.ReadKey();
		}
	}
}

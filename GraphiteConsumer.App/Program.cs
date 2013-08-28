using System;
using System.Threading;
using GraphiteConsumer.Graphite;
using GraphiteConsumer.Model;

namespace GraphiteConsumer.App
{
	static class Program
	{
		static void Main(string[] args)
		{
			Console.SetWindowSize(100, 30);

			var consoleParams = ConsoleParams.From(args);

			var graphiteParams = consoleParams.ToGraphiteParams();

			var rawData = GraphiteDataRetriever.GetRawData(graphiteParams);

			var data = Data.FromRawData(rawData);

			foreach (var metric in data.Metrics)
			{
				Console.Clear();
				Console.Write(metric);
				Thread.Sleep(2000);
			}
		}
	}
}

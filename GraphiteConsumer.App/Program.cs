using System;
using System.Collections.Generic;
using GraphiteConsumer.Graphite;
using GraphiteConsumer.Model;

namespace GraphiteConsumer.App
{
	static class Program
	{
		static void Main(string[] args)
		{
			var consoleParams = ConsoleParams.From(args);
			
			var graphiteParams = consoleParams.ToGraphiteParams();

			var rawData = GraphiteDataRetriever.GetRawData(graphiteParams);

			var data = Data.FromRawData(rawData);

			Console.Write(data);

			Console.ReadKey();
		}
	}

	internal class ConsoleParams
	{
		private List<string> _targets;
		private string _from;
		private string _until;

		public static ConsoleParams From(string[] args)
		{
			var targets = new List<string> ();
			var from = "-48h";
			var until = "-";
			for (var i = 0; i < args.Length; i += 2)
			{
				var flag = args[i];
				var value = args[i + 1];
				switch (flag)
				{
					case "--target":
					case "-t":
						targets.Add(value);
						break;
					case "--from":
					case "-f":
						from = value;
						break;
					case "--until":
					case "-u":
						until = value;
						break;
				}
			}
			return new ConsoleParams {_targets = targets, _from = from, _until = until};
		}

		public GraphiteParams ToGraphiteParams()
		{
			return new GraphiteParams(_targets, _from, _until);
		}
	}
}

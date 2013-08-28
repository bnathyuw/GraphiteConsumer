using System;

namespace GraphiteConsumer.Web.Model
{
	public class Metric
	{
		private Metric() { }
		
		private Metadata _metadata;
		private DataPoints _dataPoints;

		public static Metric FromRawData(string line)
		{
			var sections = line.Split('|');
			var metadata = Metadata.FromRawData(sections[0]);
			var dataPoints = DataPoints.FromRawData(sections[1]);
			return new Metric{_dataPoints = dataPoints, _metadata = metadata};
		}

		public override string ToString()
		{
			return String.Format("{0}\n{1}\n", _metadata, _dataPoints);
		}
	}
}
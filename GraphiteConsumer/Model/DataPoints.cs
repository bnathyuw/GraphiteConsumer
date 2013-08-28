using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphiteConsumer.Extensions;

namespace GraphiteConsumer.Model
{
	public class DataPoints
	{
		private DataPoints() { }

		private IEnumerable<float?> _points;

		public static DataPoints FromRawData(string dataSection)
		{
			var dataPoints = dataSection.Split(',').Select(ConvertString.ToNullableFloat);
			return new DataPoints {_points = dataPoints};
		}

		public override string ToString()
		{
			return string.Format("Sum: {0} Min: {1} Max {2}\n{3}\n", _points.Sum(), _points.Min(), _points.Max(), BuildChart());
		}

		private string BuildChart()
		{
			var sb = new StringBuilder();
			var places = Math.Ceiling(Math.Log10(_points.Max() ?? 0));
			var template = string.Format("{{0, {0}}}  ", places);
			for (var i = Math.Ceiling(_points.Max() ?? 0); i >= 0; i--)
			{
				sb.AppendFormat(template, i);
				foreach (var point in _points)
				{
					sb.Append(point >= i ? "|" : " ");
				}
				sb.AppendLine();
			}
			return sb.ToString();
		}
	}
}
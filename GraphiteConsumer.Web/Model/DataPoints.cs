using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphiteConsumer.Web.Extensions;

namespace GraphiteConsumer.Web.Model
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
			for (var i = _points.Max(); i >= _points.Min(); i--)
			{
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
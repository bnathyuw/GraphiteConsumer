using System;
using GraphiteConsumer.Web.Extensions;

namespace GraphiteConsumer.Web.Model
{
	public class Metadata
	{
		private Metadata() { }

		private string _name;
		private DateTime _start;
		private DateTime _end;
		private int _interval;

		public static Metadata FromRawData(string metadataSection)
		{
			var intervalAfter = metadataSection.LastIndexOf(',');
			var interval = metadataSection.Substring(intervalAfter + 1).ToInt();
			var endAfter = metadataSection.LastIndexOf(',', intervalAfter - 1);
			var end = metadataSection.Substring(endAfter + 1, intervalAfter - endAfter - 1).ToDateTime();
			var startAfter = metadataSection.LastIndexOf(',', endAfter - 1);
			var start = metadataSection.Substring(startAfter + 1, endAfter - startAfter - 1).ToDateTime();
			var name = metadataSection.Substring(0, startAfter);
			return new Metadata {_end = end, _interval = interval, _name = name, _start = start};
		}

		public override string ToString()
		{
			return String.Format("Target: {0}\nStart: {1}\nEnd: {2}\nInterval: {3}", _name, _start, _end, _interval);
		}

	}
}
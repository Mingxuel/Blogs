using System;
using System.Collections.Generic;

namespace MyDream
{
	public class Records
	{
		private Dictionary<string, Record?> _records = new Dictionary<string, Record?>();

		public Record? this[string time]
		{
			get => _records[time];
			set => _records[time] = value;
		}
	}
}

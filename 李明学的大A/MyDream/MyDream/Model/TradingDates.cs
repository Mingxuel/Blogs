using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyDream
{
	public class TradingDates
	{
		private static TradingDates? _instance = null;
		public static TradingDates Instance { get => _instance == null ? _instance = new TradingDates() : _instance; }

		private static string _dates = @"../../../../../Miniqmt/src/Config/交易日";
		private List<string> _tradingDates = new List<string>();

		private TradingDates()
		{
			foreach (var line in File.ReadLines(_dates))
			{
				var date = line.Trim();
				if (!string.IsNullOrEmpty(date)) _tradingDates.Add(date);
			}
		}

		public List<string> GetTradingDates()
		{
			return _tradingDates;
		}

		public string? PreDate(string date, int count = 1)
		{
			int idx = _tradingDates.IndexOf(date);
			if (idx > count - 1)
				return _tradingDates[idx - count];

			return null;
		}

		public string? NextDate(string date, int count = 1)
		{
			int idx = _tradingDates.IndexOf(date);
			if (idx >= 0 && idx + count < _tradingDates.Count)
				return _tradingDates[idx + count];

			return null;
		}
	}
}

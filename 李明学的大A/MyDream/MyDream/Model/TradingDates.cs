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
        public List<string> Dates { get; } = new List<string>();

        private TradingDates()
        {
            foreach (var line in File.ReadLines(_dates))
            {
                var date = line.Trim();
                if (!string.IsNullOrEmpty(date)) Dates.Add(date);
            }
        }

        public string? PreDate(string date, int count = 1)
        {
            int idx = Dates.IndexOf(date);
            if (idx > count - 1)
                return Dates[idx - count];

            return null;
        }

        public string? NextDate(string date, int count = 1)
        {
            int idx = Dates.IndexOf(date);
            if (idx >= 0 && idx + count < Dates.Count)
                return Dates[idx + count];

            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDream
{
	public class Common
	{
		private static Common? _instance = null;
		public static Common? Instance { get =>  _instance == null ? _instance = new Common() : _instance; }
		private Common() { }

		public string? MA5(string stockCode, string date)
		{
			return MA(stockCode, date, 5);	
		}

		public string? MA10(string stockCode, string date)
		{
			return MA(stockCode, date, 10);
		}

		private string? MA(string stockCode, string date, int cycle = 5)
		{
			if (!TradingDates.Instance.Dates.Contains(date)) return null;
			if (!StockCodes.Instance.Codes.Contains(stockCode)) return null;

			Record? record = Records1D.Instance.Records[stockCode]?[date];
			if (record == null) return null;

			int count = 0;
			string? pre_date = null;
			double total_price = double.Parse(record.Close);
			while (count < cycle - 1)
			{
				pre_date = TradingDates.Instance.PreDate(date);
				if (pre_date == null) return null;
				record = Records1D.Instance.Records[stockCode]?[pre_date];
				if (record == null) continue;
				count++;
				total_price += double.Parse(record.Close);
			}
			return ConvertToString(total_price / cycle);
		}

		private string ConvertToString(double price)
		{
			return Math.Round(Math.Round(price, 3), 2).ToString();
		}
	}
}

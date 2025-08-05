using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyDream
{
	public class Records1D
	{
		private static string _config = @"../../../../../Miniqmt/src/Config/Data/1D/";

		private static Records1D? _instance = null;
		public static Records1D Instance { get => _instance == null ? _instance = new Records1D() : _instance; }
		public Dictionary<string, Records?> Records { get; } = new Dictionary<string, Records?>();

		public Records? this[string stock_code]
		{
			get => Records[stock_code];
		}

		private Records1D()
		{
			try
			{
				var stock_codes = StockCodes.Instance.Codes;

				foreach (var stock_code in stock_codes)
				{
					Records[stock_code] = new Records();
					TradingDates.Instance.Dates.ForEach(date => Records[stock_code]![date] = null);
				}

				string[] files = Directory.GetFiles(_config, "*", SearchOption.TopDirectoryOnly);
				Parallel.ForEach(files, file =>
				{
					var lines = File.ReadLines(file).Skip(1);
					foreach (var line in lines)
					{
						var data = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
						var stock_code = Path.GetFileName(file);
						Records[stock_code]![data[0]] = new Record
						{
							Time = data[0],
							Open = double.Parse(data[1]),
							High = double.Parse(data[2]),
							Low = double.Parse(data[3]),
							Close = double.Parse(data[4]),
							Volume = double.Parse(data[5]),
							Amount = double.Parse(data[6]),
							SettelementPrice = double.Parse(data[7]),
							OpenInterest = double.Parse(data[8]),
							PreClose = double.Parse(data[9])
						};
					}
				});
			}
			catch (Exception ex)
			{
				MessageBox.Show($"读取文件失败: {ex.Message}");
			}
		}

		public Record? PreRecord(string stock_code, string date, int count = 1)
		{
			var pre_date = TradingDates.Instance?.PreDate(date, count);
			if (pre_date == null) return null;

			return Records[stock_code]?[pre_date];
		}

		public Record? NextRecord(string stock_code, string date, int count = 1)
		{
			var next_date = TradingDates.Instance?.NextDate(date, count);
			if (next_date == null) return null;

			return Records[stock_code]?[next_date];
		}
	}
}

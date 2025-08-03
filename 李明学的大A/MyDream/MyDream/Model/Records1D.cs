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
		private static string _config = @"../../Miniqmt/src/Config/Data/1D/";

		private static Records1D? _instance = null;
		public static Records1D? Instance { get => _instance == null ? _instance = new Records1D() : _instance; }
		private Dictionary<string, Records?> _records = new Dictionary<string, Records?>();

		public Records? this[string stock_code]
		{
			get => _records[stock_code];
		}

		private Records1D()
		{
			try
			{
				string[] files = Directory.GetFiles(_config, "*", SearchOption.TopDirectoryOnly);

				foreach (string file in files)
				{
					var stock_code = Path.GetFileName(file);
					_records[stock_code] = new Records();
					TradingDates.Instance?.GetTradingDates().ForEach(date => _records[stock_code]![date] = null);
				}

				Parallel.ForEach(files, file =>
				{
					var lines = File.ReadLines(file).Skip(1);
					foreach (var line in lines)
					{
						var data = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
						var stock_code = Path.GetFileName(file);
						_records[stock_code]![data[0]] = new Record
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

			return _records[stock_code]?[pre_date];
		}

		public Record? NextRecord(string stock_code, string date, int count = 1)
		{
			var next_date = TradingDates.Instance?.NextDate(date, count);
			if (next_date == null) return null;

			return _records[stock_code]?[next_date];
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyDream
{
	/// <summary>
	/// Board.xaml 的交互逻辑
	/// </summary>
	public partial class Board : UserControl
	{
		private static string _data_1d_config = @"../../Miniqmt/src/Config/Data/1D/";
		private static string _data_1m_config = @"../../Miniqmt/src/Config/Data/1M/";
		private static string _data_dates = @"../../Miniqmt/src/Config/交易日";
		private Dictionary<string, List<List<Record>>> data_1m = new Dictionary<string, List<List<Record>>>();
		private Dictionary<string, List<Record>> data_1d = new Dictionary<string, List<Record>>();
		private List<string> dates = new List<string>();

		public Board()
		{
			InitializeComponent();

			this.DataContext = new BoardViewModel();

			var dates = TradingDates.Instance?.GetTradingDates();
		}

		public void LoadDates()
		{
			try
			{
				dates.Clear();
				if (File.Exists(_data_dates))
				{
					foreach (var line in File.ReadLines(_data_dates))
					{
						var date = line.Trim();
						if (!string.IsNullOrEmpty(date))
						{
							dates.Add(date);
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"读取交易日失败: {ex.Message}");
			}
		}

		private void Load1D_Click(object sender, RoutedEventArgs e)
		{
			var count = Update.Instance?.UpdateTradingDates();
		}

		private void Load1M_Click(object sender, RoutedEventArgs e)
		{
			LoadDates();
		}

		// 按key列表分段加载1M数据
		public void Load1MByKeys(List<string> keys)
		{
			try
			{
				if (keys == null || keys.Count == 0) return;
				foreach (var key in keys)
				{
					string folderPath = Path.Combine(_data_1m_config, key);
					if (!Directory.Exists(folderPath)) continue;
					var files = Directory.GetFiles(folderPath, "*", SearchOption.TopDirectoryOnly);
					var dayDataList = new List<List<Record>>();

					foreach (var file in files)
					{
						var lines = File.ReadLines(file).Skip(1); // 跳过表头
						var dayData = new List<Record>();
						foreach (var line in lines)
						{
							var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
							if (parts.Length < 11) continue;
							try
							{
								var data = new Record
								{
									Time = parts[0],
									Open = double.Parse(parts[1]),
									High = double.Parse(parts[2]),
									Low = double.Parse(parts[3]),
									Close = double.Parse(parts[4]),
									Volume = double.Parse(parts[5]),
									Amount = double.Parse(parts[6]),
									SettelementPrice = double.Parse(parts[7]),
									OpenInterest = double.Parse(parts[8]),
									PreClose = double.Parse(parts[9]),
									SuspendFlag = double.Parse(parts[10])
								};
								dayData.Add(data);
							}
							catch { }
						}
						dayDataList.Add(dayData);
					}
					lock (data_1m)
					{
						data_1m[key] = dayDataList;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"分段加载1M数据失败: {ex.Message}");
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MyDream.Models;

namespace MyDream
{
	/// <summary>
	/// DataAnalyze.xaml 的交互逻辑
	/// </summary>
	public partial class DataAnalyze : UserControl
	{
		private static string _data_1d_config = @"../../../../../Miniqmt/src/Config/Data/1D/";
		private static string _data_1m_config = @"../../../../../Miniqmt/src/Config/Data/1M/";
		private static string _data_dates = @"../../../../../Miniqmt/src/Config/交易日";
		private Dictionary<string, List<List<Data1D>>> data_1m = new Dictionary<string, List<List<Data1D>>>();
		private Dictionary<string, List<Data1D>> data_1d = new Dictionary<string, List<Data1D>>();
		private List<string> dates = new List<string>();

		public DataAnalyze()
		{
			InitializeComponent();
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
			try
			{
				string[] files = Directory.GetFiles(_data_1d_config, "*", SearchOption.TopDirectoryOnly);
				data_1d.Clear();

				// 临时字典用于分组
				var tempDict = new Dictionary<string, List<Data1D>>();

				Parallel.ForEach(files, file =>
				{
					var lines = File.ReadLines(file).Skip(1); // 跳过表头
					foreach (var line in lines)
					{
						var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
						if (parts.Length < 10) continue;
						try
						{
							var data = new Data1D
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
								PreClose = double.Parse(parts[9])
							};
							lock (tempDict)
							{
								if (!tempDict.ContainsKey(data.Time))
									tempDict[data.Time] = new List<Data1D>();
								tempDict[data.Time].Add(data);
							}
						}
						catch { }
					}
				});

				// 按dates集合存储，保证所有日期都作为key
				foreach (var date in dates)
				{
					if (tempDict.ContainsKey(date))
						data_1d[date] = tempDict[date];
					else
						data_1d[date] = new List<Data1D>(); // 没有数据则空列表
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"读取文件失败: {ex.Message}");
			}
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
					var dayDataList = new List<List<Data1D>>();

					foreach (var file in files)
					{
						var lines = File.ReadLines(file).Skip(1); // 跳过表头
						var dayData = new List<Data1D>();
						foreach (var line in lines)
						{
							var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
							if (parts.Length < 11) continue;
							try
							{
								var data = new Data1D
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

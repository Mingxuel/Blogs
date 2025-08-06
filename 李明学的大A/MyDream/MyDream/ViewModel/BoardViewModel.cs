using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyDream
{
	public partial class BoardViewModel : ObservableObject
	{
		//private static string _data_1d_config = @"../../../../../Miniqmt/src/Config/Data/1D/";
		//private static string _data_1m_config = @"../../../../../Miniqmt/src/Config/Data/1M/";
		//private static string _data_dates = @"../../../../../Miniqmt/src/Config/交易日";
		private Dictionary<string, List<List<Record>>> data_1m = new Dictionary<string, List<List<Record>>>();
		private Dictionary<string, List<Record>> data_1d = new Dictionary<string, List<Record>>();
		private List<string> dates = new List<string>();

		[ObservableProperty]
		public ObservableCollection<Item> b3Data = new ObservableCollection<Item>();

		[ObservableProperty]
		public ObservableCollection<Item> b4Data = new ObservableCollection<Item>();

		[ObservableProperty]
		public ObservableCollection<Item> b5Data = new ObservableCollection<Item>();

		[ObservableProperty]
		public ObservableCollection<Ratio> b4Ratio = new ObservableCollection<Ratio>();

		[ObservableProperty]
		public ObservableCollection<Ratio> b5Ratio = new ObservableCollection<Ratio>();

		[ObservableProperty]
		public ObservableCollection<Ratio> b5Win = new ObservableCollection<Ratio>();

		[ObservableProperty]
		private string? output;

		[RelayCommand]
		private async Task UpdateTradingDatesClick()
		{
			Output = await Update.Instance.UpdateTradingDatesAsync();
		}

		[RelayCommand]
		private async Task UpdateMainStockListClick()
		{
			Output = await Update.Instance.UpdateMainStockListAsync();
		}

		[RelayCommand]
		private async Task DownloadHistory1DClick()
		{
			Output = await Update.Instance.DownloadHistory1DAsync();
		}

		[RelayCommand]
		private async Task UpdateHistory1DClick()
		{
			Output = await Update.Instance.UpdateHistory1DAsync();
		}

		[RelayCommand]
		private void TestClick()
		{
			B3Data.Clear();

			var trading_dates = TradingDates.Instance.Dates;
			var stock_codes = StockCodes.Instance.Codes;
			var records = Records1D.Instance.Records;

			foreach (var date in trading_dates)
			{
				Item item = new Item();
				item.Time = date;
				foreach (var code in stock_codes)
				{
					var record_1 = records[code]?[date];
					if (record_1 == null) continue;
					var pre_date = TradingDates.Instance.PreDate(date);
					if (pre_date == null) continue;
					var record_2 = records[code]?[pre_date];
					if (record_2 == null) continue;
					pre_date = TradingDates.Instance.PreDate(pre_date);
					if (pre_date == null) continue;
					var record_3 = records[code]?[pre_date];
					if (record_3 == null) continue;
					pre_date = TradingDates.Instance.PreDate(pre_date);
					if (pre_date == null) continue;
					var record_4 = records[code]?[pre_date];
					if (record_4 == null) continue;

					if (record_4.Close < record_4.PreClose && record_3.Close > record_3.PreClose &&
						record_2.Close > record_2.PreClose && record_1.Close > record_1.PreClose &&
						!record_3.IsTop && !record_2.IsTop && !record_1.IsTop)
					{
						item.StockCodes.Add(code);
					}
				}
				B3Data.Add(item);
			}

			B4Data.Clear();

			foreach (var date in trading_dates)
			{
				Item item = new Item();
				item.Time = date;
				foreach (var code in stock_codes)
				{
					var record_1 = records[code]?[date];
					if (record_1 == null) continue;
					var pre_date = TradingDates.Instance.PreDate(date);
					if (pre_date == null) continue;
					var record_2 = records[code]?[pre_date];
					if (record_2 == null) continue;
					pre_date = TradingDates.Instance.PreDate(pre_date);
					if (pre_date == null) continue;
					var record_3 = records[code]?[pre_date];
					if (record_3 == null) continue;
					pre_date = TradingDates.Instance.PreDate(pre_date);
					if (pre_date == null) continue;
					var record_4 = records[code]?[pre_date];
					if (record_4 == null) continue;
					pre_date = TradingDates.Instance.PreDate(pre_date);
					if (pre_date == null) continue;
					var record_5 = records[code]?[pre_date];
					if (record_5 == null) continue;

					if (record_5.Close < record_5.PreClose && record_4.Close > record_4.PreClose && record_3.Close > record_3.PreClose &&
						record_2.Close > record_2.PreClose && record_1.Close > record_1.PreClose &&
						!record_4.IsTop && !record_3.IsTop && !record_2.IsTop && !record_1.IsTop)
					{
						item.StockCodes.Add(code);
					}
				}
				B4Data.Add(item);
			}

			B5Data.Clear();

			foreach (var date in trading_dates)
			{
				Item item = new Item();
				item.Time = date;
				foreach (var code in stock_codes)
				{
					var record_1 = records[code]?[date];
					if (record_1 == null) continue;
					var pre_date = TradingDates.Instance.PreDate(date);
					if (pre_date == null) continue;
					var record_2 = records[code]?[pre_date];
					if (record_2 == null) continue;
					pre_date = TradingDates.Instance.PreDate(pre_date);
					if (pre_date == null) continue;
					var record_3 = records[code]?[pre_date];
					if (record_3 == null) continue;
					pre_date = TradingDates.Instance.PreDate(pre_date);
					if (pre_date == null) continue;
					var record_4 = records[code]?[pre_date];
					if (record_4 == null) continue;
					pre_date = TradingDates.Instance.PreDate(pre_date);
					if (pre_date == null) continue;
					var record_5 = records[code]?[pre_date];
					if (record_5 == null) continue;
					pre_date = TradingDates.Instance.PreDate(pre_date);
					if (pre_date == null) continue;
					var record_6 = records[code]?[pre_date];
					if (record_6 == null) continue;

					if (record_6.Close < record_6.PreClose && record_5.Close > record_5.PreClose && record_4.Close > record_4.PreClose &&
						record_3.Close > record_3.PreClose && record_2.Close > record_2.PreClose && record_1.Close > record_1.PreClose &&
						!record_5.IsTop && !record_4.IsTop && !record_3.IsTop && !record_2.IsTop && !record_1.IsTop)
					{
						item.StockCodes.Add(code);
					}
				}
				B5Data.Add(item);
			}

			int count = 0;
			B4Ratio.Clear();
			for (int i = 1; i < B4Data.Count; i++)
			{
				Ratio ratio = new Ratio();
				ratio.Time = B4Data[i].Time;
				if (B3Data[i - 1].StockCodes.Count == 0)
				{
					ratio.Count = 0;
				}
				else
				{
					ratio.Count = (int)(((double)B4Data[i].StockCodes.Count / (double)B3Data[i - 1].StockCodes.Count) * 100.0);
				}
				B4Ratio.Add(ratio);
				if (ratio.Count >= 50) count++;
			}

			count = 0;
			B5Ratio.Clear();
			for (int i = 1; i < B5Data.Count; i++)
			{
				Ratio ratio = new Ratio();
				ratio.Time = B5Data[i].Time;
				if (B3Data[i - 1].StockCodes.Count == 0)
				{
					ratio.Count = 0;
				}
				else
				{
					ratio.Count = (int)(((double)B5Data[i].StockCodes.Count / (double)B4Data[i - 1].StockCodes.Count) * 100.0);
				}
				B5Ratio.Add(ratio);
				if (ratio.Count >= 50) count++;
			}

			double value = (double)count / (double)B5Ratio.Count;
			MessageBox.Show(value.ToString());

			double money = 1000000.0;
			B5Win.Clear();
			foreach (var date in trading_dates)
			{
				Ratio item = new Ratio();
				item.Time = date;
				foreach (var code in stock_codes)
				{
					var next_date = TradingDates.Instance.NextDate(date);
					if (next_date == null) continue;
					var record_0 = records[code]?[next_date];
					if (record_0 == null) continue;
					var record_1 = records[code]?[date];
					if (record_1 == null) continue;
					var pre_date = TradingDates.Instance.PreDate(date);
					if (pre_date == null) continue;
					var record_2 = records[code]?[pre_date];
					if (record_2 == null) continue;
					pre_date = TradingDates.Instance.PreDate(pre_date);
					if (pre_date == null) continue;
					var record_3 = records[code]?[pre_date];
					if (record_3 == null) continue;
					pre_date = TradingDates.Instance.PreDate(pre_date);
					if (pre_date == null) continue;
					var record_4 = records[code]?[pre_date];
					if (record_4 == null) continue;
					pre_date = TradingDates.Instance.PreDate(pre_date);
					if (pre_date == null) continue;
					var record_5 = records[code]?[pre_date];
					if (record_5 == null) continue;

					if (record_5.Close < record_5.PreClose && record_4.Close > record_4.PreClose &&
						record_3.Close > record_3.PreClose && record_2.Close > record_2.PreClose && record_1.Close > record_1.PreClose &&
						!record_5.IsTop && !record_4.IsTop && !record_3.IsTop && !record_2.IsTop && !record_1.IsTop)
					{
						item.Value += ((record_0.Close - record_0.PreClose) / record_0.PreClose) * 100;
						item.Count++;
					}
				}
				if (item.Count > 0)
				{
					item.Value /= item.Count;
				}
				else
				{
					item.Value = 0;
				}
				money = money * (1 + item.Value / 100.0);
				item.Count = (int)item.Value + 10;
				B5Win.Add(item);
			}
			MessageBox.Show(money.ToString("F2"));
		}
	}
}

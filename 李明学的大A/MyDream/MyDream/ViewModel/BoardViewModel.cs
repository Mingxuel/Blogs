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
            InitB3();
            InitB4();
            InitB5();
            InitB4ToB5Ratio();
        }

        private void InitB3()
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
                    var record_2 = Common.PreRecord(code, date, 1);
                    if (record_2 == null) continue;
                    var record_3 = Common.PreRecord(code, date, 2);
                    if (record_3 == null) continue;
                    var record_4 = Common.PreRecord(code, date, 3);
                    if (record_4 == null) continue;
                    if (record_4.IsDown && record_3.IsUp && record_2.IsUp && record_1.IsUp)
                    {
                        item.StockCodes.Add(code);
                    }
                }
                B3Data.Add(item);
            }
        }

        private void InitB4()
        {
            B4Data.Clear();
            B4Ratio.Clear();
            var trading_dates = TradingDates.Instance.Dates;
            var stock_codes = StockCodes.Instance.Codes;
            var records = Records1D.Instance.Records;
            foreach (var date in trading_dates)
            {
                Item item = new Item();
                item.Time = date;
                int win_count = 0;
                int total_count = 0;
                foreach (var code in stock_codes)
                {
                    var record_1 = records[code]?[date];
                    if (record_1 == null) continue;
                    var record_2 = Common.PreRecord(code, date, 1);
                    if (record_2 == null) continue;
                    var record_3 = Common.PreRecord(code, date, 2);
                    if (record_3 == null) continue;
                    var record_4 = Common.PreRecord(code, date, 3);
                    if (record_4 == null) continue;
                    var record_5 = Common.PreRecord(code, date, 4);
                    if (record_5 == null) continue;
                    if (record_5.IsDown && record_4.IsUp && record_3.IsUp && record_2.IsUp && record_1.IsUp)
                    {
                        item.StockCodes.Add(code);
                        total_count++;
                        if (record_1.IsUp) win_count++;
                    }
                }
                B4Data.Add(item);
            }
        }

        private void InitB5()
        {
            B5Data.Clear();
            B5Ratio.Clear();
            B5Win.Clear();
            var trading_dates = TradingDates.Instance.Dates;
            var stock_codes = StockCodes.Instance.Codes;
            var records = Records1D.Instance.Records;
            foreach (var date in trading_dates)
            {
                Item item = new Item();
                item.Time = date;
                int win_count = 0;
                int total_count = 0;
                foreach (var code in stock_codes)
                {
                    var record_1 = records[code]?[date];
                    if (record_1 == null) continue;
                    var record_2 = Common.PreRecord(code, date, 1);
                    if (record_2 == null) continue;
                    var record_3 = Common.PreRecord(code, date, 2);
                    if (record_3 == null) continue;
                    var record_4 = Common.PreRecord(code, date, 3);
                    if (record_4 == null) continue;
                    var record_5 = Common.PreRecord(code, date, 4);
                    if (record_5 == null) continue;
                    var record_6 = Common.PreRecord(code, date, 5);
                    if (record_6 == null) continue;
                    if (record_6.IsDown && record_5.IsUp && record_4.IsUp && record_3.IsUp && record_2.IsUp && record_1.IsUp)
                    {
                        item.StockCodes.Add(code);
                        total_count++;
                        if (record_1.IsUp) win_count++;
                    }
                }
                B5Data.Add(item);
            }
        }

        private void InitB4ToB5Ratio()
        {
            B4Ratio.Clear();
            B5Ratio.Clear();
            B5Win.Clear();
            var trading_dates = TradingDates.Instance.Dates;
            foreach (var date in trading_dates)
            {
                var b4_item = B4Data.FirstOrDefault(i => i.Time == date);
                var b5_item = B5Data.FirstOrDefault(i => i.Time == date);
                if (b4_item == null || b5_item == null) continue;
                int b4_count = b4_item.StockCodes.Count;
                int b5_count = b5_item.StockCodes.Count;
                if (b4_count == 0) continue;
                Ratio ratio = new Ratio
                {
                    Time = date,
                    RatioValue = Math.Round((double)b5_count / b4_count, 2)
                };
                B4Ratio.Add(ratio);
                ratio = new Ratio
                {
                    Time = date,
                    RatioValue = Math.Round((double)b5_count / b4_count, 2)
                };
                B5Ratio.Add(ratio);
                ratio = new Ratio
                {
                    Time = date,
                    RatioValue = Math.Round((double)b5_item.Count / b5_count, 2)
                };
                B5Win.Add(ratio);
            }
        }
    }
}

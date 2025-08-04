using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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
	}
}

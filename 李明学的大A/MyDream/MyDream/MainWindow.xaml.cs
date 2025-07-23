using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyDream
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		private static string _keydays = @"../../../../../Data/Config/KeyDays.config";
		private List<string> _dates = new List<string>();

		public MainWindow()
        {
            InitializeComponent();
        }

		private void bt_0_0_Click(object sender, RoutedEventArgs e)
		{
			//2F
			string keyword = "主板非st，\r\nD-0非涨停，\r\nD-1放量涨停，\r\nD-2涨停，\r\nD-3未涨停";
			tb_0_0.Text = Format(keyword, lb_0_0.SelectedIndex);
			Clipboard.SetText(tb_0_0.Text);
		}

		private void bt_0_1_Click(object sender, RoutedEventArgs e)
		{
			//2F GO
			string keyword = "主板非st，\r\nD-0放量涨停，\r\nD-1涨停，\r\nD-2未涨停";
			tb_0_1.Text = Format(keyword, lb_0_1.SelectedIndex);
			Clipboard.SetText(tb_0_1.Text);
		}

		private void bt_0_2_Click(object sender, RoutedEventArgs e)
		{
			//2F GO
			string keyword = "主板非st，\r\nD-0放量涨停，\r\nD-1涨停，\r\nD-2未涨停";
			tb_0_2.Text = Format(keyword, lb_0_2.SelectedIndex);
			Clipboard.SetText(tb_0_2.Text);
		}

		private void bt_1_0_Click(object sender, RoutedEventArgs e)
		{
			//2S
			string keyword = "主板非st，\r\nD-0非涨停，\r\nD-1缩量涨停，\r\nD-2涨停，\r\nD-3未涨停";
			tb_1_0.Text = Format(keyword, lb_1_0.SelectedIndex);
			Clipboard.SetText(tb_1_0.Text);
		}

		private void bt_1_1_Click(object sender, RoutedEventArgs e)
		{
			//2S GO
			string keyword = "主板非st，\r\nD-0缩量涨停，\r\nD-1涨停，\r\nD-2未涨停";
			tb_1_1.Text = Format(keyword, lb_1_1.SelectedIndex);
			Clipboard.SetText(tb_1_1.Text);
		}

		private void bt_1_2_Click(object sender, RoutedEventArgs e)
		{
			//2S GO
			string keyword = "主板非st，\r\nD-0缩量涨停，\r\nD-1涨停，\r\nD-2未涨停";
			tb_1_2.Text = Format(keyword, lb_1_2.SelectedIndex);
			Clipboard.SetText(tb_1_2.Text);
		}

		private string Format(string keyword, int index)
		{
			keyword = keyword.Replace("D-0", _dates[index++]);
			keyword = keyword.Replace("D-1", _dates[index++]);
			keyword = keyword.Replace("D-2", _dates[index++]);
			keyword = keyword.Replace("D-3", _dates[index++]);
			keyword = keyword.Replace("D-4", _dates[index++]);
			keyword = keyword.Replace("D-5", _dates[index++]);
			keyword = keyword.Replace("D-6", _dates[index++]);
			keyword = keyword.Replace("D-7", _dates[index++]);
			keyword = keyword.Replace("D-8", _dates[index++]);
			keyword = keyword.Replace("D-9", _dates[index++]);

			return keyword;
		}

		private void LoadClick(object sender, RoutedEventArgs e)
		{
			File.WriteAllText(_keydays, tb_days.Text);
			UpdateData();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			UpdateData();
		}

		private void UpdateData()
		{
			tb_days.Text = File.ReadAllText(_keydays);
			lb_0_0.Items.Clear();
			lb_0_1.Items.Clear();
			lb_0_2.Items.Clear();
			lb_1_0.Items.Clear();
			lb_1_1.Items.Clear();
			lb_1_2.Items.Clear();
			_dates.Clear();
			string[] dates = File.ReadAllText(_keydays).Split("\r\n");
			foreach (string date in dates)
			{
				_dates.Add(date.Trim());
				lb_0_0.Items.Add(date.Trim());
				lb_0_1.Items.Add(date.Trim());
				lb_0_2.Items.Add(date.Trim());
				lb_1_0.Items.Add(date.Trim());
				lb_1_1.Items.Add(date.Trim());
				lb_1_2.Items.Add(date.Trim());
			}
		}
	}
}
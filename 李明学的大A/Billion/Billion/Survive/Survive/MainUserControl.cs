using Peace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Survive
{
	public partial class MainUserControl : UserControl
	{
		private CAllManager _all_manager = new CAllManager();
		private CTicketManager _ticket_manager = new CTicketManager();

		private CWinner _winner = new CWinner();
		private Dictionary<int, List<double>> Winner = new Dictionary<int, List<double>>();

		private int _default_days_count = 60;

		//配置文件相关参数集合
		private int ConditionDays
		{
			get
			{
				if (rbtn_day3.Checked) return 3;
				if (rbtn_day4.Checked) return 4;
				if (rbtn_day5.Checked) return 5;
				if (rbtn_day6.Checked) return 6;

				return 3;
			}
			set
			{
				if (value == 3) rbtn_day3.Checked = true;
				if (value == 4) rbtn_day4.Checked = true;
				if (value == 5) rbtn_day5.Checked = true;
				if (value == 6) rbtn_day6.Checked = true;
			}
		}

		private Dictionary<int, ConfigInputUserControl> ConditionsRate = new Dictionary<int, ConfigInputUserControl>();
		private Dictionary<int, SolutionUserControl> Solutions = new Dictionary<int, SolutionUserControl>();
		private Dictionary<int, ConfigInputUserControl> ConditionsTrade = new Dictionary<int, ConfigInputUserControl>();

		public MainUserControl()
		{
			InitializeComponent();
		}

		private void MainUserControl_Load(object sender, EventArgs e)
		{
			DateTime first_day = DateTime.Now;
			tb_last_day.Text = first_day.ToString("yyyy-MM-dd");
			DateTime last_day = first_day.AddDays(-_default_days_count);
			tb_first_day.Text = last_day.ToString("yyyy-MM-dd");

			ConditionsRate[0] = ciuc_rate_day_0;
			ConditionsRate[1] = ciuc_rate_day_1;
			ConditionsRate[2] = ciuc_rate_day_2;
			ConditionsRate[3] = ciuc_rate_day_3;
			ConditionsRate[4] = ciuc_rate_day_4;
			ConditionsRate[5] = ciuc_rate_day_5;
			ConditionsRate[6] = ciuc_rate_day_6;

			for (int i = 0; i <= 20; i++)
			{
				SolutionUserControl uc = (SolutionUserControl)this.Controls.Find(string.Format("soluc_{0}", i), true)[0];
				Solutions[i] = uc;
				Solutions[i].EditMode = true;
				Solutions[i].SaveClick = SaveSolution;
				Solutions[i].LoadClick = LoadSolution;
				Solutions[i].LoadInformation();
			}
			soluc_0.EditMode = false;

			ConditionsTrade[0] = ciuc_trade_buy_0;
			ConditionsTrade[1] = ciuc_trade_buy_1;
			ConditionsTrade[2] = ciuc_trade_buy_2;
			ConditionsTrade[3] = ciuc_trade_buy_3;
			ConditionsTrade[4] = ciuc_trade_buy_4;
			ConditionsTrade[5] = ciuc_trade_buy_5;
			ConditionsTrade[6] = ciuc_trade_buy_6;

			LoadSolution(1);
			UpdateDaysControls();
		}

		private void bt_analyze_Click(object sender, EventArgs e)
		{
			Filter();
		}

		private void RenameAll()
		{
			string all = @"../../../../../Data/All/";
			string[] all_files = Directory.GetFiles(all, "*.xlsx");
			Array.Sort(all_files);
			foreach (string file in all_files)
			{
				if (file.Contains("开盘价"))
				{

					string new_file = string.Format(@"{0}{1}.xlsx", all, Path.GetFileNameWithoutExtension(file).Substring(0, 10).Replace(".", "-"));
					File.Move(file, new_file);
				}
			}
		}

		private void ClearRandom()
		{
			for (int i = 1; i <= 4; i++)
			{
				Label label_id = (Label)this.Controls.Find(string.Format("lb_target_id_{0}", i), true)[0];
				label_id.Text = "";
				Label label_name = (Label)this.Controls.Find(string.Format("lb_target_name_{0}", i), true)[0];
				label_name.Text = "";
			}
		}

		private void UpdateRandom()
		{
			int count = _all_manager.Filter_Details.Count;
			int space = 4;

			if (count == 0) return;

			if (space > count) space = count;

			lb_today_count.Text = count.ToString();
			lb_today_space.Text = space.ToString();

			Dictionary<int, int> random_box = new Dictionary<int, int>();
			while (random_box.Count != space)
			{
				Random random = new Random();
				int random_index = random.Next(0, count);
				if (!random_box.ContainsKey(random_index))
				{
					random_box[random_index] = random_index;
				}
			}

			for (int i = 1; i <= space; i++)
			{
				int random_index = random_box.ElementAt(i - 1).Key;
				Label label_id = (Label)this.Controls.Find(string.Format("lb_target_id_{0}", i), true)[0];
				label_id.Text = _all_manager.Filter_Details.ElementAt(random_index).ID;
				Label label_name = (Label)this.Controls.Find(string.Format("lb_target_name_{0}", i), true)[0];
				label_name.Text = _all_manager.Filter_Details.ElementAt(random_index).Name;
			}
		}

		//清除所有数据
		private void ClearFilter()
		{
			_all_manager.Clear();
			_winner.Clear();
			Winner.Clear();
			lv_analyze_details.Items.Clear();
			lv_filter_result.Items.Clear();
			ClearRandom();
		}

		//读取所有数据, 并将数据格式化成更易读的数据
		private void InitAllManager()
		{
			string download = @"C:\Users\Administrator\Downloads\";
			string all = @"../../../../../Data/All/";

			DateTime first_day = DateTime.Parse(tb_first_day.Text);
			DateTime last_day = DateTime.Parse(tb_last_day.Text);

			#region 当最后一天为今天时, 表示是战斗模式, 需要将Downloads文件夹的实时数据更新到All文件夹当中
			DateTime today = DateTime.Now.Date;
			if (today == last_day)
			{
				string temp = today.ToString("yyyy.MM.dd");
				if (ContainsFile(download, ref temp))
				{
					string delete_excel = string.Format(@"{0}{1}.xlsx", all, today.ToString("yyyy-MM-dd"));
					File.Delete(delete_excel);
					string delete_json = string.Format(@"{0}{1}.json", all, today.ToString("yyyy-MM-dd"));
					File.Delete(delete_json);
					string new_file = string.Format(@"{0}{1}.xlsx", all, today.ToString("yyyy-MM-dd"));
					File.Move(temp, new_file);
				}
			}
			#endregion

			List<string> filtered_files = new List<string>();
			string[] all_files = Directory.GetFiles(all, "*.xlsx");
			Array.Sort(all_files);

			foreach (string file in all_files)
			{
				DateTime date = DateTime.Parse(Path.GetFileNameWithoutExtension(file));
				if (date < first_day) continue;
				if (date > last_day) break;
				filtered_files.Add(file);
			}

			foreach (string file in filtered_files)
			{
				DateTime date = DateTime.Parse(Path.GetFileNameWithoutExtension(file));
				if (!_all_manager.Data.ContainsKey(date))
				{
					CTicketManager ticket_manager = new CTicketManager();
					ticket_manager.LoadExcel(EExcelType.All, Path.GetFileNameWithoutExtension(file));
					_all_manager.Data[date] = ticket_manager;
				}
			}

			_all_manager.Organize();
		}

		private bool ContainsFile(string directory, ref string file)
		{
			string[] files = Directory.GetFiles(directory);
			foreach (string item in files)
			{
				if (item.Contains(file))
				{
					file = item;
					return true;
				}
			}

			return false;
		}

		private void Filter()
		{
			ClearFilter();
			InitAllManager();
			FilterDetail(true);
			FilterDetail(false);
			InitFilterControls();
			UpdateRandom();
		}

		private void FilterDetail(bool istest)
		{
			bool[] plates = new bool[6]{ cb_plate_shanghai.Checked,
										cb_plate_shenzhen.Checked ,
										cb_plate_kechuang.Checked,
										cb_plate_chuangye.Checked,
										cb_plate_beijing.Checked,
										cb_plate_st.Checked};

			for (int i = 0; i < _all_manager.Count; i++)
			{
				string id = _all_manager.Organized_Data.ElementAt(i).Key;
				int type = int.Parse(id) / 10000;

				if (!plates[2] && type == 68) continue;
				if (!plates[3] && (type == 30 || type == 92)) continue;
				if (!plates[4] && (type == 83 || type == 87)) continue;
				if (!plates[5] && type == 43) continue;

				if (!plates[5])
				{
					string name = (string)_all_manager.Organized_Data[id].Last().Value[ETicketObjectID.Name].Item;
					if (name.Contains("st") || name.Contains("ST")) continue;
				}

				for (int day = 1; day <= _all_manager.Days; day++)
				{
					if (istest)
					{
						//判断是否超出测试天数, 比如所有天数是10, 条件天数是4, 那么第6天开始是不符合条件的
						if (day > _all_manager.Days - ConditionDays) break;
					}
					else
					{
						day = _all_manager.Days - ConditionDays + 1;
					}

					//如果存在空白天, 说明停牌之类的, 也不计算在内
					bool is_empty = false;
					int last_day = day + ConditionDays;
					if (istest)
					{
						last_day += 1;
					}
					for (int j = day; j < last_day; j++)
					{
						if (_all_manager.Organized_Data[id][j].IsEmpty())
						{
							is_empty = true;
							break;
						}
					}
					if (is_empty)
					{
						if (istest) day = _all_manager.Days;
						break;
					}

					//开始正式计算, 并将结果存储到winner中
					if (Calculate(id, day))
					{
						if (istest)
						{
							int check_day = day + ConditionDays;
							double result = 0.0;
							if (_all_manager.Organized_Data[id].ContainsKey(check_day))
							{
								//到这里, 就表示前期条件均满足, 返回测试天的股价
								result = double.Parse((string)_all_manager.Organized_Data[id][check_day][ETicketObjectID.Rate].Item);
								_winner.Add(result);
								_all_manager.AddWinnerDetail(id, day, ConditionDays);
							}

							if (!Winner.ContainsKey(day))
							{
								Winner[day] = new List<double>();
							}
							Winner[day].Add(result);
						}
						else
						{
							_all_manager.AddFilterDetail(id, day, ConditionDays);
						}
					}

					if (!istest) break;
				}
			}
		}

		//计算公式
		private bool Calculate(string id, int start_day)
		{
			//将要使用的数据存储到tickets
			List<CTicket> tickets = new List<CTicket>();
			for (int j = 0; j < ConditionDays; j++)
			{
				tickets.Add(_all_manager.Organized_Data[id][start_day + j]);
			}

			#region 净额计算
			if (!CalculateStatus(tickets, ETicketObjectID.MainForce)) return false;
			#endregion

			#region 涨跌幅计算
			if (!CalculateValue(tickets, ETicketObjectID.Rate)) return false;
			#endregion

			#region 主力买入计算
			//if (!CalculateValue(tickets, ETicketObjectID.MainBuy)) return false;
			#endregion
/*
			#region Market Value carlulate
			double market_value = double.Parse((string)tickets.Last()[ETicketObjectID.MarketValue].Item);
			if (market_value < double.Parse(ciuc_market_value.Value1) * 100000000 || market_value > double.Parse(ciuc_market_value.Value2) * 100000000) return false;
			#endregion
*/
			#region 公式计算
			CFunctions functions = new CFunctions();
			functions.Compile(tb_functions.Text.Replace("\r\n", "#"));
			List<double> day_values = new List<double>();
			double total_ticket_value = 0.0;
			List<double> ticket_values = new List<double>();
			foreach (var ticket in tickets)
			{
				double value = double.Parse(ticket[ETicketObjectID.Rate].Item.ToString());
				total_ticket_value += value;
				ticket_values.Add(value);
			}
			day_values.Add(total_ticket_value);
			day_values.AddRange(ticket_values);
			if (!functions.Run(day_values)) return false;
			#endregion

			#region 均价计算
			if (!rbtn_average_value_none.Checked)
			{
				double total_value = 0.0;
				foreach (CTicket ticket in tickets)
				{
					total_value += double.Parse((string)ticket[ETicketObjectID.ValueEnd].Item);
				}

				double last_value = double.Parse(tickets.Last().GetValue(ETicketObjectID.ValueEnd));
				double average_value = total_value / ConditionDays;
				if (rbtn_average_value_high.Checked && last_value < average_value) return false;
				if (rbtn_average_value_low.Checked && last_value > average_value) return false;
			}
			#endregion
/*
			#region 涨跌停状态
			if (!rbtn_top_status_none.Checked)
			{
				int high_count = 0;
				int low_count = 0;
				foreach (CTicket ticket in tickets)
				{
					double rate = double.Parse((string)ticket[ETicketObjectID.Rate].Item);
					if (rate > 9.9)
					{
						high_count++;
					}
					else if (rate < -9.9)
					{
						low_count++;
					}
				}
				if (rbtn_top_status_high.Checked)
				{
					if (high_count != 1 || low_count != 0) return false;
				}
				if (rbtn_top_status_low.Checked)
				{
					if (high_count != 0 || low_count != 1) return false;
				}
			}
			#endregion
*/
			return true;
		}

		private bool CalculateValue(List<CTicket> tickets, ETicketObjectID id)
		{
			Dictionary<int, ConfigInputUserControl> conditions = [];

			List<double> ratio = new List<double>();

			switch (id)
			{
				case ETicketObjectID.Rate:
					conditions = ConditionsRate;
					foreach (CTicket ticket in tickets)
					{
						double value = 1.0;
						ratio.Add(value);
					}
					break;
				case ETicketObjectID.MainForce:
					break;
				case ETicketObjectID.MainBuy:
					conditions = ConditionsTrade;
					foreach (CTicket ticket in tickets)
					{
						double value = double.Parse((string)ticket[ETicketObjectID.ValueEnd].Item)/1000000;
						ratio.Add(value);
					}
					break;
			}

			List<double> values = new List<double>();
			double total_value = 0.0;
			int index = 0;
			foreach (CTicket ticket in tickets)
			{
				double value = double.Parse((string)ticket[id].Item) * ratio.ElementAt(index);
				values.Add(value);
				total_value += value;
				index++;
			}

			double total_low = double.Parse(conditions[0].Value1);
			double total_high = double.Parse(conditions[0].Value2);
			if (total_low > total_value || total_high < total_value) return false;

			for (int i = 1; i <= ConditionDays; i++)
			{
				double low_value = double.Parse(conditions[i].Value1) * ratio.ElementAt(i-1);
				double high_value = double.Parse(conditions[i].Value2) * ratio.ElementAt(i-1);

				if (low_value > values[i - 1] || high_value < values[i - 1]) return false;
			}

			return true;
		}

		private bool CalculateStatus(List<CTicket> tickets, ETicketObjectID id)
		{
			Dictionary<int, ConfigInputUserControl> conditions = [];
			switch (id)
			{
				case ETicketObjectID.MainForce:
					conditions = ConditionsRate;
					break;
				case ETicketObjectID.MainBuy:
					conditions = ConditionsTrade;
					break;
			}

			List<double> values = new List<double>();
			double total_value = 0.0;
			foreach (CTicket ticket in tickets)
			{
				double value = double.Parse((string)ticket[id].Item);
				values.Add(value);
				total_value += value;
			}

			ERateStatus rate_status = (ERateStatus)conditions[0].RateStatus;
			if (rate_status == ERateStatus.Up && total_value < 0.0) return false;
			if (rate_status == ERateStatus.Down && total_value > 0.0) return false;

			for (int i = 1; i <= ConditionDays; i++)
			{
				rate_status = (ERateStatus)conditions[i].RateStatus;
				if (rate_status == ERateStatus.Up && values[i - 1] < 0.0) return false;
				if (rate_status == ERateStatus.Down && values[i - 1] > 0.0) return false;
			}

			return true;
		}

		//将结果输出到控件
		private void InitFilterControls()
		{
			int total_count = 0;
			for (int index = 1; index <= 20; index++)
			{
				if (_winner.Winners.ContainsKey(index))
				{
					total_count += _winner.Winners[index].Count;
				}
			}

			//显示胜率列表
			uc_ratio.Clear();
			uc_ratio.SetTitle("范 围", "数量", "分 布");
			for (int index = 1; index <= 20; index++)
			{
				string range = "";
				if (index <= 10)
				{
					range = string.Format("[+{0:D2}%] - [+{1:D2}%]", 10 - index, 11 - index);
				}
				else
				{
					range = string.Format("[-{0:D2}%] - [-{1:D2}%]", Math.Abs(10 - index), Math.Abs(11 - index));
				}
				string count = "0";
				string ratio = "0";
				if (_winner.Winners.ContainsKey(index))
				{
					count = _winner.Winners[index].Count.ToString();
					ratio = ((int)(((double)_winner.Winners[index].Count / (double)total_count) * 100)).ToString();
				}
				uc_ratio.Add(range, count, ratio);
			}

			//计算随机
			Solutions[0].Data = Winner;
			Solutions[0].LastDay = _all_manager.Days - ConditionDays;
			Solutions[0].UpdateData();

			foreach (CWinnerDetailsItem item in _all_manager.Winner_Details)
			{
				string[] values = new string[11];
				values[0] = item.ID;
				values[1] = item.Name;
				values[2] = item.Start_Day;
				values[3] = item.Check_Day;
				if (ConditionDays == 3)
				{
					values[4] = item.Day1;
					values[5] = item.Day2;
					values[6] = item.Day3;
					values[7] = item.Day4;
				}
				else if (ConditionDays == 4)
				{
					values[4] = item.Day1;
					values[5] = item.Day2;
					values[6] = item.Day3;
					values[7] = item.Day4;
					values[8] = item.Day5;
				}
				else if (ConditionDays == 5)
				{
					values[4] = item.Day1;
					values[5] = item.Day2;
					values[6] = item.Day3;
					values[7] = item.Day4;
					values[8] = item.Day5;
					values[9] = item.Day6;
				}
				else if (ConditionDays == 6)
				{
					values[4] = item.Day1;
					values[5] = item.Day2;
					values[6] = item.Day3;
					values[7] = item.Day4;
					values[8] = item.Day5;
					values[9] = item.Day6;
					values[10] = item.Day7;
				}
				ListViewItem lv_item = new ListViewItem(values);
				lv_analyze_details.Items.Add(lv_item);
			}

			foreach (CWinnerDetailsItem item in _all_manager.Filter_Details)
			{
				string[] values = new string[10];
				values[0] = item.ID;
				values[1] = item.Name;
				if (ConditionDays == 3)
				{
					values[2] = item.Day1;
					values[3] = item.Day2;
					values[4] = item.Day3;
					values[5] = item.Day4;
				}
				else if (ConditionDays == 4)
				{
					values[2] = item.Day1;
					values[3] = item.Day2;
					values[4] = item.Day3;
					values[5] = item.Day4;
					values[6] = item.Day5;
				}
				else if (ConditionDays == 5)
				{
					values[2] = item.Day1;
					values[3] = item.Day2;
					values[4] = item.Day3;
					values[5] = item.Day4;
					values[6] = item.Day5;
					values[7] = item.Day6;
				}
				else if (ConditionDays == 6)
				{
					values[2] = item.Day1;
					values[3] = item.Day2;
					values[4] = item.Day3;
					values[5] = item.Day4;
					values[6] = item.Day5;
					values[7] = item.Day6;
					values[8] = item.Day7;
				}
				ListViewItem lv_item = new ListViewItem(values);
				lv_filter_result.Items.Add(lv_item);
			}
		}

		private void LoadSolution(object sender, EventArgs e)
		{
			int solution_id = (int)sender;
			LoadSolution(solution_id);
		}

		//配置文件载入后初始化
		private void LoadSolution(int solution_id)
		{
			if (!CConfig.StrategyExists(solution_id)) return;

			ConditionDays = int.Parse(CConfig.LoadStrategy(solution_id, "ConditionDays"));

			cb_plate_shanghai.Checked = bool.Parse(CConfig.LoadStrategy(solution_id, "plate_shanghai"));
			cb_plate_shenzhen.Checked = bool.Parse(CConfig.LoadStrategy(solution_id, "plate_shenzhen"));
			cb_plate_kechuang.Checked = bool.Parse(CConfig.LoadStrategy(solution_id, "plate_kechuang"));
			cb_plate_chuangye.Checked = bool.Parse(CConfig.LoadStrategy(solution_id, "plate_chuangye"));
			cb_plate_beijing.Checked = bool.Parse(CConfig.LoadStrategy(solution_id, "plate_beijing"));
			cb_plate_st.Checked = bool.Parse(CConfig.LoadStrategy(solution_id, "plate_st"));

			for (int i = 0; i < ConditionsRate.Count; i++)
			{
				ConditionsRate[i].Value1 = CConfig.LoadStrategy(solution_id, string.Format("{0}_day_low", i));
				ConditionsRate[i].Value2 = CConfig.LoadStrategy(solution_id, string.Format("{0}_day_high", i));
				ConditionsRate[i].RateStatus = int.Parse(CConfig.LoadStrategy(solution_id, string.Format("{0}_day_rate_status", i)));
			}

			for (int i = 0; i < ConditionsTrade.Count; i++)
			{
				ConditionsTrade[i].Value1 = CConfig.LoadStrategy(solution_id, string.Format("{0}_trade_buy_low", i));
				ConditionsTrade[i].Value2 = CConfig.LoadStrategy(solution_id, string.Format("{0}_trade_buy_high", i));
				int status = 0;
				if (int.TryParse(CConfig.LoadStrategy(solution_id, string.Format("{0}_trade_buy_status", i)), out status))
				{
					ConditionsTrade[i].RateStatus = status;
				}
			}

			tb_functions.Text = CConfig.LoadStrategy(solution_id, "function").Replace("#", "\r\n");

			int average_value_status = 0;
			if (!int.TryParse(CConfig.LoadStrategy(solution_id, "average_value_status"), out average_value_status))
			{
				average_value_status = 0;
			}
			if (average_value_status == 0) rbtn_average_value_none.Checked = true;
			if (average_value_status == 1) rbtn_average_value_high.Checked = true;
			if (average_value_status == 2) rbtn_average_value_low.Checked = true;

			ciuc_market_value.Value1 = CConfig.LoadStrategy(solution_id, "market_value_low");
			ciuc_market_value.Value2 = CConfig.LoadStrategy(solution_id, "market_value_high");


			int top_status = 0;
			if (!int.TryParse(CConfig.LoadStrategy(solution_id, "top_status"), out top_status))
			{
				top_status = 0;
			}
			if (top_status == 0) rbtn_top_status_none.Checked = true;
			if (top_status == 1) rbtn_top_status_high.Checked = true;
			if (top_status == 2) rbtn_top_status_low.Checked = true;
		}

		private void SaveSolution(object sender, EventArgs e)
		{
			Filter();

			int solution_id = (int)sender;
			Solutions[solution_id].Data = Winner;
			Solutions[solution_id].LastDay = _all_manager.Days - ConditionDays;

			SaveSolution(solution_id);
		}

		//配置文件保存
		private void SaveSolution(int solution_id)
		{
			CConfig.SaveStrategy(solution_id, "ConditionDays", ConditionDays.ToString());

			CConfig.SaveStrategy(solution_id, "plate_shanghai", cb_plate_shanghai.Checked.ToString());
			CConfig.SaveStrategy(solution_id, "plate_shenzhen", cb_plate_shenzhen.Checked.ToString());
			CConfig.SaveStrategy(solution_id, "plate_kechuang", cb_plate_kechuang.Checked.ToString());
			CConfig.SaveStrategy(solution_id, "plate_chuangye", cb_plate_chuangye.Checked.ToString());
			CConfig.SaveStrategy(solution_id, "plate_beijing", cb_plate_beijing.Checked.ToString());
			CConfig.SaveStrategy(solution_id, "plate_st", cb_plate_st.Checked.ToString());

			for (int i = 0; i < ConditionsRate.Count; i++)
			{
				CConfig.SaveStrategy(solution_id, string.Format("{0}_day_low", i), ConditionsRate[i].Value1);
				CConfig.SaveStrategy(solution_id, string.Format("{0}_day_high", i), ConditionsRate[i].Value2);
				CConfig.SaveStrategy(solution_id, string.Format("{0}_day_rate_status", i), ConditionsRate[i].RateStatus.ToString());
			}

			for (int i = 0; i < ConditionsTrade.Count; i++)
			{
				CConfig.SaveStrategy(solution_id, string.Format("{0}_trade_buy_low", i), ConditionsTrade[i].Value1);
				CConfig.SaveStrategy(solution_id, string.Format("{0}_trade_buy_high", i), ConditionsTrade[i].Value2);
				CConfig.SaveStrategy(solution_id, string.Format("{0}_trade_buy_status", i), ConditionsTrade[i].RateStatus.ToString());
			}

			CConfig.SaveStrategy(solution_id, "function", tb_functions.Text.Replace("\r\n", "#"));

			int average_value_status = 0;
			if (rbtn_average_value_none.Checked)
			{
				average_value_status = 0;
			}
			else if (rbtn_average_value_high.Checked)
			{
				average_value_status = 1;
			}
			else if (rbtn_average_value_low.Checked)
			{
				average_value_status = 2;
			}
			CConfig.SaveStrategy(solution_id, "average_value_status", average_value_status.ToString());

			CConfig.SaveStrategy(solution_id, "market_value_low", ciuc_market_value.Value1);
			CConfig.SaveStrategy(solution_id, "market_value_high", ciuc_market_value.Value2);

			int top_status = 0;
			if (rbtn_top_status_none.Checked)
			{
				top_status = 0;
			}
			else if (rbtn_top_status_high.Checked)
			{
				top_status = 1;
			}
			else if (rbtn_top_status_low.Checked)
			{
				top_status = 2;
			}
			CConfig.SaveStrategy(solution_id, "top_status", top_status.ToString());
		}

		private void Days_Changed(object sender, EventArgs e)
		{
			UpdateDaysControls();
		}

		private void SolutionQuickLoad(object sender, EventArgs e)
		{
			int solution_id = int.Parse(string.Format("{0}", ((Button)sender).Name.Last()));
			LoadSolution(solution_id);
		}
	}
}

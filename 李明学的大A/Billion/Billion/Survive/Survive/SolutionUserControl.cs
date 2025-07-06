using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Survive
{
	public partial class SolutionUserControl : UserControl
	{
		public SolutionUserControl()
		{
			InitializeComponent();
		}

		EventHandler? _save;
		public EventHandler? SaveClick
		{
			set
			{
				_save += value;
			}
		}

		EventHandler? _load;
		public EventHandler? LoadClick
		{
			set
			{
				_load += value;
			}
		}

		public int ID { get; set; }

		public int LastDay { get; set; }

		private bool _editMode = false;
		public bool EditMode
		{
			get
			{
				return _editMode;
			}
			set
			{
				lb_title_name.Visible = value;
				lb_title_last_update.Visible = value;
				tb_name.Visible = value;
				lb_last_update.Visible = value;
				btn_load.Visible = value;
				btn_save.Visible = value;
				_editMode = value;
			}
		}

		public Dictionary<int, List<double>> Data { get; set; }

		private void btn_load_Click(object sender, EventArgs e)
		{
			if (_load != null) _load(ID, e);

			LoadInformation();
		}

		public void LoadInformation()
		{
			tb_name.Text = CConfig.LoadSolution(ID, "Name");
			lb_last_update.Text = CConfig.LoadSolution(ID, "LastUpdate");

			lb_total_5.Text = CConfig.LoadSolution(ID, "Total_5");
			lb_total_10.Text = CConfig.LoadSolution(ID, "Total_10");
			lb_total_15.Text = CConfig.LoadSolution(ID, "Total_15");
			lb_total_20.Text = CConfig.LoadSolution(ID, "Total_20");

			lb_ratio_5.Text = CConfig.LoadSolution(ID, "Ratio_5");
			lb_ratio_10.Text = CConfig.LoadSolution(ID, "Ratio_10");
			lb_ratio_15.Text = CConfig.LoadSolution(ID, "Ratio_15");
			lb_ratio_20.Text = CConfig.LoadSolution(ID, "Ratio_20");

			lb_win_5.Text = CConfig.LoadSolution(ID, "Win_5");
			lb_win_10.Text = CConfig.LoadSolution(ID, "Win_10");
			lb_win_15.Text = CConfig.LoadSolution(ID, "Win_15");
			lb_win_20.Text = CConfig.LoadSolution(ID, "Win_20");

			lb_win_2p_5.Text = CConfig.LoadSolution(ID, "Win_2p_5");
			 lb_win_2p_10.Text = CConfig.LoadSolution(ID, "Win_2p_10");
			lb_win_2p_15.Text = CConfig.LoadSolution(ID, "Win_2p_15");
			lb_win_2p_20.Text = CConfig.LoadSolution(ID, "Win_2p_20");

			lb_win_4p_5.Text = CConfig.LoadSolution(ID, "Win_4p_5");
			lb_win_4p_10.Text = CConfig.LoadSolution(ID, "Win_4p_10");
			lb_win_4p_15.Text = CConfig.LoadSolution(ID, "Win_4p_15");
			lb_win_4p_20.Text = CConfig.LoadSolution(ID, "Win_4p_20");

			for (int i = 1; i <= 10; i++)
			{
				Label lable_count = (Label)(this.Controls.Find(string.Format("lb_day_count_{0}", i), true)[0]);
				lable_count.Text = CConfig.LoadSolution(ID, string.Format("lb_day_count_{0}", i));
				Label lable_ratio = (Label)(this.Controls.Find(string.Format("lb_day_ratio_{0}", i), true)[0]);
				lable_ratio.Text = CConfig.LoadSolution(ID, string.Format("lb_day_ratio_{0}", i));
			}
		}

		private void btn_save_Click(object sender, EventArgs e)
		{
			if (_save != null) _save(ID, e);

			UpdateData();

			CConfig.SaveSolution(ID, "Name", tb_name.Text);
			CConfig.SaveSolution(ID, "LastUpdate", DateTime.Now.ToString("yy-MM-dd"));

			CConfig.SaveSolution(ID, "Total_5", lb_total_5.Text);
			CConfig.SaveSolution(ID, "Total_10", lb_total_10.Text);
			CConfig.SaveSolution(ID, "Total_15", lb_total_15.Text);
			CConfig.SaveSolution(ID, "Total_20", lb_total_20.Text);

			CConfig.SaveSolution(ID, "Ratio_5", lb_ratio_5.Text);
			CConfig.SaveSolution(ID, "Ratio_10", lb_ratio_10.Text);
			CConfig.SaveSolution(ID, "Ratio_15", lb_ratio_15.Text);
			CConfig.SaveSolution(ID, "Ratio_20", lb_ratio_20.Text);

			CConfig.SaveSolution(ID, "Win_5", lb_win_5.Text);
			CConfig.SaveSolution(ID, "Win_10", lb_win_10.Text);
			CConfig.SaveSolution(ID, "Win_15", lb_win_15.Text);
			CConfig.SaveSolution(ID, "Win_20", lb_win_20.Text);

			CConfig.SaveSolution(ID, "Win_2p_5", lb_win_2p_5.Text);
			CConfig.SaveSolution(ID, "Win_2p_10", lb_win_2p_10.Text);
			CConfig.SaveSolution(ID, "Win_2p_15", lb_win_2p_15.Text);
			CConfig.SaveSolution(ID, "Win_2p_20", lb_win_2p_20.Text);

			CConfig.SaveSolution(ID, "Win_4p_5", lb_win_4p_5.Text);
			CConfig.SaveSolution(ID, "Win_4p_10", lb_win_4p_10.Text);
			CConfig.SaveSolution(ID, "Win_4p_15", lb_win_4p_15.Text);
			CConfig.SaveSolution(ID, "Win_4p_20", lb_win_4p_20.Text);

			for (int i = 1; i <= 10; i++)
			{
				Label lable_count = (Label)(this.Controls.Find(string.Format("lb_day_count_{0}", i), true)[0]);
				CConfig.SaveSolution(ID, string.Format("lb_day_count_{0}", i), lable_count.Text);
				Label lable_ratio = (Label)(this.Controls.Find(string.Format("lb_day_ratio_{0}", i), true)[0]);
				CConfig.SaveSolution(ID, string.Format("lb_day_ratio_{0}", i), lable_ratio.Text);
			}
		}

		public void UpdateData()
		{
			int total_count = 0;
			double ratio = 0.0;
			double win_rate_p1_total = 1.0;
			double win_rate_p2_total = 1.0;
			double win_rate_p4_total = 1.0;

			Calculate(5, out total_count, out ratio, out win_rate_p1_total, out win_rate_p2_total, out win_rate_p4_total);
			lb_total_5.Text = total_count.ToString();
			lb_ratio_5.Text = ratio.ToString("P2");
			lb_win_5.Text = win_rate_p1_total.ToString("P2");
			lb_win_2p_5.Text = win_rate_p2_total.ToString("P2");
			lb_win_4p_5.Text = win_rate_p4_total.ToString("P2");

			Calculate(10, out total_count, out ratio, out win_rate_p1_total, out win_rate_p2_total, out win_rate_p4_total);
			lb_total_10.Text = total_count.ToString();
			lb_ratio_10.Text = ratio.ToString("P2");
			lb_win_10.Text = win_rate_p1_total.ToString("P2");
			lb_win_2p_10.Text = win_rate_p2_total.ToString("P2");
			lb_win_4p_10.Text = win_rate_p4_total.ToString("P2");

			Calculate(15, out total_count, out ratio, out win_rate_p1_total, out win_rate_p2_total, out win_rate_p4_total);
			lb_total_15.Text = total_count.ToString();
			lb_ratio_15.Text = ratio.ToString("P2");
			lb_win_15.Text = win_rate_p1_total.ToString("P2");
			lb_win_2p_15.Text = win_rate_p2_total.ToString("P2");
			lb_win_4p_15.Text = win_rate_p4_total.ToString("P2");

			Calculate(20, out total_count, out ratio, out win_rate_p1_total, out win_rate_p2_total, out win_rate_p4_total);
			lb_total_20.Text = total_count.ToString();
			lb_ratio_20.Text = ratio.ToString("P2");
			lb_win_20.Text = win_rate_p1_total.ToString("P2");
			lb_win_2p_20.Text = win_rate_p2_total.ToString("P2");
			lb_win_4p_20.Text = win_rate_p4_total.ToString("P2");

			int index = 1;
			for (int i = LastDay; i > LastDay - 10; i--)
			{
				if (Data.ContainsKey(i))
				{
					int count = Data[i].Count;
					int win_count = 0;
					foreach (double data in Data[i])
					{
						if (data >= 0.0) win_count++;
					}
					double win_ratio = (double)win_count / (double)count;
					Label lable_count = (Label)(this.Controls.Find(string.Format("lb_day_count_{0}", index), true)[0]);
					lable_count.Text = count.ToString();
					Label lable_ratio = (Label)(this.Controls.Find(string.Format("lb_day_ratio_{0}", index), true)[0]);
					lable_ratio.Text = win_ratio.ToString("P2");
				}
				else
				{
					Label lable_count = (Label)(this.Controls.Find(string.Format("lb_day_count_{0}", index), true)[0]);
					lable_count.Text = "0";
					Label lable_ratio = (Label)(this.Controls.Find(string.Format("lb_day_ratio_{0}", index), true)[0]);
					lable_ratio.Text = "00.00%";
				}
				index++;
			}
		}

		private void Calculate(int days, out int total_count, out double ratio, out double win_rate_p1_total, out double win_rate_p2_total, out double win_rate_p4_total)
		{
			total_count = 0;
			ratio = 0.0;
			win_rate_p1_total = 0.0;
			win_rate_p2_total = 0.0;
			win_rate_p4_total = 0.0;

			double win_ratio = 0;
			int total_days = 0;
			for (int i = LastDay; i > LastDay - days; i--)
			{
				if (Data.ContainsKey(i))
				{
					total_days++;

					int count = Data[i].Count;
					int win_count = 0;
					foreach (double data in Data[i])
					{
						if (data >= 0.0) win_count++;
					}

					win_ratio += (double)win_count / (double)count;
					total_count += count;
				}
			}

			if (total_days != 0)
			{
				ratio = win_ratio / (double)total_days;
			}
			else
			{
				ratio = 0.0;
			}

			int random_times = 0;
			if (tb_random_count.Text == "") tb_random_count.Text = "1";
			int random_count = int.Parse(tb_random_count.Text);
			while (random_times < random_count)
			{
				double win_rate = 1.0;
				double win_2p_rate = 1.0;
				double win_4p_rate = 1.0;
				for (int i = LastDay - days + 1; i <= LastDay; i++)
				{
					if (Data.ContainsKey(i))
					{
						int count = Data[i].Count;

						win_rate *= CalculateRandomRate(i, 1);
						win_2p_rate *= CalculateRandomRate(i, 2);
						win_4p_rate *= CalculateRandomRate(i, 4);
					}
				}

				win_rate_p1_total += win_rate;
				win_rate_p2_total += win_2p_rate;
				win_rate_p4_total += win_4p_rate;
				random_times++;
			}
			win_rate_p1_total = win_rate_p1_total / (double)random_times;
			win_rate_p2_total = win_rate_p2_total / (double)random_times;
			win_rate_p4_total = win_rate_p4_total / (double)random_times;
		}

		private double CalculateRandomRate(int day, int piece)
		{
			int count = Data[day].Count;

			if (count == 1 || piece == 1)
			{
				Random random = new Random();
				int random_index = random.Next(0, count);
				return (1.0 + Data[day][random_index] / 100.0);
			}

			if (count == 2)
			{
				return 0.5 * (1.0 + Data[day][0] / 100.0) + 0.5 * (1.0 + Data[day][1] / 100.0);
			}
			else
			{
				Dictionary<int, int> random_pool = new Dictionary<int, int>();

				if (count == 3) piece = 3;

				while (random_pool.Count != piece)
				{
					Random random = new Random();
					int random_index = random.Next(0, count);
					if (!random_pool.ContainsKey(random_index))
					{
						random_pool[random_index] = 1;
					}
				}

				double rate = 0.0;
				foreach (var item in random_pool)
				{
					rate += (1.0 / piece) * (1.0 + Data[day][item.Key] / 100.0);
				}

				return rate;
			}
		}
	}
}

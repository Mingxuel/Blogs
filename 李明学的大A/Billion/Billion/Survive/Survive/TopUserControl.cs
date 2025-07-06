using Peace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.Text.Json;
using Survive;

namespace Survive
{
    public partial class TopUserControl : UserControl
	{
		private CTicketManager _ticket_manager = new CTicketManager();
		private CContinueManager _continue_manager = new CContinueManager();
		private string _directory = @"../../../../../Data/Top/";
		private string _file_xlsx_format = @"{0}.xlsx";
		private string _file_json_format = @"{0}.json";
		private int _title_width = 15;
		private int lastSortedColumn;
		private Dictionary<string, int> _subjects_all = new Dictionary<string, int>();
		private Dictionary<string, int> _subjects_first_all = new Dictionary<string, int>();
		private Dictionary<string, int> _subjects_first_new = new Dictionary<string, int>();

		public TopUserControl()
		{
			InitializeComponent();

			string[] files = Directory.GetFiles(_directory, "*.xlsx");
			Array.Sort(files);
			Array.Reverse(files);
			foreach (string file in files)
			{
				string fileName = Path.GetFileNameWithoutExtension(file);
				cb_path.Items.Add(fileName);
			}
			if (cb_path.Items.Count > 0)
			{
				cb_path.SelectedIndex = 0;
			}
		}

		private void bt_load_one_Click(object sender, EventArgs e)
		{
			Load_One(EExcelType.Top, cb_path.Text);
		}

		private bool Load_One(EExcelType ptype, string pfile)
		{
			Clear();

			if (_ticket_manager.LoadExcel(ptype, pfile) == false)
			{
				return false;
			}

			Caculate_Subjects();

			Init_listview_all();
			Init_listview_subjects_all();
			Init_listview_subjects_first_all();
			Init_listview_subjects_first_new();

			return true;
		}

		private void Caculate_Subjects()
		{
			// 计算出涨停板中所有的概念出现次数
			foreach (CTicket ticket in _ticket_manager.Tickets)
			{
				if (ticket[ETicketObjectID.Subjects].Item is JsonElement)
				{ }
				foreach (string subject in (List<string>)ticket[ETicketObjectID.Subjects].Item)
				{
					if (_subjects_all.ContainsKey(subject) == false)
					{
						_subjects_all[subject] = 1;
					}
					else
					{
						_subjects_all[subject] += 1;
					}
				}
			}

			// 计算出涨停板中所有首板的概念出现次数
			foreach (CTicket ticket in _ticket_manager.Tickets)
			{
				if (ticket.GetValue(ETicketObjectID.ContinueTopTimes) != "1")
					continue;

				foreach (String subject in (List<string>)ticket[ETicketObjectID.Subjects].Item)
				{
					if (_subjects_first_all.ContainsKey(subject) == false)
					{
						_subjects_first_all[subject] = 1;
					}
					else
					{
						_subjects_first_all[subject] += 1;
					}
				}
			}

			// 计算出涨停板中所有首板的新概念出现次数
			foreach (KeyValuePair<string, int> subject in _subjects_first_all)
			{
				bool contain = false;
				foreach (CTicket ticket in _ticket_manager.Tickets)
				{
					if (int.Parse(ticket.GetValue(ETicketObjectID.ContinueTopTimes)) > 1 && ((List<string>)ticket[ETicketObjectID.Subjects].Item).Contains(subject.Key))
					{
						contain = true;
						break;
					}
				}
				if (!contain) _subjects_first_new[subject.Key] = subject.Value;
			}
		}

		//显示所有涨停股
		private void Init_listview_all()
		{
			CTicket temp = new CTicket();
			List<ETicketObjectID> ids = _ticket_manager.GetExcelTypes(EExcelType.Top);

			foreach (ETicketObjectID id in ids)
			{
				lv_all.Columns.Add(temp[id].Name, temp[id].Name.Length * _title_width, HorizontalAlignment.Center);
			}

			foreach (CTicket ticket in _ticket_manager.Tickets)
			{
				string[] values = new string[ids.Count()];

				foreach (ETicketObjectID id in ids)
				{
					values[(int)id] = ticket.GetValue(id);
				}

				ListViewItem item = new ListViewItem(values);
				lv_all.Items.Add(item);
			}
		}

		//显示所有涨停股
		private void Init_listview_subjects_all()
		{
			lv_subjects_all.Columns.Add("热门主题", 90, HorizontalAlignment.Center);
			lv_subjects_all.Columns.Add("次数", 60, HorizontalAlignment.Center);

			foreach (KeyValuePair<string, int> subject in _subjects_all)
			{
				ListViewItem item = new ListViewItem(new string[] { subject.Key, subject.Value.ToString() });
				lv_subjects_all.Items.Add(item);
			}
		}

		//显示所有涨停股
		private void Init_listview_subjects_first_all()
		{
			lv_subjects_first_all.Columns.Add("热门主题", 90, HorizontalAlignment.Center);
			lv_subjects_first_all.Columns.Add("次数", 60, HorizontalAlignment.Center);

			foreach (KeyValuePair<string, int> subject in _subjects_first_all)
			{
				ListViewItem item = new ListViewItem(new string[] { subject.Key, subject.Value.ToString() });
				lv_subjects_first_all.Items.Add(item);
			}
		}

		//显示所有涨停股
		private void Init_listview_subjects_first_new()
		{
			lv_subjects_first_new.Columns.Add("热门主题", 90, HorizontalAlignment.Center);
			lv_subjects_first_new.Columns.Add("次数", 60, HorizontalAlignment.Center);
			foreach (KeyValuePair<string, int> subject in _subjects_first_new)
			{
				if (subject.Value > 0)
				{
					ListViewItem item = new ListViewItem(new string[] { subject.Key, subject.Value.ToString() });
					lv_subjects_first_new.Items.Add(item);
				}
			}
		}

		private void SortListView(ListView listView, int columnIndex)
		{
			if (listView.Sorting == SortOrder.Ascending && columnIndex == lastSortedColumn)
			{
				listView.Sorting = SortOrder.Descending;
			}
			else
			{
				listView.Sorting = SortOrder.Ascending;
				lastSortedColumn = columnIndex;
			}
			listView.ListViewItemSorter = new CListViewItemComparer(columnIndex, listView.Sorting);
		}

		private void lv_all_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			SortListView(lv_all, e.Column);
		}

		private void lv_subjects_all_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			SortListView(lv_subjects_all, e.Column);
		}

		private void lv_subjects_first_all_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			SortListView(lv_subjects_first_all, e.Column);
		}

		private void lv_subjects_first_new_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			SortListView(lv_subjects_first_new, e.Column);
		}

		private void lv_filter_1_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			SortListView(lv_filter_1, e.Column);
		}

		private void lv_filter_2_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			SortListView(lv_filter_2, e.Column);
		}

		private void lv_filter_3_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			SortListView(lv_filter_3, e.Column);
		}

		private void Clear()
		{
			lv_all.Clear();
			lv_subjects_all.Clear();
			lv_subjects_first_all.Clear();
			lv_subjects_first_new.Clear();
			lv_filter_1.Clear();
			lv_filter_2.Clear();
			lv_filter_3.Clear();

			_subjects_all.Clear();
			_subjects_first_all.Clear();
			_subjects_first_new.Clear();

			_ticket_manager.Clear();
		}

		private void bt_subjects_all_Click(object sender, EventArgs e)
		{
			Select(lv_subjects_all, lv_filter_1, lb_filter1);
		}

		private void bt_subjects_first_all_Click(object sender, EventArgs e)
		{
			Select(lv_subjects_first_all, lv_filter_2, lb_filter2);
		}

		private void bt_subjects_first_new_Click(object sender, EventArgs e)
		{
			Select(lv_subjects_first_new, lv_filter_3, lb_filter3);
		}

		private void Select(ListView pselect, ListView poutput, Label psubject)
		{
			psubject.Text = pselect.SelectedItems[0].SubItems[0].Text;

			poutput.Clear();

			CTicket temp = new CTicket();
			List<ETicketObjectID> ids = _ticket_manager.GetExcelTypes(EExcelType.Top);

			foreach (ETicketObjectID id in ids)
			{
				poutput.Columns.Add(temp[id].Name, temp[id].Name.Length * _title_width, HorizontalAlignment.Center);
			}

			foreach (CTicket ticket in _ticket_manager.Tickets)
			{
				string[] values = new string[ids.Count()];

				foreach (ETicketObjectID id in ids)
				{
					values[(int)id] = ticket.GetValue(ticket[id].ID);
				}

				int type = int.Parse(ticket.GetValue(ETicketObjectID.ID)) / 10000;
				if (((List<string>)ticket[ETicketObjectID.Subjects].Item).Contains(psubject.Text) && type != 30 && type != 68 && type != 83 && type != 43)
				{
					ListViewItem item = new ListViewItem(values);
					poutput.Items.Add(item);
				}
			}
		}

		private void btn_continue_Click(object sender, EventArgs e)
		{
			ContinueClear();

			Update_continue_manager();
			Update_lv_continue();
			Update_lv_continue_ratio();
		}

		private void ContinueClear()
		{
			_continue_manager.Clear();

			lv_continue.Clear();
		}

		private void Update_continue_manager()
		{
			int day = 1;
			string[] files = Directory.GetFiles(_directory, "*.xlsx");
			Array.Sort(files);
			Array.Reverse(files);
			foreach (string file in files)
			{
				if (day > 15) break;
				CTicketManager ticket_manager = new CTicketManager();
				ticket_manager.LoadExcel(EExcelType.Top, Path.GetFileNameWithoutExtension(file));
				foreach (CTicket ticket in ticket_manager.Tickets)
				{
					if (!((List<string>)ticket[ETicketObjectID.Subjects].Item).Contains("ST板块"))
					{
						_continue_manager.Add(day, TimeSpan.Parse(ticket.GetValue(ETicketObjectID.TopStarttime)), int.Parse(ticket.GetValue(ETicketObjectID.ContinueTopTimes)));
					}
				}
				day += 1;
			}
		}

		private void Update_lv_continue()
		{
			lv_continue.Columns.Add("板数", 45, HorizontalAlignment.Center);
			for (int i = 1; i <= 15; i++)
			{
				lv_continue.Columns.Add(string.Format("{0}天", i), 53, HorizontalAlignment.Center);
			}

			for (int continue_times = 1; continue_times <= 15; continue_times++)
			{
				ListViewItem item = new ListViewItem(_continue_manager.Total(continue_times));
				lv_continue.Items.Add(item);
			}
		}

		private void Update_lv_continue_ratio()
		{
			lv_ratio.Columns.Add("板数", 45, HorizontalAlignment.Center);
			for (int i = 1; i <= 15; i++)
			{
				lv_ratio.Columns.Add(string.Format("{0}天", i), 53, HorizontalAlignment.Center);
			}

			for (int continue_times = 1; continue_times <= 15; continue_times++)
			{
				ListViewItem item = new ListViewItem(_continue_manager.Ratio(continue_times));
				lv_ratio.Items.Add(item);
			}
		}
	}
}

using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Survive
{
	public partial class ConfigInputUserControl : UserControl
	{
		public ConfigInputUserControl()
		{
			InitializeComponent();
		}

		private string _day = "N";
		public string Day
		{

			get
			{
				return _day;
			}
			set
			{
				if (value != "-1")
				{
					_day = value;
					Update_Day_Changed();
				}
			}
		}

		public string Title1
		{

			get { return lb_1.Text; }
			set { lb_1.Text = value; }
		}

		public string Title2
		{
			get { return lb_2.Text; }
			set { lb_2.Text = value; }
		}

		public string Value1
		{

			get { return tb_1.Text; }
			set { tb_1.Text = value; }
		}

		public string Value2
		{
			get { return tb_2.Text; }
			set { tb_2.Text = value; }
		}

		public bool _visible1 = true;
		public bool Visible1
		{
			get
			{
				return _visible1;
			}

			set
			{
				_visible1 = lb_1.Visible;
				lb_1.Visible = value;
				tb_1.Visible = value;
			}
		}

		public bool _visible2 = true;
		public bool Visible2
		{
			get
			{
				return _visible2;
			}

			set
			{
				_visible2 = lb_2.Visible;
				lb_2.Visible = value;
				tb_2.Visible = value;
			}
		}

		public bool _visible3 = true;
		public bool Visible3
		{
			get
			{
				return _visible3;
			}

			set
			{
				_visible3 = value;
				rbtn_up.Visible = value;
				rbtn_down.Visible = value;
				rbtn_none.Visible = value;
			}
		}

		private ERateStatus _status;
		public int RateStatus
		{
			get
			{
				return (int)_status;
			}

			set
			{
				_status = (ERateStatus)value;
				Update_Status();
			}
		}

		private void Update_Day_Changed()
		{
			lb_1.Text = string.Format("{0}-DAY 涨幅最低", _day);
			lb_2.Text = string.Format("{0}-DAY 涨幅最高", _day);
		}

		private void Update_Status()
		{
			switch (_status)
			{
				case ERateStatus.None:
					rbtn_up.Checked = false;
					rbtn_down.Checked = false;
					rbtn_none.Checked = true;
					break;
				case ERateStatus.Up:
					rbtn_up.Checked = true;
					rbtn_down.Checked = false;
					rbtn_none.Checked = false;
					break;
				case ERateStatus.Down:
					rbtn_up.Checked = false;
					rbtn_down.Checked = true;
					rbtn_none.Checked = false;
					break;
			}
		}

		private void CheckChanged(object sender, EventArgs e)
		{
			if (rbtn_up.Checked)
			{
				_status = ERateStatus.Up;
			}
			else if (rbtn_down.Checked)
			{
				_status = ERateStatus.Down;
			}
			else
			{
				_status = ERateStatus.None;
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Survive
{
	public partial class RatioUserControl : UserControl
	{
		List<CRatioUserControlItem> items = new List<CRatioUserControlItem>();
		public RatioUserControl()
		{
			InitializeComponent();
		}

		public void SetTitle(string col1, string col2, string col3)
		{
			lb_title_1.Text = col1;
			lb_title_2.Text = col2;
			lb_title_3.Text = col3;
		}

		public void Add(string range, string count, string ratio)
		{
			CRatioUserControlItem item = new CRatioUserControlItem(range, count, ratio);
			items.Add(item);

			int row = items.Count;

			if (row > 20) return;

			Label lb_range = new Label();
			tlp_main.Controls.Add(lb_range, 0, row);
			lb_range.Text = range;
			lb_range.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			lb_range.AutoSize = true;
			lb_range.Font = new Font("Showcard Gothic", 8F, FontStyle.Bold);
			lb_range.ForeColor = Color.LightGray;
			lb_range.TextAlign = ContentAlignment.MiddleCenter;

			Label lb_count = new Label();
			tlp_main.Controls.Add(lb_count, 1, row);
			lb_count.Text = count.ToString();
			lb_count.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			lb_count.AutoSize = true;
			lb_count.Font = new Font("Showcard Gothic", 8F, FontStyle.Bold);
			lb_count.ForeColor = Color.LightGray;
			lb_count.TextAlign = ContentAlignment.MiddleCenter;

			ProgressBar pbar_ratio = new ProgressBar();
			pbar_ratio.Margin = new Padding(0);
			pbar_ratio.Width = 100;
			pbar_ratio.Height = 15;
			pbar_ratio.Step = 1;
			pbar_ratio.Maximum = 50;
			if (int.Parse(ratio) > 50) ratio = "50";
			pbar_ratio.Value = int.Parse(ratio);
			tlp_main.Controls.Add(pbar_ratio, 2, row);
		}

		public void Clear()
		{
			items.Clear();
			tlp_main.Controls.Clear();
		}
	}
}

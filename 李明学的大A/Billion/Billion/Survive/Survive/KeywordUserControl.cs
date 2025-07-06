using Peace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Survive
{
    public partial class KeywordUserControl : Form
    {
        private List<string> _days = new List<string>();
        private Dictionary<string, string> _keywords = new Dictionary<string, string>();
        public KeywordUserControl()
        {
            InitializeComponent();
            InitText();

            foreach (var item in _keywords)
            {
                cb_no1_keys.Items.Add(item.Key);
                cb_no2_keys.Items.Add(item.Key);
            }

            InitControls();
        }

        private void KeywordUserControl_Load(object sender, EventArgs e)
        {
            cb_no1_keys.SelectedIndex = 0;
            cb_no2_keys.SelectedIndex = 1;
        }

        private void InitText()
        {
            _keywords["二板缩量自选"] = "主板非st，\r\nDAY-0缩量涨停，\r\nDAY-1涨停，\r\nDAY-2非涨停";
            _keywords["二板缩量"] = "主板非st，\r\nDAY-0未涨停，\r\nDAY-1缩量涨停，\r\nDAY-2涨停，\r\nDAY-3非涨停";
            _keywords["二板放量自选"] = "主板非st，\r\nDAY-0放量涨停，\r\nDAY-1涨停，\r\nDAY-2非涨停";
            _keywords["二板放量"] = "主板非st，\r\nDAY-0未涨停，\r\nDAY-1放量涨停，\r\nDAY-2涨停，\r\nDAY-3非涨停，\r\nDAY-0成交量大于DAY-1成交量，\r\nDAY-0成交量大于DAY-2成交量，\r\nDAY-1振幅大于5%，\r\nDAY-2振幅大于5%";
        }

        private void InitControls()
        {
            lv_no1_days.Clear();
            lv_no2_days.Clear();
            _days.Clear();

            lv_no1_days.Columns.Add(" ", 5, HorizontalAlignment.Center);
            lv_no1_days.Columns.Add("DAYS", 160, HorizontalAlignment.Center);
            lv_no2_days.Columns.Add(" ", 5, HorizontalAlignment.Center);
            lv_no2_days.Columns.Add("DAYS", 160, HorizontalAlignment.Center);

            tb_days.Text = CConfig.LoadKeyDays();

            string[] keydays = CConfig.LoadKeyDays().Split("\r\n");
            int i = 1;
            foreach (string file in keydays)
            {
                string[] values = new string[2];
                values[0] = i++.ToString();
                values[1] = Path.GetFileNameWithoutExtension(file);
                ListViewItem item1 = new ListViewItem(values);
                lv_no1_days.Items.Add(item1);
                ListViewItem item2 = new ListViewItem(values);
                lv_no2_days.Items.Add(item2);
                ListViewItem item3 = new ListViewItem(values);
                _days.Add(Path.GetFileNameWithoutExtension(file));
            }

            tb_no1_input.Text = _keywords.ElementAt(0).Value;
            tb_no2_input.Text = _keywords.ElementAt(1).Value;
        }

        private string generate_key(string text, string selected_day)
        {
            List<string> days = new List<string>();
            foreach (string day in _days)
            {
                if (day == selected_day)
                {
                    days.Add(day);
                    continue;
                }
                if (days.Count() > 0)
                {
                    days.Add(day);
                }
            }

            if (text.Contains("DAY-6"))
            {
                text = text.Replace("DAY-6", days.ElementAt(6));
            }
            if (text.Contains("DAY-5"))
            {
                text = text.Replace("DAY-5", days.ElementAt(5));
            }
            if (text.Contains("DAY-4"))
            {
                text = text.Replace("DAY-4", days.ElementAt(4));
            }
            if (text.Contains("DAY-3"))
            {
                text = text.Replace("DAY-3", days.ElementAt(3));
            }
            if (text.Contains("DAY-2"))
            {
                text = text.Replace("DAY-2", days.ElementAt(2));
            }
            if (text.Contains("DAY-1"))
            {
                text = text.Replace("DAY-1", days.ElementAt(1));
            }
            if (text.Contains("DAY-0"))
            {
                text = text.Replace("DAY-0", days.ElementAt(0));
            }

            return text;
        }

        private void btn_no1_generate_Click(object sender, EventArgs e)
        {
            if (lv_no1_days.SelectedItems.Count == 0) return;

            string text = tb_no1_input.Text;
            text = generate_key(text, lv_no1_days.SelectedItems[0].SubItems[1].Text);
            tb_no1_output.Text = text;
            Clipboard.SetText(text);
        }

        private void btn_no2_generate_Click(object sender, EventArgs e)
        {
            if (lv_no2_days.SelectedItems.Count == 0) return;

            string text = tb_no2_input.Text;
            text = generate_key(text, lv_no2_days.SelectedItems[0].SubItems[1].Text);
            tb_no2_output.Text = text;
            Clipboard.SetText(text);
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            CConfig.SaveKeyDays(tb_days.Text);
            InitControls();
        }

        private void cb_no1_keys_SelectedValueChanged(object sender, EventArgs e)
        {
            string key = cb_no1_keys.Text;
            if (_keywords.ContainsKey(key))
            {
                tb_no1_input.Text = _keywords[key];
            }
        }

        private void cb_no2_keys_SelectedValueChanged(object sender, EventArgs e)
        {
            string key = cb_no2_keys.Text;
            if (_keywords.ContainsKey(key))
            {
                tb_no2_input.Text = _keywords[key];
            }
        }

        private void KeywordUserControl_Resize(object sender, EventArgs e)
        {
            gb_key1.Height = this.ClientSize.Height / 2 - 11;
            gb_key2.Height = this.ClientSize.Height / 2 - 11;
        }
    }
}

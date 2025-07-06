namespace Survive
{
	partial class MainUserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private int lastSortedColumn;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private int UpdateDaysControls()
		{
			if (rbtn_day3.Checked)
			{
				ciuc_rate_day_4.Visible = false;
				ciuc_rate_day_5.Visible = false;
				ciuc_rate_day_6.Visible = false;
				ciuc_trade_buy_4.Visible = false;
				ciuc_trade_buy_5.Visible = false;
				ciuc_trade_buy_6.Visible = false;
				return 3;
			}
			else if (rbtn_day4.Checked)
			{
				ciuc_rate_day_4.Visible = true;
				ciuc_rate_day_5.Visible = false;
				ciuc_rate_day_6.Visible = false;
				ciuc_trade_buy_4.Visible = true;
				ciuc_trade_buy_5.Visible = false;
				ciuc_trade_buy_6.Visible = false;
				return 4;
			}
			else if (rbtn_day5.Checked)
			{
				ciuc_rate_day_4.Visible = true;
				ciuc_rate_day_5.Visible = true;
				ciuc_rate_day_6.Visible = false;
				ciuc_trade_buy_4.Visible = true;
				ciuc_trade_buy_5.Visible = true;
				ciuc_trade_buy_6.Visible = false;
				return 5;
			}
			else if (rbtn_day6.Checked)
			{
				ciuc_rate_day_4.Visible = true;
				ciuc_rate_day_5.Visible = true;
				ciuc_rate_day_6.Visible = true;
				ciuc_trade_buy_4.Visible = true;
				ciuc_trade_buy_5.Visible = true;
				ciuc_trade_buy_6.Visible = true;
				return 6;
			}

			return 3;
		}

		private void lv_filter_result_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			SortListView(lv_filter_result, e.Column);
		}

		private void lv_analyze_details_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			SortListView(lv_analyze_details, e.Column);
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			groupBox7 = new GroupBox();
			cb_plate_st = new CheckBox();
			cb_plate_beijing = new CheckBox();
			cb_plate_chuangye = new CheckBox();
			cb_plate_kechuang = new CheckBox();
			cb_plate_shenzhen = new CheckBox();
			cb_plate_shanghai = new CheckBox();
			bt_analyze = new Button();
			bg_days = new GroupBox();
			rbtn_day6 = new RadioButton();
			rbtn_day5 = new RadioButton();
			rbtn_day3 = new RadioButton();
			rbtn_day4 = new RadioButton();
			tb_functions = new TextBox();
			ciuc_rate_day_0 = new ConfigInputUserControl();
			ciuc_rate_day_6 = new ConfigInputUserControl();
			ciuc_rate_day_5 = new ConfigInputUserControl();
			ciuc_rate_day_4 = new ConfigInputUserControl();
			ciuc_rate_day_3 = new ConfigInputUserControl();
			ciuc_rate_day_2 = new ConfigInputUserControl();
			ciuc_rate_day_1 = new ConfigInputUserControl();
			bt_solution_save = new Button();
			cb_solution = new ComboBox();
			bt_solution_4 = new Button();
			bt_solution_3 = new Button();
			bt_solution_2 = new Button();
			bt_solution_1 = new Button();
			groupBox1 = new GroupBox();
			soluc_0 = new SolutionUserControl();
			lb_target_name_2 = new Label();
			lb_target_id_2 = new Label();
			lb_target_id_1 = new Label();
			uc_ratio = new RatioUserControl();
			lv_filter_result = new ListView();
			columnHeader11 = new ColumnHeader();
			columnHeader12 = new ColumnHeader();
			columnHeader14 = new ColumnHeader();
			columnHeader15 = new ColumnHeader();
			columnHeader16 = new ColumnHeader();
			columnHeader17 = new ColumnHeader();
			columnHeader18 = new ColumnHeader();
			columnHeader13 = new ColumnHeader();
			label15 = new Label();
			lv_analyze_details = new ListView();
			columnHeader1 = new ColumnHeader();
			columnHeader2 = new ColumnHeader();
			columnHeader3 = new ColumnHeader();
			columnHeader10 = new ColumnHeader();
			columnHeader4 = new ColumnHeader();
			columnHeader5 = new ColumnHeader();
			columnHeader6 = new ColumnHeader();
			columnHeader7 = new ColumnHeader();
			columnHeader8 = new ColumnHeader();
			columnHeader9 = new ColumnHeader();
			columnHeader19 = new ColumnHeader();
			panel2 = new Panel();
			groupBox3 = new GroupBox();
			tableLayoutPanel1 = new TableLayoutPanel();
			label4 = new Label();
			label5 = new Label();
			lb_today_count = new Label();
			lb_today_space = new Label();
			label9 = new Label();
			label10 = new Label();
			lb_target_name_1 = new Label();
			lb_target_id_3 = new Label();
			lb_target_name_3 = new Label();
			lb_target_id_4 = new Label();
			lb_target_name_4 = new Label();
			groupBox2 = new GroupBox();
			tabControl2 = new TabControl();
			tabPage13 = new TabPage();
			soluc_1 = new SolutionUserControl();
			tabPage14 = new TabPage();
			soluc_2 = new SolutionUserControl();
			tabPage15 = new TabPage();
			soluc_3 = new SolutionUserControl();
			tabPage16 = new TabPage();
			soluc_4 = new SolutionUserControl();
			tabPage17 = new TabPage();
			soluc_5 = new SolutionUserControl();
			tabPage18 = new TabPage();
			soluc_6 = new SolutionUserControl();
			tabPage19 = new TabPage();
			soluc_7 = new SolutionUserControl();
			tabPage20 = new TabPage();
			soluc_8 = new SolutionUserControl();
			tabPage21 = new TabPage();
			soluc_9 = new SolutionUserControl();
			tabPage22 = new TabPage();
			soluc_10 = new SolutionUserControl();
			tabPage23 = new TabPage();
			soluc_11 = new SolutionUserControl();
			tabPage24 = new TabPage();
			soluc_12 = new SolutionUserControl();
			tabPage25 = new TabPage();
			soluc_13 = new SolutionUserControl();
			tabPage26 = new TabPage();
			soluc_14 = new SolutionUserControl();
			tabPage27 = new TabPage();
			soluc_15 = new SolutionUserControl();
			tabPage28 = new TabPage();
			soluc_16 = new SolutionUserControl();
			tabPage29 = new TabPage();
			soluc_17 = new SolutionUserControl();
			tabPage30 = new TabPage();
			soluc_18 = new SolutionUserControl();
			tabPage31 = new TabPage();
			soluc_19 = new SolutionUserControl();
			tabPage32 = new TabPage();
			soluc_20 = new SolutionUserControl();
			panel1 = new Panel();
			tb_last_day = new TextBox();
			tb_first_day = new TextBox();
			groupBox4 = new GroupBox();
			gb_conditions = new TabControl();
			tabPage1 = new TabPage();
			groupBox6 = new GroupBox();
			rbtn_top_status_none = new RadioButton();
			rbtn_top_status_low = new RadioButton();
			rbtn_top_status_high = new RadioButton();
			tabPage2 = new TabPage();
			tabPage3 = new TabPage();
			groupBox5 = new GroupBox();
			rbtn_average_value_none = new RadioButton();
			rbtn_average_value_low = new RadioButton();
			rbtn_average_value_high = new RadioButton();
			tabPage4 = new TabPage();
			label1 = new Label();
			ciuc_trade_buy_5 = new ConfigInputUserControl();
			ciuc_trade_buy_6 = new ConfigInputUserControl();
			ciuc_trade_buy_4 = new ConfigInputUserControl();
			ciuc_trade_buy_3 = new ConfigInputUserControl();
			ciuc_trade_buy_2 = new ConfigInputUserControl();
			ciuc_trade_buy_1 = new ConfigInputUserControl();
			ciuc_trade_buy_0 = new ConfigInputUserControl();
			ciuc_market_value = new ConfigInputUserControl();
			groupBox7.SuspendLayout();
			bg_days.SuspendLayout();
			groupBox1.SuspendLayout();
			panel2.SuspendLayout();
			groupBox3.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			groupBox2.SuspendLayout();
			tabControl2.SuspendLayout();
			tabPage13.SuspendLayout();
			tabPage14.SuspendLayout();
			tabPage15.SuspendLayout();
			tabPage16.SuspendLayout();
			tabPage17.SuspendLayout();
			tabPage18.SuspendLayout();
			tabPage19.SuspendLayout();
			tabPage20.SuspendLayout();
			tabPage21.SuspendLayout();
			tabPage22.SuspendLayout();
			tabPage23.SuspendLayout();
			tabPage24.SuspendLayout();
			tabPage25.SuspendLayout();
			tabPage26.SuspendLayout();
			tabPage27.SuspendLayout();
			tabPage28.SuspendLayout();
			tabPage29.SuspendLayout();
			tabPage30.SuspendLayout();
			tabPage31.SuspendLayout();
			tabPage32.SuspendLayout();
			panel1.SuspendLayout();
			groupBox4.SuspendLayout();
			gb_conditions.SuspendLayout();
			tabPage1.SuspendLayout();
			groupBox6.SuspendLayout();
			tabPage2.SuspendLayout();
			tabPage3.SuspendLayout();
			groupBox5.SuspendLayout();
			tabPage4.SuspendLayout();
			SuspendLayout();
			// 
			// groupBox7
			// 
			groupBox7.Controls.Add(cb_plate_st);
			groupBox7.Controls.Add(cb_plate_beijing);
			groupBox7.Controls.Add(cb_plate_chuangye);
			groupBox7.Controls.Add(cb_plate_kechuang);
			groupBox7.Controls.Add(cb_plate_shenzhen);
			groupBox7.Controls.Add(cb_plate_shanghai);
			groupBox7.Font = new Font("Showcard Gothic", 12F, FontStyle.Bold);
			groupBox7.ForeColor = Color.LightGray;
			groupBox7.Location = new Point(10, 79);
			groupBox7.Name = "groupBox7";
			groupBox7.Size = new Size(532, 68);
			groupBox7.TabIndex = 6;
			groupBox7.TabStop = false;
			groupBox7.Text = "PLATE";
			// 
			// cb_plate_st
			// 
			cb_plate_st.AutoSize = true;
			cb_plate_st.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
			cb_plate_st.ForeColor = Color.LightGray;
			cb_plate_st.Location = new Point(449, 30);
			cb_plate_st.Name = "cb_plate_st";
			cb_plate_st.Size = new Size(55, 19);
			cb_plate_st.TabIndex = 9;
			cb_plate_st.Text = "ST股";
			cb_plate_st.UseVisualStyleBackColor = true;
			// 
			// cb_plate_beijing
			// 
			cb_plate_beijing.AutoSize = true;
			cb_plate_beijing.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
			cb_plate_beijing.ForeColor = Color.LightGray;
			cb_plate_beijing.Location = new Point(361, 30);
			cb_plate_beijing.Name = "cb_plate_beijing";
			cb_plate_beijing.Size = new Size(78, 19);
			cb_plate_beijing.TabIndex = 8;
			cb_plate_beijing.Text = "北京主板";
			cb_plate_beijing.UseVisualStyleBackColor = true;
			// 
			// cb_plate_chuangye
			// 
			cb_plate_chuangye.AutoSize = true;
			cb_plate_chuangye.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
			cb_plate_chuangye.ForeColor = Color.LightGray;
			cb_plate_chuangye.Location = new Point(273, 30);
			cb_plate_chuangye.Name = "cb_plate_chuangye";
			cb_plate_chuangye.Size = new Size(78, 19);
			cb_plate_chuangye.TabIndex = 7;
			cb_plate_chuangye.Text = "创业主板";
			cb_plate_chuangye.UseVisualStyleBackColor = true;
			// 
			// cb_plate_kechuang
			// 
			cb_plate_kechuang.AutoSize = true;
			cb_plate_kechuang.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
			cb_plate_kechuang.ForeColor = Color.LightGray;
			cb_plate_kechuang.Location = new Point(185, 30);
			cb_plate_kechuang.Name = "cb_plate_kechuang";
			cb_plate_kechuang.Size = new Size(78, 19);
			cb_plate_kechuang.TabIndex = 6;
			cb_plate_kechuang.Text = "科创主板";
			cb_plate_kechuang.UseVisualStyleBackColor = true;
			// 
			// cb_plate_shenzhen
			// 
			cb_plate_shenzhen.AutoSize = true;
			cb_plate_shenzhen.Checked = true;
			cb_plate_shenzhen.CheckState = CheckState.Checked;
			cb_plate_shenzhen.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
			cb_plate_shenzhen.ForeColor = Color.LightGray;
			cb_plate_shenzhen.Location = new Point(97, 30);
			cb_plate_shenzhen.Name = "cb_plate_shenzhen";
			cb_plate_shenzhen.Size = new Size(78, 19);
			cb_plate_shenzhen.TabIndex = 5;
			cb_plate_shenzhen.Text = "深圳主板";
			cb_plate_shenzhen.UseVisualStyleBackColor = true;
			// 
			// cb_plate_shanghai
			// 
			cb_plate_shanghai.AutoSize = true;
			cb_plate_shanghai.Checked = true;
			cb_plate_shanghai.CheckState = CheckState.Checked;
			cb_plate_shanghai.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
			cb_plate_shanghai.ForeColor = Color.LightGray;
			cb_plate_shanghai.Location = new Point(9, 30);
			cb_plate_shanghai.Name = "cb_plate_shanghai";
			cb_plate_shanghai.Size = new Size(78, 19);
			cb_plate_shanghai.TabIndex = 4;
			cb_plate_shanghai.Text = "上海主板";
			cb_plate_shanghai.UseVisualStyleBackColor = true;
			// 
			// bt_analyze
			// 
			bt_analyze.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
			bt_analyze.ForeColor = Color.Black;
			bt_analyze.Location = new Point(174, 3);
			bt_analyze.Margin = new Padding(0);
			bt_analyze.Name = "bt_analyze";
			bt_analyze.Size = new Size(75, 23);
			bt_analyze.TabIndex = 2;
			bt_analyze.Text = "Analyze Data";
			bt_analyze.UseVisualStyleBackColor = true;
			bt_analyze.Click += bt_analyze_Click;
			// 
			// bg_days
			// 
			bg_days.Controls.Add(rbtn_day6);
			bg_days.Controls.Add(rbtn_day5);
			bg_days.Controls.Add(rbtn_day3);
			bg_days.Controls.Add(rbtn_day4);
			bg_days.Font = new Font("Showcard Gothic", 12F, FontStyle.Bold);
			bg_days.ForeColor = Color.LightGray;
			bg_days.Location = new Point(10, 6);
			bg_days.Name = "bg_days";
			bg_days.Size = new Size(532, 67);
			bg_days.TabIndex = 0;
			bg_days.TabStop = false;
			bg_days.Text = "DAYS";
			// 
			// rbtn_day6
			// 
			rbtn_day6.AutoSize = true;
			rbtn_day6.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
			rbtn_day6.Location = new Point(273, 31);
			rbtn_day6.Name = "rbtn_day6";
			rbtn_day6.Size = new Size(72, 19);
			rbtn_day6.TabIndex = 5;
			rbtn_day6.Text = "6 DAYS";
			rbtn_day6.UseVisualStyleBackColor = true;
			rbtn_day6.CheckedChanged += Days_Changed;
			// 
			// rbtn_day5
			// 
			rbtn_day5.AutoSize = true;
			rbtn_day5.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
			rbtn_day5.Location = new Point(185, 31);
			rbtn_day5.Name = "rbtn_day5";
			rbtn_day5.Size = new Size(72, 19);
			rbtn_day5.TabIndex = 4;
			rbtn_day5.Text = "5 DAYS";
			rbtn_day5.UseVisualStyleBackColor = true;
			rbtn_day5.CheckedChanged += Days_Changed;
			// 
			// rbtn_day3
			// 
			rbtn_day3.AutoSize = true;
			rbtn_day3.Checked = true;
			rbtn_day3.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
			rbtn_day3.Location = new Point(10, 31);
			rbtn_day3.Name = "rbtn_day3";
			rbtn_day3.Size = new Size(72, 19);
			rbtn_day3.TabIndex = 2;
			rbtn_day3.TabStop = true;
			rbtn_day3.Text = "3 DAYS";
			rbtn_day3.UseVisualStyleBackColor = true;
			rbtn_day3.CheckedChanged += Days_Changed;
			// 
			// rbtn_day4
			// 
			rbtn_day4.AutoSize = true;
			rbtn_day4.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
			rbtn_day4.Location = new Point(97, 31);
			rbtn_day4.Name = "rbtn_day4";
			rbtn_day4.Size = new Size(73, 19);
			rbtn_day4.TabIndex = 3;
			rbtn_day4.Text = "4 DAYS";
			rbtn_day4.UseVisualStyleBackColor = true;
			rbtn_day4.CheckedChanged += Days_Changed;
			// 
			// tb_functions
			// 
			tb_functions.BackColor = Color.FromArgb(30, 30, 30);
			tb_functions.ForeColor = Color.LightGray;
			tb_functions.Location = new Point(6, 5);
			tb_functions.Multiline = true;
			tb_functions.Name = "tb_functions";
			tb_functions.Size = new Size(500, 447);
			tb_functions.TabIndex = 36;
			// 
			// ciuc_rate_day_0
			// 
			ciuc_rate_day_0.BackColor = Color.Transparent;
			ciuc_rate_day_0.Day = "N";
			ciuc_rate_day_0.Font = new Font("Showcard Gothic", 8F, FontStyle.Bold);
			ciuc_rate_day_0.ForeColor = Color.LightGray;
			ciuc_rate_day_0.Location = new Point(0, 11);
			ciuc_rate_day_0.Margin = new Padding(0);
			ciuc_rate_day_0.Name = "ciuc_rate_day_0";
			ciuc_rate_day_0.RateStatus = 0;
			ciuc_rate_day_0.Size = new Size(512, 30);
			ciuc_rate_day_0.TabIndex = 35;
			ciuc_rate_day_0.Title1 = "N-DAY 涨幅最低";
			ciuc_rate_day_0.Title2 = "N-DAY 涨幅最高";
			ciuc_rate_day_0.Value1 = "-11";
			ciuc_rate_day_0.Value2 = "11";
			ciuc_rate_day_0.Visible1 = true;
			ciuc_rate_day_0.Visible2 = true;
			ciuc_rate_day_0.Visible3 = true;
			// 
			// ciuc_rate_day_6
			// 
			ciuc_rate_day_6.BackColor = Color.Transparent;
			ciuc_rate_day_6.Day = "6";
			ciuc_rate_day_6.Font = new Font("Showcard Gothic", 8F, FontStyle.Bold);
			ciuc_rate_day_6.ForeColor = Color.LightGray;
			ciuc_rate_day_6.Location = new Point(0, 191);
			ciuc_rate_day_6.Margin = new Padding(0);
			ciuc_rate_day_6.Name = "ciuc_rate_day_6";
			ciuc_rate_day_6.RateStatus = 0;
			ciuc_rate_day_6.Size = new Size(512, 30);
			ciuc_rate_day_6.TabIndex = 34;
			ciuc_rate_day_6.Title1 = "6-DAY 涨幅最低";
			ciuc_rate_day_6.Title2 = "6-DAY 涨幅最高";
			ciuc_rate_day_6.Value1 = "-11";
			ciuc_rate_day_6.Value2 = "11";
			ciuc_rate_day_6.Visible1 = true;
			ciuc_rate_day_6.Visible2 = true;
			ciuc_rate_day_6.Visible3 = true;
			// 
			// ciuc_rate_day_5
			// 
			ciuc_rate_day_5.BackColor = Color.Transparent;
			ciuc_rate_day_5.Day = "5";
			ciuc_rate_day_5.Font = new Font("Showcard Gothic", 8F, FontStyle.Bold);
			ciuc_rate_day_5.ForeColor = Color.LightGray;
			ciuc_rate_day_5.Location = new Point(0, 161);
			ciuc_rate_day_5.Margin = new Padding(0);
			ciuc_rate_day_5.Name = "ciuc_rate_day_5";
			ciuc_rate_day_5.RateStatus = 0;
			ciuc_rate_day_5.Size = new Size(512, 30);
			ciuc_rate_day_5.TabIndex = 24;
			ciuc_rate_day_5.Title1 = "5-DAY 涨幅最低";
			ciuc_rate_day_5.Title2 = "5-DAY 涨幅最高";
			ciuc_rate_day_5.Value1 = "-11";
			ciuc_rate_day_5.Value2 = "11";
			ciuc_rate_day_5.Visible1 = true;
			ciuc_rate_day_5.Visible2 = true;
			ciuc_rate_day_5.Visible3 = true;
			// 
			// ciuc_rate_day_4
			// 
			ciuc_rate_day_4.BackColor = Color.Transparent;
			ciuc_rate_day_4.Day = "4";
			ciuc_rate_day_4.Font = new Font("Showcard Gothic", 8F, FontStyle.Bold);
			ciuc_rate_day_4.ForeColor = Color.LightGray;
			ciuc_rate_day_4.Location = new Point(0, 131);
			ciuc_rate_day_4.Margin = new Padding(0);
			ciuc_rate_day_4.Name = "ciuc_rate_day_4";
			ciuc_rate_day_4.RateStatus = 0;
			ciuc_rate_day_4.Size = new Size(512, 30);
			ciuc_rate_day_4.TabIndex = 23;
			ciuc_rate_day_4.Title1 = "4-DAY 涨幅最低";
			ciuc_rate_day_4.Title2 = "4-DAY 涨幅最高";
			ciuc_rate_day_4.Value1 = "-11";
			ciuc_rate_day_4.Value2 = "11";
			ciuc_rate_day_4.Visible1 = true;
			ciuc_rate_day_4.Visible2 = true;
			ciuc_rate_day_4.Visible3 = true;
			// 
			// ciuc_rate_day_3
			// 
			ciuc_rate_day_3.BackColor = Color.Transparent;
			ciuc_rate_day_3.Day = "3";
			ciuc_rate_day_3.Font = new Font("Showcard Gothic", 8F, FontStyle.Bold);
			ciuc_rate_day_3.ForeColor = Color.LightGray;
			ciuc_rate_day_3.Location = new Point(0, 101);
			ciuc_rate_day_3.Margin = new Padding(0);
			ciuc_rate_day_3.Name = "ciuc_rate_day_3";
			ciuc_rate_day_3.RateStatus = 0;
			ciuc_rate_day_3.Size = new Size(512, 30);
			ciuc_rate_day_3.TabIndex = 22;
			ciuc_rate_day_3.Title1 = "3-DAY 涨幅最低";
			ciuc_rate_day_3.Title2 = "3-DAY 涨幅最高";
			ciuc_rate_day_3.Value1 = "-11";
			ciuc_rate_day_3.Value2 = "11";
			ciuc_rate_day_3.Visible1 = true;
			ciuc_rate_day_3.Visible2 = true;
			ciuc_rate_day_3.Visible3 = true;
			// 
			// ciuc_rate_day_2
			// 
			ciuc_rate_day_2.BackColor = Color.Transparent;
			ciuc_rate_day_2.Day = "2";
			ciuc_rate_day_2.Font = new Font("Showcard Gothic", 8F, FontStyle.Bold);
			ciuc_rate_day_2.ForeColor = Color.LightGray;
			ciuc_rate_day_2.Location = new Point(0, 71);
			ciuc_rate_day_2.Margin = new Padding(0);
			ciuc_rate_day_2.Name = "ciuc_rate_day_2";
			ciuc_rate_day_2.RateStatus = 0;
			ciuc_rate_day_2.Size = new Size(512, 30);
			ciuc_rate_day_2.TabIndex = 21;
			ciuc_rate_day_2.Title1 = "2-DAY 涨幅最低";
			ciuc_rate_day_2.Title2 = "2-DAY 涨幅最高";
			ciuc_rate_day_2.Value1 = "-11";
			ciuc_rate_day_2.Value2 = "11";
			ciuc_rate_day_2.Visible1 = true;
			ciuc_rate_day_2.Visible2 = true;
			ciuc_rate_day_2.Visible3 = true;
			// 
			// ciuc_rate_day_1
			// 
			ciuc_rate_day_1.BackColor = Color.Transparent;
			ciuc_rate_day_1.Day = "1";
			ciuc_rate_day_1.Font = new Font("Showcard Gothic", 8F, FontStyle.Bold);
			ciuc_rate_day_1.ForeColor = Color.LightGray;
			ciuc_rate_day_1.Location = new Point(0, 41);
			ciuc_rate_day_1.Margin = new Padding(0);
			ciuc_rate_day_1.Name = "ciuc_rate_day_1";
			ciuc_rate_day_1.RateStatus = 0;
			ciuc_rate_day_1.Size = new Size(512, 30);
			ciuc_rate_day_1.TabIndex = 20;
			ciuc_rate_day_1.Title1 = "1-DAY 涨幅最低";
			ciuc_rate_day_1.Title2 = "1-DAY 涨幅最高";
			ciuc_rate_day_1.Value1 = "-11";
			ciuc_rate_day_1.Value2 = "11";
			ciuc_rate_day_1.Visible1 = true;
			ciuc_rate_day_1.Visible2 = true;
			ciuc_rate_day_1.Visible3 = true;
			// 
			// bt_solution_save
			// 
			bt_solution_save.Anchor = AnchorStyles.Bottom;
			bt_solution_save.BackColor = Color.Black;
			bt_solution_save.Font = new Font("Showcard Gothic", 8F, FontStyle.Bold);
			bt_solution_save.Location = new Point(415, 310);
			bt_solution_save.Name = "bt_solution_save";
			bt_solution_save.Size = new Size(111, 23);
			bt_solution_save.TabIndex = 32;
			bt_solution_save.Text = "QUICK LOAD";
			bt_solution_save.UseVisualStyleBackColor = false;
			// 
			// cb_solution
			// 
			cb_solution.Anchor = AnchorStyles.Bottom;
			cb_solution.BackColor = Color.Black;
			cb_solution.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
			cb_solution.ForeColor = Color.LightGray;
			cb_solution.FormattingEnabled = true;
			cb_solution.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
			cb_solution.Location = new Point(361, 310);
			cb_solution.Name = "cb_solution";
			cb_solution.Size = new Size(46, 23);
			cb_solution.TabIndex = 31;
			cb_solution.Text = "1";
			// 
			// bt_solution_4
			// 
			bt_solution_4.BackColor = Color.Black;
			bt_solution_4.Font = new Font("Showcard Gothic", 7F, FontStyle.Bold);
			bt_solution_4.Location = new Point(258, 309);
			bt_solution_4.Name = "bt_solution_4";
			bt_solution_4.Size = new Size(80, 25);
			bt_solution_4.TabIndex = 30;
			bt_solution_4.Text = "SOLUT-4";
			bt_solution_4.UseVisualStyleBackColor = false;
			bt_solution_4.Click += SolutionQuickLoad;
			// 
			// bt_solution_3
			// 
			bt_solution_3.BackColor = Color.Black;
			bt_solution_3.Font = new Font("Showcard Gothic", 7F, FontStyle.Bold);
			bt_solution_3.Location = new Point(172, 309);
			bt_solution_3.Name = "bt_solution_3";
			bt_solution_3.Size = new Size(80, 25);
			bt_solution_3.TabIndex = 29;
			bt_solution_3.Text = "SOLUT-3";
			bt_solution_3.UseVisualStyleBackColor = false;
			bt_solution_3.Click += SolutionQuickLoad;
			// 
			// bt_solution_2
			// 
			bt_solution_2.BackColor = Color.Black;
			bt_solution_2.Font = new Font("Showcard Gothic", 7F, FontStyle.Bold);
			bt_solution_2.Location = new Point(90, 309);
			bt_solution_2.Name = "bt_solution_2";
			bt_solution_2.Size = new Size(80, 25);
			bt_solution_2.TabIndex = 28;
			bt_solution_2.Text = "SOLUT-2";
			bt_solution_2.UseVisualStyleBackColor = false;
			bt_solution_2.Click += SolutionQuickLoad;
			// 
			// bt_solution_1
			// 
			bt_solution_1.BackColor = Color.Black;
			bt_solution_1.Font = new Font("Showcard Gothic", 7F, FontStyle.Bold);
			bt_solution_1.Location = new Point(6, 309);
			bt_solution_1.Name = "bt_solution_1";
			bt_solution_1.Size = new Size(80, 25);
			bt_solution_1.TabIndex = 27;
			bt_solution_1.Text = "SOLUT-1";
			bt_solution_1.UseVisualStyleBackColor = false;
			bt_solution_1.Click += SolutionQuickLoad;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(soluc_0);
			groupBox1.Font = new Font("Showcard Gothic", 12F, FontStyle.Bold);
			groupBox1.ForeColor = Color.LightGray;
			groupBox1.Location = new Point(547, 392);
			groupBox1.Margin = new Padding(0);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(0);
			groupBox1.Size = new Size(426, 277);
			groupBox1.TabIndex = 6;
			groupBox1.TabStop = false;
			groupBox1.Text = "ANALYZE TOTAL";
			// 
			// soluc_0
			// 
			soluc_0.BackColor = Color.Transparent;
			soluc_0.Data = null;
			soluc_0.EditMode = false;
			soluc_0.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			soluc_0.ForeColor = Color.LightGray;
			soluc_0.ID = 0;
			soluc_0.LastDay = 0;
			soluc_0.Location = new Point(1, 20);
			soluc_0.Margin = new Padding(0);
			soluc_0.Name = "soluc_0";
			soluc_0.Size = new Size(420, 238);
			soluc_0.TabIndex = 18;
			// 
			// lb_target_name_2
			// 
			lb_target_name_2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			lb_target_name_2.AutoSize = true;
			lb_target_name_2.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			lb_target_name_2.ForeColor = Color.LightGray;
			lb_target_name_2.Location = new Point(111, 156);
			lb_target_name_2.Margin = new Padding(0);
			lb_target_name_2.Name = "lb_target_name_2";
			lb_target_name_2.Size = new Size(150, 18);
			lb_target_name_2.TabIndex = 23;
			lb_target_name_2.Text = "-";
			lb_target_name_2.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lb_target_id_2
			// 
			lb_target_id_2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			lb_target_id_2.AutoSize = true;
			lb_target_id_2.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			lb_target_id_2.ForeColor = Color.LightGray;
			lb_target_id_2.Location = new Point(0, 156);
			lb_target_id_2.Margin = new Padding(0);
			lb_target_id_2.Name = "lb_target_id_2";
			lb_target_id_2.Size = new Size(111, 18);
			lb_target_id_2.TabIndex = 22;
			lb_target_id_2.Text = "000000";
			lb_target_id_2.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lb_target_id_1
			// 
			lb_target_id_1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			lb_target_id_1.AutoSize = true;
			lb_target_id_1.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			lb_target_id_1.ForeColor = Color.LightGray;
			lb_target_id_1.Location = new Point(0, 126);
			lb_target_id_1.Margin = new Padding(0);
			lb_target_id_1.Name = "lb_target_id_1";
			lb_target_id_1.Size = new Size(111, 18);
			lb_target_id_1.TabIndex = 20;
			lb_target_id_1.Text = "000000";
			lb_target_id_1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// uc_ratio
			// 
			uc_ratio.BackColor = Color.Transparent;
			uc_ratio.Font = new Font("Showcard Gothic", 8F, FontStyle.Bold);
			uc_ratio.Location = new Point(0, 29);
			uc_ratio.Margin = new Padding(0);
			uc_ratio.Name = "uc_ratio";
			uc_ratio.Size = new Size(250, 360);
			uc_ratio.TabIndex = 0;
			// 
			// lv_filter_result
			// 
			lv_filter_result.BackColor = Color.FromArgb(30, 30, 30);
			lv_filter_result.Columns.AddRange(new ColumnHeader[] { columnHeader11, columnHeader12, columnHeader14, columnHeader15, columnHeader16, columnHeader17, columnHeader18, columnHeader13 });
			lv_filter_result.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
			lv_filter_result.ForeColor = Color.LightGray;
			lv_filter_result.FullRowSelect = true;
			lv_filter_result.Location = new Point(547, 672);
			lv_filter_result.Name = "lv_filter_result";
			lv_filter_result.Size = new Size(706, 339);
			lv_filter_result.TabIndex = 10;
			lv_filter_result.UseCompatibleStateImageBehavior = false;
			lv_filter_result.View = View.Details;
			lv_filter_result.ColumnClick += lv_filter_result_ColumnClick;
			// 
			// columnHeader11
			// 
			columnHeader11.Text = "ID";
			// 
			// columnHeader12
			// 
			columnHeader12.Text = "NAME";
			columnHeader12.TextAlign = HorizontalAlignment.Center;
			columnHeader12.Width = 80;
			// 
			// columnHeader14
			// 
			columnHeader14.Text = "D-1 RATIO";
			columnHeader14.TextAlign = HorizontalAlignment.Center;
			columnHeader14.Width = 90;
			// 
			// columnHeader15
			// 
			columnHeader15.Text = "D-2 RATIO";
			columnHeader15.TextAlign = HorizontalAlignment.Center;
			columnHeader15.Width = 90;
			// 
			// columnHeader16
			// 
			columnHeader16.Text = "D-3 RATIO";
			columnHeader16.TextAlign = HorizontalAlignment.Center;
			columnHeader16.Width = 90;
			// 
			// columnHeader17
			// 
			columnHeader17.Text = "D-4 RATIO";
			columnHeader17.TextAlign = HorizontalAlignment.Center;
			columnHeader17.Width = 90;
			// 
			// columnHeader18
			// 
			columnHeader18.Text = "D-5 RATIO";
			columnHeader18.TextAlign = HorizontalAlignment.Center;
			columnHeader18.Width = 90;
			// 
			// columnHeader13
			// 
			columnHeader13.Text = "D-6 RATIO";
			columnHeader13.TextAlign = HorizontalAlignment.Center;
			columnHeader13.Width = 90;
			// 
			// label15
			// 
			label15.AutoSize = true;
			label15.Font = new Font("Showcard Gothic", 12F, FontStyle.Bold);
			label15.ForeColor = Color.LightGray;
			label15.Location = new Point(799, 4);
			label15.Name = "label15";
			label15.Size = new Size(212, 20);
			label15.TabIndex = 9;
			label15.Text = "ANALYZE DAYS DETAILS";
			// 
			// lv_analyze_details
			// 
			lv_analyze_details.BackColor = Color.FromArgb(30, 30, 30);
			lv_analyze_details.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader10, columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader8, columnHeader9, columnHeader19 });
			lv_analyze_details.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
			lv_analyze_details.ForeColor = Color.LightGray;
			lv_analyze_details.FullRowSelect = true;
			lv_analyze_details.Location = new Point(800, 29);
			lv_analyze_details.Name = "lv_analyze_details";
			lv_analyze_details.Size = new Size(724, 360);
			lv_analyze_details.TabIndex = 8;
			lv_analyze_details.UseCompatibleStateImageBehavior = false;
			lv_analyze_details.View = View.Details;
			lv_analyze_details.ColumnClick += lv_analyze_details_ColumnClick;
			// 
			// columnHeader1
			// 
			columnHeader1.Text = "ID";
			// 
			// columnHeader2
			// 
			columnHeader2.Text = "NAME";
			columnHeader2.TextAlign = HorizontalAlignment.Center;
			columnHeader2.Width = 75;
			// 
			// columnHeader3
			// 
			columnHeader3.Text = "START DAY";
			columnHeader3.TextAlign = HorizontalAlignment.Center;
			columnHeader3.Width = 90;
			// 
			// columnHeader10
			// 
			columnHeader10.Text = "CHECK DAY";
			columnHeader10.TextAlign = HorizontalAlignment.Center;
			columnHeader10.Width = 90;
			// 
			// columnHeader4
			// 
			columnHeader4.Text = "DAY-1";
			columnHeader4.TextAlign = HorizontalAlignment.Center;
			columnHeader4.Width = 55;
			// 
			// columnHeader5
			// 
			columnHeader5.Text = "DAY-2";
			columnHeader5.TextAlign = HorizontalAlignment.Center;
			columnHeader5.Width = 55;
			// 
			// columnHeader6
			// 
			columnHeader6.Text = "DAY-3";
			columnHeader6.TextAlign = HorizontalAlignment.Center;
			columnHeader6.Width = 55;
			// 
			// columnHeader7
			// 
			columnHeader7.Text = "DAY-4";
			columnHeader7.TextAlign = HorizontalAlignment.Center;
			columnHeader7.Width = 55;
			// 
			// columnHeader8
			// 
			columnHeader8.Text = "DAY-5";
			columnHeader8.TextAlign = HorizontalAlignment.Center;
			columnHeader8.Width = 55;
			// 
			// columnHeader9
			// 
			columnHeader9.Text = "DAY-6";
			columnHeader9.TextAlign = HorizontalAlignment.Center;
			columnHeader9.Width = 55;
			// 
			// columnHeader19
			// 
			columnHeader19.Text = "DAY-7";
			columnHeader19.TextAlign = HorizontalAlignment.Center;
			columnHeader19.Width = 55;
			// 
			// panel2
			// 
			panel2.Controls.Add(groupBox3);
			panel2.Controls.Add(groupBox2);
			panel2.Controls.Add(groupBox7);
			panel2.Controls.Add(panel1);
			panel2.Controls.Add(lv_filter_result);
			panel2.Controls.Add(groupBox4);
			panel2.Controls.Add(bg_days);
			panel2.Controls.Add(label15);
			panel2.Controls.Add(lv_analyze_details);
			panel2.Controls.Add(groupBox1);
			panel2.Location = new Point(0, 0);
			panel2.Margin = new Padding(0);
			panel2.Name = "panel2";
			panel2.Size = new Size(1892, 1014);
			panel2.TabIndex = 1;
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(tableLayoutPanel1);
			groupBox3.Font = new Font("Showcard Gothic", 12F, FontStyle.Bold);
			groupBox3.ForeColor = Color.LightGray;
			groupBox3.Location = new Point(976, 392);
			groupBox3.Margin = new Padding(0);
			groupBox3.Name = "groupBox3";
			groupBox3.Padding = new Padding(0);
			groupBox3.Size = new Size(277, 277);
			groupBox3.TabIndex = 28;
			groupBox3.TabStop = false;
			groupBox3.Text = "Random BOX";
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
			tableLayoutPanel1.Controls.Add(label4, 0, 0);
			tableLayoutPanel1.Controls.Add(label5, 0, 1);
			tableLayoutPanel1.Controls.Add(lb_today_count, 1, 0);
			tableLayoutPanel1.Controls.Add(lb_today_space, 1, 1);
			tableLayoutPanel1.Controls.Add(label9, 0, 3);
			tableLayoutPanel1.Controls.Add(label10, 1, 3);
			tableLayoutPanel1.Controls.Add(lb_target_id_1, 0, 4);
			tableLayoutPanel1.Controls.Add(lb_target_name_1, 1, 4);
			tableLayoutPanel1.Controls.Add(lb_target_id_2, 0, 5);
			tableLayoutPanel1.Controls.Add(lb_target_name_2, 1, 5);
			tableLayoutPanel1.Controls.Add(lb_target_id_3, 0, 6);
			tableLayoutPanel1.Controls.Add(lb_target_name_3, 1, 6);
			tableLayoutPanel1.Controls.Add(lb_target_id_4, 0, 7);
			tableLayoutPanel1.Controls.Add(lb_target_name_4, 1, 7);
			tableLayoutPanel1.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			tableLayoutPanel1.Location = new Point(8, 31);
			tableLayoutPanel1.Margin = new Padding(0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 8;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
			tableLayoutPanel1.Size = new Size(261, 240);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// label4
			// 
			label4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			label4.AutoSize = true;
			label4.Location = new Point(3, 6);
			label4.Name = "label4";
			label4.Size = new Size(105, 18);
			label4.TabIndex = 36;
			label4.Text = "COUNT";
			label4.TextAlign = ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			label5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			label5.AutoSize = true;
			label5.Location = new Point(3, 36);
			label5.Name = "label5";
			label5.Size = new Size(105, 18);
			label5.TabIndex = 37;
			label5.Text = "SPACE";
			label5.TextAlign = ContentAlignment.MiddleRight;
			// 
			// lb_today_count
			// 
			lb_today_count.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			lb_today_count.AutoSize = true;
			lb_today_count.Location = new Point(114, 6);
			lb_today_count.Name = "lb_today_count";
			lb_today_count.Size = new Size(144, 18);
			lb_today_count.TabIndex = 38;
			lb_today_count.Text = "999";
			lb_today_count.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// lb_today_space
			// 
			lb_today_space.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			lb_today_space.AutoSize = true;
			lb_today_space.Location = new Point(114, 36);
			lb_today_space.Name = "lb_today_space";
			lb_today_space.Size = new Size(144, 18);
			lb_today_space.TabIndex = 39;
			lb_today_space.Text = "4";
			lb_today_space.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			label9.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			label9.AutoSize = true;
			label9.Location = new Point(3, 96);
			label9.Name = "label9";
			label9.Size = new Size(105, 18);
			label9.TabIndex = 29;
			label9.Text = "ID";
			label9.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// label10
			// 
			label10.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			label10.AutoSize = true;
			label10.Location = new Point(114, 96);
			label10.Name = "label10";
			label10.Size = new Size(144, 18);
			label10.TabIndex = 30;
			label10.Text = "NAME";
			label10.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lb_target_name_1
			// 
			lb_target_name_1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			lb_target_name_1.AutoSize = true;
			lb_target_name_1.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			lb_target_name_1.ForeColor = Color.LightGray;
			lb_target_name_1.Location = new Point(111, 126);
			lb_target_name_1.Margin = new Padding(0);
			lb_target_name_1.Name = "lb_target_name_1";
			lb_target_name_1.Size = new Size(150, 18);
			lb_target_name_1.TabIndex = 27;
			lb_target_name_1.Text = "-";
			lb_target_name_1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lb_target_id_3
			// 
			lb_target_id_3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			lb_target_id_3.AutoSize = true;
			lb_target_id_3.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			lb_target_id_3.ForeColor = Color.LightGray;
			lb_target_id_3.Location = new Point(0, 186);
			lb_target_id_3.Margin = new Padding(0);
			lb_target_id_3.Name = "lb_target_id_3";
			lb_target_id_3.Size = new Size(111, 18);
			lb_target_id_3.TabIndex = 24;
			lb_target_id_3.Text = "000000";
			lb_target_id_3.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lb_target_name_3
			// 
			lb_target_name_3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			lb_target_name_3.AutoSize = true;
			lb_target_name_3.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			lb_target_name_3.ForeColor = Color.LightGray;
			lb_target_name_3.Location = new Point(111, 186);
			lb_target_name_3.Margin = new Padding(0);
			lb_target_name_3.Name = "lb_target_name_3";
			lb_target_name_3.Size = new Size(150, 18);
			lb_target_name_3.TabIndex = 25;
			lb_target_name_3.Text = "-";
			lb_target_name_3.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lb_target_id_4
			// 
			lb_target_id_4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			lb_target_id_4.AutoSize = true;
			lb_target_id_4.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			lb_target_id_4.ForeColor = Color.LightGray;
			lb_target_id_4.Location = new Point(0, 216);
			lb_target_id_4.Margin = new Padding(0);
			lb_target_id_4.Name = "lb_target_id_4";
			lb_target_id_4.Size = new Size(111, 18);
			lb_target_id_4.TabIndex = 28;
			lb_target_id_4.Text = "000000";
			lb_target_id_4.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lb_target_name_4
			// 
			lb_target_name_4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			lb_target_name_4.AutoSize = true;
			lb_target_name_4.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			lb_target_name_4.ForeColor = Color.LightGray;
			lb_target_name_4.Location = new Point(111, 216);
			lb_target_name_4.Margin = new Padding(0);
			lb_target_name_4.Name = "lb_target_name_4";
			lb_target_name_4.Size = new Size(150, 18);
			lb_target_name_4.TabIndex = 26;
			lb_target_name_4.Text = "-";
			lb_target_name_4.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(tabControl2);
			groupBox2.Controls.Add(cb_solution);
			groupBox2.Controls.Add(bt_solution_save);
			groupBox2.Controls.Add(bt_solution_1);
			groupBox2.Controls.Add(bt_solution_4);
			groupBox2.Controls.Add(bt_solution_3);
			groupBox2.Controls.Add(bt_solution_2);
			groupBox2.Font = new Font("Showcard Gothic", 12F, FontStyle.Bold);
			groupBox2.ForeColor = Color.LightGray;
			groupBox2.Location = new Point(10, 672);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(532, 339);
			groupBox2.TabIndex = 17;
			groupBox2.TabStop = false;
			groupBox2.Text = "SOLUTIONS";
			// 
			// tabControl2
			// 
			tabControl2.Controls.Add(tabPage13);
			tabControl2.Controls.Add(tabPage14);
			tabControl2.Controls.Add(tabPage15);
			tabControl2.Controls.Add(tabPage16);
			tabControl2.Controls.Add(tabPage17);
			tabControl2.Controls.Add(tabPage18);
			tabControl2.Controls.Add(tabPage19);
			tabControl2.Controls.Add(tabPage20);
			tabControl2.Controls.Add(tabPage21);
			tabControl2.Controls.Add(tabPage22);
			tabControl2.Controls.Add(tabPage23);
			tabControl2.Controls.Add(tabPage24);
			tabControl2.Controls.Add(tabPage25);
			tabControl2.Controls.Add(tabPage26);
			tabControl2.Controls.Add(tabPage27);
			tabControl2.Controls.Add(tabPage28);
			tabControl2.Controls.Add(tabPage29);
			tabControl2.Controls.Add(tabPage30);
			tabControl2.Controls.Add(tabPage31);
			tabControl2.Controls.Add(tabPage32);
			tabControl2.Location = new Point(6, 26);
			tabControl2.Name = "tabControl2";
			tabControl2.SelectedIndex = 0;
			tabControl2.Size = new Size(520, 280);
			tabControl2.TabIndex = 0;
			// 
			// tabPage13
			// 
			tabPage13.BackColor = Color.FromArgb(30, 30, 30);
			tabPage13.BackgroundImageLayout = ImageLayout.Center;
			tabPage13.Controls.Add(soluc_1);
			tabPage13.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			tabPage13.Location = new Point(4, 29);
			tabPage13.Margin = new Padding(0);
			tabPage13.Name = "tabPage13";
			tabPage13.Padding = new Padding(3);
			tabPage13.Size = new Size(512, 247);
			tabPage13.TabIndex = 0;
			tabPage13.Text = "SOLUTION-1";
			// 
			// soluc_1
			// 
			soluc_1.BackColor = Color.Transparent;
			soluc_1.BorderStyle = BorderStyle.FixedSingle;
			soluc_1.Data = null;
			soluc_1.EditMode = false;
			soluc_1.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			soluc_1.ForeColor = Color.LightGray;
			soluc_1.ID = 1;
			soluc_1.LastDay = 0;
			soluc_1.Location = new Point(0, 0);
			soluc_1.Margin = new Padding(0);
			soluc_1.Name = "soluc_1";
			soluc_1.Size = new Size(510, 247);
			soluc_1.TabIndex = 0;
			// 
			// tabPage14
			// 
			tabPage14.BackColor = Color.FromArgb(30, 30, 30);
			tabPage14.BackgroundImageLayout = ImageLayout.Center;
			tabPage14.Controls.Add(soluc_2);
			tabPage14.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			tabPage14.Location = new Point(4, 29);
			tabPage14.Margin = new Padding(0);
			tabPage14.Name = "tabPage14";
			tabPage14.Padding = new Padding(3);
			tabPage14.Size = new Size(512, 247);
			tabPage14.TabIndex = 1;
			tabPage14.Text = "SOLUTION-2";
			// 
			// soluc_2
			// 
			soluc_2.BackColor = Color.Transparent;
			soluc_2.BorderStyle = BorderStyle.FixedSingle;
			soluc_2.Data = null;
			soluc_2.EditMode = false;
			soluc_2.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			soluc_2.ForeColor = Color.LightGray;
			soluc_2.ID = 2;
			soluc_2.LastDay = 0;
			soluc_2.Location = new Point(0, 0);
			soluc_2.Margin = new Padding(0);
			soluc_2.Name = "soluc_2";
			soluc_2.Size = new Size(515, 255);
			soluc_2.TabIndex = 1;
			// 
			// tabPage15
			// 
			tabPage15.BackColor = Color.FromArgb(30, 30, 30);
			tabPage15.BackgroundImageLayout = ImageLayout.Center;
			tabPage15.Controls.Add(soluc_3);
			tabPage15.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			tabPage15.Location = new Point(4, 29);
			tabPage15.Margin = new Padding(0);
			tabPage15.Name = "tabPage15";
			tabPage15.Size = new Size(512, 247);
			tabPage15.TabIndex = 2;
			tabPage15.Text = "SOLUTION-3";
			// 
			// soluc_3
			// 
			soluc_3.BackColor = Color.Transparent;
			soluc_3.BorderStyle = BorderStyle.FixedSingle;
			soluc_3.Data = null;
			soluc_3.EditMode = false;
			soluc_3.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			soluc_3.ForeColor = Color.LightGray;
			soluc_3.ID = 3;
			soluc_3.LastDay = 0;
			soluc_3.Location = new Point(0, 0);
			soluc_3.Margin = new Padding(0);
			soluc_3.Name = "soluc_3";
			soluc_3.Size = new Size(515, 255);
			soluc_3.TabIndex = 2;
			// 
			// tabPage16
			// 
			tabPage16.BackColor = Color.FromArgb(30, 30, 30);
			tabPage16.BackgroundImageLayout = ImageLayout.Center;
			tabPage16.Controls.Add(soluc_4);
			tabPage16.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			tabPage16.Location = new Point(4, 29);
			tabPage16.Margin = new Padding(0);
			tabPage16.Name = "tabPage16";
			tabPage16.Size = new Size(512, 247);
			tabPage16.TabIndex = 3;
			tabPage16.Text = "SOLUTION-4";
			// 
			// soluc_4
			// 
			soluc_4.BackColor = Color.Transparent;
			soluc_4.BorderStyle = BorderStyle.FixedSingle;
			soluc_4.Data = null;
			soluc_4.EditMode = false;
			soluc_4.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			soluc_4.ForeColor = Color.LightGray;
			soluc_4.ID = 4;
			soluc_4.LastDay = 0;
			soluc_4.Location = new Point(0, 0);
			soluc_4.Margin = new Padding(0);
			soluc_4.Name = "soluc_4";
			soluc_4.Size = new Size(515, 255);
			soluc_4.TabIndex = 2;
			// 
			// tabPage17
			// 
			tabPage17.BackColor = Color.FromArgb(30, 30, 30);
			tabPage17.BackgroundImageLayout = ImageLayout.Center;
			tabPage17.Controls.Add(soluc_5);
			tabPage17.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			tabPage17.Location = new Point(4, 29);
			tabPage17.Margin = new Padding(0);
			tabPage17.Name = "tabPage17";
			tabPage17.Size = new Size(512, 247);
			tabPage17.TabIndex = 4;
			tabPage17.Text = "SOLUTION-5";
			// 
			// soluc_5
			// 
			soluc_5.BackColor = Color.Transparent;
			soluc_5.BorderStyle = BorderStyle.FixedSingle;
			soluc_5.Data = null;
			soluc_5.EditMode = false;
			soluc_5.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			soluc_5.ForeColor = Color.LightGray;
			soluc_5.ID = 5;
			soluc_5.LastDay = 0;
			soluc_5.Location = new Point(0, 0);
			soluc_5.Margin = new Padding(0);
			soluc_5.Name = "soluc_5";
			soluc_5.Size = new Size(515, 255);
			soluc_5.TabIndex = 2;
			// 
			// tabPage18
			// 
			tabPage18.BackColor = Color.FromArgb(30, 30, 30);
			tabPage18.BackgroundImageLayout = ImageLayout.Center;
			tabPage18.Controls.Add(soluc_6);
			tabPage18.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			tabPage18.Location = new Point(4, 29);
			tabPage18.Margin = new Padding(0);
			tabPage18.Name = "tabPage18";
			tabPage18.Size = new Size(512, 247);
			tabPage18.TabIndex = 5;
			tabPage18.Text = "SOLUTION-6";
			// 
			// soluc_6
			// 
			soluc_6.BackColor = Color.Transparent;
			soluc_6.BorderStyle = BorderStyle.FixedSingle;
			soluc_6.Data = null;
			soluc_6.EditMode = false;
			soluc_6.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			soluc_6.ForeColor = Color.LightGray;
			soluc_6.ID = 6;
			soluc_6.LastDay = 0;
			soluc_6.Location = new Point(0, 0);
			soluc_6.Margin = new Padding(0);
			soluc_6.Name = "soluc_6";
			soluc_6.Size = new Size(515, 255);
			soluc_6.TabIndex = 2;
			// 
			// tabPage19
			// 
			tabPage19.BackColor = Color.FromArgb(30, 30, 30);
			tabPage19.BackgroundImageLayout = ImageLayout.Center;
			tabPage19.Controls.Add(soluc_7);
			tabPage19.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			tabPage19.Location = new Point(4, 29);
			tabPage19.Margin = new Padding(0);
			tabPage19.Name = "tabPage19";
			tabPage19.Size = new Size(512, 247);
			tabPage19.TabIndex = 6;
			tabPage19.Text = "SOLUTION-7";
			// 
			// soluc_7
			// 
			soluc_7.BackColor = Color.Transparent;
			soluc_7.BorderStyle = BorderStyle.FixedSingle;
			soluc_7.Data = null;
			soluc_7.EditMode = false;
			soluc_7.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			soluc_7.ForeColor = Color.LightGray;
			soluc_7.ID = 7;
			soluc_7.LastDay = 0;
			soluc_7.Location = new Point(0, 0);
			soluc_7.Margin = new Padding(0);
			soluc_7.Name = "soluc_7";
			soluc_7.Size = new Size(515, 255);
			soluc_7.TabIndex = 2;
			// 
			// tabPage20
			// 
			tabPage20.BackColor = Color.FromArgb(30, 30, 30);
			tabPage20.BackgroundImageLayout = ImageLayout.Center;
			tabPage20.Controls.Add(soluc_8);
			tabPage20.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			tabPage20.Location = new Point(4, 29);
			tabPage20.Margin = new Padding(0);
			tabPage20.Name = "tabPage20";
			tabPage20.Size = new Size(512, 247);
			tabPage20.TabIndex = 7;
			tabPage20.Text = "SOLUTION-8";
			// 
			// soluc_8
			// 
			soluc_8.BackColor = Color.Transparent;
			soluc_8.BorderStyle = BorderStyle.FixedSingle;
			soluc_8.Data = null;
			soluc_8.EditMode = false;
			soluc_8.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			soluc_8.ForeColor = Color.LightGray;
			soluc_8.ID = 8;
			soluc_8.LastDay = 0;
			soluc_8.Location = new Point(0, 0);
			soluc_8.Margin = new Padding(0);
			soluc_8.Name = "soluc_8";
			soluc_8.Size = new Size(515, 255);
			soluc_8.TabIndex = 2;
			// 
			// tabPage21
			// 
			tabPage21.BackColor = Color.FromArgb(30, 30, 30);
			tabPage21.BackgroundImageLayout = ImageLayout.Center;
			tabPage21.Controls.Add(soluc_9);
			tabPage21.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			tabPage21.Location = new Point(4, 29);
			tabPage21.Margin = new Padding(0);
			tabPage21.Name = "tabPage21";
			tabPage21.Size = new Size(512, 247);
			tabPage21.TabIndex = 8;
			tabPage21.Text = "SOLUTION-9";
			// 
			// soluc_9
			// 
			soluc_9.BackColor = Color.Transparent;
			soluc_9.BorderStyle = BorderStyle.FixedSingle;
			soluc_9.Data = null;
			soluc_9.EditMode = false;
			soluc_9.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			soluc_9.ForeColor = Color.LightGray;
			soluc_9.ID = 9;
			soluc_9.LastDay = 0;
			soluc_9.Location = new Point(0, 0);
			soluc_9.Margin = new Padding(0);
			soluc_9.Name = "soluc_9";
			soluc_9.Size = new Size(515, 255);
			soluc_9.TabIndex = 2;
			// 
			// tabPage22
			// 
			tabPage22.BackColor = Color.FromArgb(30, 30, 30);
			tabPage22.BackgroundImageLayout = ImageLayout.Center;
			tabPage22.Controls.Add(soluc_10);
			tabPage22.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			tabPage22.Location = new Point(4, 29);
			tabPage22.Margin = new Padding(0);
			tabPage22.Name = "tabPage22";
			tabPage22.Size = new Size(512, 247);
			tabPage22.TabIndex = 9;
			tabPage22.Text = "SOLUTION-10";
			// 
			// soluc_10
			// 
			soluc_10.BackColor = Color.Transparent;
			soluc_10.BorderStyle = BorderStyle.FixedSingle;
			soluc_10.Data = null;
			soluc_10.EditMode = false;
			soluc_10.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			soluc_10.ForeColor = Color.LightGray;
			soluc_10.ID = 10;
			soluc_10.LastDay = 0;
			soluc_10.Location = new Point(0, 0);
			soluc_10.Margin = new Padding(0);
			soluc_10.Name = "soluc_10";
			soluc_10.Size = new Size(515, 255);
			soluc_10.TabIndex = 2;
			// 
			// tabPage23
			// 
			tabPage23.BackColor = Color.FromArgb(30, 30, 30);
			tabPage23.BackgroundImageLayout = ImageLayout.Center;
			tabPage23.Controls.Add(soluc_11);
			tabPage23.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			tabPage23.Location = new Point(4, 29);
			tabPage23.Margin = new Padding(0);
			tabPage23.Name = "tabPage23";
			tabPage23.Size = new Size(512, 247);
			tabPage23.TabIndex = 10;
			tabPage23.Text = "SOLUTION-11";
			// 
			// soluc_11
			// 
			soluc_11.BackColor = Color.Transparent;
			soluc_11.BorderStyle = BorderStyle.FixedSingle;
			soluc_11.Data = null;
			soluc_11.EditMode = false;
			soluc_11.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			soluc_11.ForeColor = Color.LightGray;
			soluc_11.ID = 11;
			soluc_11.LastDay = 0;
			soluc_11.Location = new Point(0, 0);
			soluc_11.Margin = new Padding(0);
			soluc_11.Name = "soluc_11";
			soluc_11.Size = new Size(515, 255);
			soluc_11.TabIndex = 2;
			// 
			// tabPage24
			// 
			tabPage24.BackColor = Color.FromArgb(30, 30, 30);
			tabPage24.BackgroundImageLayout = ImageLayout.Center;
			tabPage24.Controls.Add(soluc_12);
			tabPage24.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			tabPage24.Location = new Point(4, 29);
			tabPage24.Margin = new Padding(0);
			tabPage24.Name = "tabPage24";
			tabPage24.Size = new Size(512, 247);
			tabPage24.TabIndex = 11;
			tabPage24.Text = "SOLUTION-12";
			// 
			// soluc_12
			// 
			soluc_12.BackColor = Color.Transparent;
			soluc_12.BorderStyle = BorderStyle.FixedSingle;
			soluc_12.Data = null;
			soluc_12.EditMode = false;
			soluc_12.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			soluc_12.ForeColor = Color.LightGray;
			soluc_12.ID = 12;
			soluc_12.LastDay = 0;
			soluc_12.Location = new Point(0, 0);
			soluc_12.Margin = new Padding(0);
			soluc_12.Name = "soluc_12";
			soluc_12.Size = new Size(515, 255);
			soluc_12.TabIndex = 2;
			// 
			// tabPage25
			// 
			tabPage25.BackColor = Color.FromArgb(30, 30, 30);
			tabPage25.BackgroundImageLayout = ImageLayout.Center;
			tabPage25.Controls.Add(soluc_13);
			tabPage25.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			tabPage25.Location = new Point(4, 29);
			tabPage25.Margin = new Padding(0);
			tabPage25.Name = "tabPage25";
			tabPage25.Size = new Size(512, 247);
			tabPage25.TabIndex = 12;
			tabPage25.Text = "SOLUTION-13";
			// 
			// soluc_13
			// 
			soluc_13.BackColor = Color.Transparent;
			soluc_13.BorderStyle = BorderStyle.FixedSingle;
			soluc_13.Data = null;
			soluc_13.EditMode = false;
			soluc_13.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			soluc_13.ForeColor = Color.LightGray;
			soluc_13.ID = 13;
			soluc_13.LastDay = 0;
			soluc_13.Location = new Point(0, 0);
			soluc_13.Margin = new Padding(0);
			soluc_13.Name = "soluc_13";
			soluc_13.Size = new Size(515, 255);
			soluc_13.TabIndex = 2;
			// 
			// tabPage26
			// 
			tabPage26.BackColor = Color.FromArgb(30, 30, 30);
			tabPage26.BackgroundImageLayout = ImageLayout.Center;
			tabPage26.Controls.Add(soluc_14);
			tabPage26.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			tabPage26.Location = new Point(4, 29);
			tabPage26.Margin = new Padding(0);
			tabPage26.Name = "tabPage26";
			tabPage26.Size = new Size(512, 247);
			tabPage26.TabIndex = 13;
			tabPage26.Text = "SOLUTION-14";
			// 
			// soluc_14
			// 
			soluc_14.BackColor = Color.Transparent;
			soluc_14.BorderStyle = BorderStyle.FixedSingle;
			soluc_14.Data = null;
			soluc_14.EditMode = false;
			soluc_14.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			soluc_14.ForeColor = Color.LightGray;
			soluc_14.ID = 14;
			soluc_14.LastDay = 0;
			soluc_14.Location = new Point(0, 0);
			soluc_14.Margin = new Padding(0);
			soluc_14.Name = "soluc_14";
			soluc_14.Size = new Size(515, 255);
			soluc_14.TabIndex = 2;
			// 
			// tabPage27
			// 
			tabPage27.BackColor = Color.FromArgb(30, 30, 30);
			tabPage27.BackgroundImageLayout = ImageLayout.Center;
			tabPage27.Controls.Add(soluc_15);
			tabPage27.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			tabPage27.Location = new Point(4, 29);
			tabPage27.Margin = new Padding(0);
			tabPage27.Name = "tabPage27";
			tabPage27.Size = new Size(512, 247);
			tabPage27.TabIndex = 14;
			tabPage27.Text = "SOLUTION-15";
			// 
			// soluc_15
			// 
			soluc_15.BackColor = Color.Transparent;
			soluc_15.BorderStyle = BorderStyle.FixedSingle;
			soluc_15.Data = null;
			soluc_15.EditMode = false;
			soluc_15.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			soluc_15.ForeColor = Color.LightGray;
			soluc_15.ID = 15;
			soluc_15.LastDay = 0;
			soluc_15.Location = new Point(0, 0);
			soluc_15.Margin = new Padding(0);
			soluc_15.Name = "soluc_15";
			soluc_15.Size = new Size(515, 255);
			soluc_15.TabIndex = 2;
			// 
			// tabPage28
			// 
			tabPage28.BackColor = Color.FromArgb(30, 30, 30);
			tabPage28.BackgroundImageLayout = ImageLayout.Center;
			tabPage28.Controls.Add(soluc_16);
			tabPage28.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			tabPage28.Location = new Point(4, 29);
			tabPage28.Margin = new Padding(0);
			tabPage28.Name = "tabPage28";
			tabPage28.Size = new Size(512, 247);
			tabPage28.TabIndex = 15;
			tabPage28.Text = "SOLUTION-16";
			// 
			// soluc_16
			// 
			soluc_16.BackColor = Color.Transparent;
			soluc_16.BorderStyle = BorderStyle.FixedSingle;
			soluc_16.Data = null;
			soluc_16.EditMode = false;
			soluc_16.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			soluc_16.ForeColor = Color.LightGray;
			soluc_16.ID = 16;
			soluc_16.LastDay = 0;
			soluc_16.Location = new Point(0, 0);
			soluc_16.Margin = new Padding(0);
			soluc_16.Name = "soluc_16";
			soluc_16.Size = new Size(515, 255);
			soluc_16.TabIndex = 2;
			// 
			// tabPage29
			// 
			tabPage29.BackColor = Color.FromArgb(30, 30, 30);
			tabPage29.BackgroundImageLayout = ImageLayout.Center;
			tabPage29.Controls.Add(soluc_17);
			tabPage29.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			tabPage29.Location = new Point(4, 29);
			tabPage29.Margin = new Padding(0);
			tabPage29.Name = "tabPage29";
			tabPage29.Size = new Size(512, 247);
			tabPage29.TabIndex = 16;
			tabPage29.Text = "SOLUTION-17";
			// 
			// soluc_17
			// 
			soluc_17.BackColor = Color.Transparent;
			soluc_17.BorderStyle = BorderStyle.FixedSingle;
			soluc_17.Data = null;
			soluc_17.EditMode = false;
			soluc_17.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			soluc_17.ForeColor = Color.LightGray;
			soluc_17.ID = 17;
			soluc_17.LastDay = 0;
			soluc_17.Location = new Point(0, 0);
			soluc_17.Margin = new Padding(0);
			soluc_17.Name = "soluc_17";
			soluc_17.Size = new Size(515, 255);
			soluc_17.TabIndex = 2;
			// 
			// tabPage30
			// 
			tabPage30.BackColor = Color.FromArgb(30, 30, 30);
			tabPage30.BackgroundImageLayout = ImageLayout.Center;
			tabPage30.Controls.Add(soluc_18);
			tabPage30.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			tabPage30.Location = new Point(4, 29);
			tabPage30.Margin = new Padding(0);
			tabPage30.Name = "tabPage30";
			tabPage30.Size = new Size(512, 247);
			tabPage30.TabIndex = 17;
			tabPage30.Text = "SOLUTION-18";
			// 
			// soluc_18
			// 
			soluc_18.BackColor = Color.Transparent;
			soluc_18.BorderStyle = BorderStyle.FixedSingle;
			soluc_18.Data = null;
			soluc_18.EditMode = false;
			soluc_18.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			soluc_18.ForeColor = Color.LightGray;
			soluc_18.ID = 18;
			soluc_18.LastDay = 0;
			soluc_18.Location = new Point(0, 0);
			soluc_18.Margin = new Padding(0);
			soluc_18.Name = "soluc_18";
			soluc_18.Size = new Size(515, 255);
			soluc_18.TabIndex = 2;
			// 
			// tabPage31
			// 
			tabPage31.BackColor = Color.FromArgb(30, 30, 30);
			tabPage31.BackgroundImageLayout = ImageLayout.Center;
			tabPage31.Controls.Add(soluc_19);
			tabPage31.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			tabPage31.Location = new Point(4, 29);
			tabPage31.Margin = new Padding(0);
			tabPage31.Name = "tabPage31";
			tabPage31.Size = new Size(512, 247);
			tabPage31.TabIndex = 18;
			tabPage31.Text = "SOLUTION-19";
			// 
			// soluc_19
			// 
			soluc_19.BackColor = Color.Transparent;
			soluc_19.BorderStyle = BorderStyle.FixedSingle;
			soluc_19.Data = null;
			soluc_19.EditMode = false;
			soluc_19.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			soluc_19.ForeColor = Color.LightGray;
			soluc_19.ID = 19;
			soluc_19.LastDay = 0;
			soluc_19.Location = new Point(0, 0);
			soluc_19.Margin = new Padding(0);
			soluc_19.Name = "soluc_19";
			soluc_19.Size = new Size(515, 255);
			soluc_19.TabIndex = 2;
			// 
			// tabPage32
			// 
			tabPage32.BackColor = Color.FromArgb(30, 30, 30);
			tabPage32.BackgroundImageLayout = ImageLayout.Center;
			tabPage32.Controls.Add(soluc_20);
			tabPage32.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			tabPage32.Location = new Point(4, 29);
			tabPage32.Margin = new Padding(0);
			tabPage32.Name = "tabPage32";
			tabPage32.Size = new Size(512, 247);
			tabPage32.TabIndex = 19;
			tabPage32.Text = "SOLUTION-20";
			// 
			// soluc_20
			// 
			soluc_20.BackColor = Color.Transparent;
			soluc_20.BorderStyle = BorderStyle.FixedSingle;
			soluc_20.Data = null;
			soluc_20.EditMode = false;
			soluc_20.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold);
			soluc_20.ForeColor = Color.LightGray;
			soluc_20.ID = 20;
			soluc_20.LastDay = 0;
			soluc_20.Location = new Point(0, 0);
			soluc_20.Margin = new Padding(0);
			soluc_20.Name = "soluc_20";
			soluc_20.Size = new Size(515, 255);
			soluc_20.TabIndex = 2;
			// 
			// panel1
			// 
			panel1.BorderStyle = BorderStyle.FixedSingle;
			panel1.Controls.Add(tb_last_day);
			panel1.Controls.Add(tb_first_day);
			panel1.Controls.Add(uc_ratio);
			panel1.Controls.Add(bt_analyze);
			panel1.Location = new Point(547, 0);
			panel1.Margin = new Padding(0);
			panel1.Name = "panel1";
			panel1.Size = new Size(250, 389);
			panel1.TabIndex = 16;
			// 
			// tb_last_day
			// 
			tb_last_day.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			tb_last_day.BackColor = Color.Black;
			tb_last_day.BorderStyle = BorderStyle.FixedSingle;
			tb_last_day.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
			tb_last_day.ForeColor = Color.White;
			tb_last_day.Location = new Point(87, 3);
			tb_last_day.Margin = new Padding(0);
			tb_last_day.Name = "tb_last_day";
			tb_last_day.Size = new Size(80, 22);
			tb_last_day.TabIndex = 4;
			tb_last_day.TextAlign = HorizontalAlignment.Center;
			// 
			// tb_first_day
			// 
			tb_first_day.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			tb_first_day.BackColor = Color.Black;
			tb_first_day.BorderStyle = BorderStyle.FixedSingle;
			tb_first_day.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
			tb_first_day.ForeColor = Color.White;
			tb_first_day.Location = new Point(0, 3);
			tb_first_day.Margin = new Padding(0);
			tb_first_day.Name = "tb_first_day";
			tb_first_day.Size = new Size(80, 22);
			tb_first_day.TabIndex = 3;
			tb_first_day.TextAlign = HorizontalAlignment.Center;
			// 
			// groupBox4
			// 
			groupBox4.Controls.Add(gb_conditions);
			groupBox4.Font = new Font("Showcard Gothic", 12F, FontStyle.Bold);
			groupBox4.ForeColor = Color.LightGray;
			groupBox4.Location = new Point(10, 153);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new Size(532, 515);
			groupBox4.TabIndex = 1;
			groupBox4.TabStop = false;
			groupBox4.Text = "CONDITIONS";
			// 
			// gb_conditions
			// 
			gb_conditions.Controls.Add(tabPage1);
			gb_conditions.Controls.Add(tabPage2);
			gb_conditions.Controls.Add(tabPage3);
			gb_conditions.Controls.Add(tabPage4);
			gb_conditions.Location = new Point(6, 22);
			gb_conditions.Name = "gb_conditions";
			gb_conditions.SelectedIndex = 0;
			gb_conditions.Size = new Size(520, 488);
			gb_conditions.TabIndex = 38;
			// 
			// tabPage1
			// 
			tabPage1.BackColor = Color.Black;
			tabPage1.Controls.Add(groupBox6);
			tabPage1.Controls.Add(ciuc_rate_day_0);
			tabPage1.Controls.Add(ciuc_rate_day_1);
			tabPage1.Controls.Add(ciuc_rate_day_2);
			tabPage1.Controls.Add(ciuc_rate_day_3);
			tabPage1.Controls.Add(ciuc_rate_day_6);
			tabPage1.Controls.Add(ciuc_rate_day_4);
			tabPage1.Controls.Add(ciuc_rate_day_5);
			tabPage1.Location = new Point(4, 29);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new Padding(3);
			tabPage1.Size = new Size(512, 455);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "RATE";
			// 
			// groupBox6
			// 
			groupBox6.Controls.Add(rbtn_top_status_none);
			groupBox6.Controls.Add(rbtn_top_status_low);
			groupBox6.Controls.Add(rbtn_top_status_high);
			groupBox6.ForeColor = Color.LightGray;
			groupBox6.Location = new Point(9, 224);
			groupBox6.Name = "groupBox6";
			groupBox6.Size = new Size(494, 69);
			groupBox6.TabIndex = 36;
			groupBox6.TabStop = false;
			groupBox6.Text = "TOP STATUS";
			// 
			// rbtn_top_status_none
			// 
			rbtn_top_status_none.AutoSize = true;
			rbtn_top_status_none.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
			rbtn_top_status_none.Location = new Point(215, 31);
			rbtn_top_status_none.Name = "rbtn_top_status_none";
			rbtn_top_status_none.Size = new Size(63, 19);
			rbtn_top_status_none.TabIndex = 2;
			rbtn_top_status_none.TabStop = true;
			rbtn_top_status_none.Text = "NONE";
			rbtn_top_status_none.UseVisualStyleBackColor = true;
			// 
			// rbtn_top_status_low
			// 
			rbtn_top_status_low.AutoSize = true;
			rbtn_top_status_low.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
			rbtn_top_status_low.Location = new Point(116, 31);
			rbtn_top_status_low.Name = "rbtn_top_status_low";
			rbtn_top_status_low.Size = new Size(64, 19);
			rbtn_top_status_low.TabIndex = 1;
			rbtn_top_status_low.TabStop = true;
			rbtn_top_status_low.Text = "有跌停";
			rbtn_top_status_low.UseVisualStyleBackColor = true;
			// 
			// rbtn_top_status_high
			// 
			rbtn_top_status_high.AutoSize = true;
			rbtn_top_status_high.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
			rbtn_top_status_high.Location = new Point(17, 31);
			rbtn_top_status_high.Name = "rbtn_top_status_high";
			rbtn_top_status_high.Size = new Size(64, 19);
			rbtn_top_status_high.TabIndex = 0;
			rbtn_top_status_high.TabStop = true;
			rbtn_top_status_high.Text = "有涨停";
			rbtn_top_status_high.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			tabPage2.BackColor = Color.Black;
			tabPage2.Controls.Add(tb_functions);
			tabPage2.Location = new Point(4, 29);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new Padding(3);
			tabPage2.Size = new Size(512, 455);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "FUNCTION";
			// 
			// tabPage3
			// 
			tabPage3.BackColor = Color.Black;
			tabPage3.Controls.Add(ciuc_market_value);
			tabPage3.Controls.Add(groupBox5);
			tabPage3.Location = new Point(4, 29);
			tabPage3.Name = "tabPage3";
			tabPage3.Size = new Size(512, 455);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "Value";
			// 
			// groupBox5
			// 
			groupBox5.Controls.Add(rbtn_average_value_none);
			groupBox5.Controls.Add(rbtn_average_value_low);
			groupBox5.Controls.Add(rbtn_average_value_high);
			groupBox5.ForeColor = Color.White;
			groupBox5.Location = new Point(10, 7);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new Size(493, 62);
			groupBox5.TabIndex = 0;
			groupBox5.TabStop = false;
			groupBox5.Text = "average value";
			// 
			// rbtn_average_value_none
			// 
			rbtn_average_value_none.AutoSize = true;
			rbtn_average_value_none.Checked = true;
			rbtn_average_value_none.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
			rbtn_average_value_none.Location = new Point(237, 26);
			rbtn_average_value_none.Name = "rbtn_average_value_none";
			rbtn_average_value_none.Size = new Size(63, 19);
			rbtn_average_value_none.TabIndex = 2;
			rbtn_average_value_none.TabStop = true;
			rbtn_average_value_none.Text = "NONE";
			rbtn_average_value_none.UseVisualStyleBackColor = true;
			// 
			// rbtn_average_value_low
			// 
			rbtn_average_value_low.AutoSize = true;
			rbtn_average_value_low.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
			rbtn_average_value_low.Location = new Point(136, 26);
			rbtn_average_value_low.Name = "rbtn_average_value_low";
			rbtn_average_value_low.Size = new Size(55, 19);
			rbtn_average_value_low.TabIndex = 1;
			rbtn_average_value_low.TabStop = true;
			rbtn_average_value_low.Text = "LOW";
			rbtn_average_value_low.UseVisualStyleBackColor = true;
			// 
			// rbtn_average_value_high
			// 
			rbtn_average_value_high.AutoSize = true;
			rbtn_average_value_high.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
			rbtn_average_value_high.Location = new Point(30, 26);
			rbtn_average_value_high.Name = "rbtn_average_value_high";
			rbtn_average_value_high.Size = new Size(60, 19);
			rbtn_average_value_high.TabIndex = 0;
			rbtn_average_value_high.TabStop = true;
			rbtn_average_value_high.Text = "HIGH";
			rbtn_average_value_high.UseVisualStyleBackColor = true;
			// 
			// tabPage4
			// 
			tabPage4.BackColor = Color.Black;
			tabPage4.Controls.Add(label1);
			tabPage4.Controls.Add(ciuc_trade_buy_5);
			tabPage4.Controls.Add(ciuc_trade_buy_6);
			tabPage4.Controls.Add(ciuc_trade_buy_4);
			tabPage4.Controls.Add(ciuc_trade_buy_3);
			tabPage4.Controls.Add(ciuc_trade_buy_2);
			tabPage4.Controls.Add(ciuc_trade_buy_1);
			tabPage4.Controls.Add(ciuc_trade_buy_0);
			tabPage4.Location = new Point(4, 29);
			tabPage4.Name = "tabPage4";
			tabPage4.Size = new Size(512, 455);
			tabPage4.TabIndex = 3;
			tabPage4.Text = "TRADE";
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			label1.AutoSize = true;
			label1.Location = new Point(6, 228);
			label1.Name = "label1";
			label1.Size = new Size(109, 20);
			label1.TabIndex = 42;
			label1.Text = "×100,0000万";
			label1.TextAlign = ContentAlignment.MiddleRight;
			// 
			// ciuc_trade_buy_5
			// 
			ciuc_trade_buy_5.BackColor = Color.Transparent;
			ciuc_trade_buy_5.Day = "6";
			ciuc_trade_buy_5.Font = new Font("Showcard Gothic", 8F, FontStyle.Bold);
			ciuc_trade_buy_5.ForeColor = Color.LightGray;
			ciuc_trade_buy_5.Location = new Point(0, 162);
			ciuc_trade_buy_5.Margin = new Padding(0);
			ciuc_trade_buy_5.Name = "ciuc_trade_buy_5";
			ciuc_trade_buy_5.RateStatus = 0;
			ciuc_trade_buy_5.Size = new Size(512, 30);
			ciuc_trade_buy_5.TabIndex = 41;
			ciuc_trade_buy_5.Title1 = "5-DAY 买量最低";
			ciuc_trade_buy_5.Title2 = "5-DAY 买量最高";
			ciuc_trade_buy_5.Value1 = "-11";
			ciuc_trade_buy_5.Value2 = "11";
			ciuc_trade_buy_5.Visible1 = true;
			ciuc_trade_buy_5.Visible2 = true;
			ciuc_trade_buy_5.Visible3 = true;
			// 
			// ciuc_trade_buy_6
			// 
			ciuc_trade_buy_6.BackColor = Color.Transparent;
			ciuc_trade_buy_6.Day = "6";
			ciuc_trade_buy_6.Font = new Font("Showcard Gothic", 8F, FontStyle.Bold);
			ciuc_trade_buy_6.ForeColor = Color.LightGray;
			ciuc_trade_buy_6.Location = new Point(0, 192);
			ciuc_trade_buy_6.Margin = new Padding(0);
			ciuc_trade_buy_6.Name = "ciuc_trade_buy_6";
			ciuc_trade_buy_6.RateStatus = 0;
			ciuc_trade_buy_6.Size = new Size(512, 30);
			ciuc_trade_buy_6.TabIndex = 40;
			ciuc_trade_buy_6.Title1 = "6-DAY 买量最低";
			ciuc_trade_buy_6.Title2 = "6-DAY 买量最高";
			ciuc_trade_buy_6.Value1 = "-11";
			ciuc_trade_buy_6.Value2 = "11";
			ciuc_trade_buy_6.Visible1 = true;
			ciuc_trade_buy_6.Visible2 = true;
			ciuc_trade_buy_6.Visible3 = true;
			// 
			// ciuc_trade_buy_4
			// 
			ciuc_trade_buy_4.BackColor = Color.Transparent;
			ciuc_trade_buy_4.Day = "6";
			ciuc_trade_buy_4.Font = new Font("Showcard Gothic", 8F, FontStyle.Bold);
			ciuc_trade_buy_4.ForeColor = Color.LightGray;
			ciuc_trade_buy_4.Location = new Point(0, 132);
			ciuc_trade_buy_4.Margin = new Padding(0);
			ciuc_trade_buy_4.Name = "ciuc_trade_buy_4";
			ciuc_trade_buy_4.RateStatus = 0;
			ciuc_trade_buy_4.Size = new Size(512, 30);
			ciuc_trade_buy_4.TabIndex = 39;
			ciuc_trade_buy_4.Title1 = "4-DAY 买量最低";
			ciuc_trade_buy_4.Title2 = "4-DAY 买量最高";
			ciuc_trade_buy_4.Value1 = "-11";
			ciuc_trade_buy_4.Value2 = "11";
			ciuc_trade_buy_4.Visible1 = true;
			ciuc_trade_buy_4.Visible2 = true;
			ciuc_trade_buy_4.Visible3 = true;
			// 
			// ciuc_trade_buy_3
			// 
			ciuc_trade_buy_3.BackColor = Color.Transparent;
			ciuc_trade_buy_3.Day = "6";
			ciuc_trade_buy_3.Font = new Font("Showcard Gothic", 8F, FontStyle.Bold);
			ciuc_trade_buy_3.ForeColor = Color.LightGray;
			ciuc_trade_buy_3.Location = new Point(0, 102);
			ciuc_trade_buy_3.Margin = new Padding(0);
			ciuc_trade_buy_3.Name = "ciuc_trade_buy_3";
			ciuc_trade_buy_3.RateStatus = 0;
			ciuc_trade_buy_3.Size = new Size(512, 30);
			ciuc_trade_buy_3.TabIndex = 38;
			ciuc_trade_buy_3.Title1 = "3-DAY 买量最低";
			ciuc_trade_buy_3.Title2 = "3-DAY 买量最高";
			ciuc_trade_buy_3.Value1 = "-11";
			ciuc_trade_buy_3.Value2 = "11";
			ciuc_trade_buy_3.Visible1 = true;
			ciuc_trade_buy_3.Visible2 = true;
			ciuc_trade_buy_3.Visible3 = true;
			// 
			// ciuc_trade_buy_2
			// 
			ciuc_trade_buy_2.BackColor = Color.Transparent;
			ciuc_trade_buy_2.Day = "6";
			ciuc_trade_buy_2.Font = new Font("Showcard Gothic", 8F, FontStyle.Bold);
			ciuc_trade_buy_2.ForeColor = Color.LightGray;
			ciuc_trade_buy_2.Location = new Point(0, 72);
			ciuc_trade_buy_2.Margin = new Padding(0);
			ciuc_trade_buy_2.Name = "ciuc_trade_buy_2";
			ciuc_trade_buy_2.RateStatus = 0;
			ciuc_trade_buy_2.Size = new Size(512, 30);
			ciuc_trade_buy_2.TabIndex = 37;
			ciuc_trade_buy_2.Title1 = "2-DAY 买量最低";
			ciuc_trade_buy_2.Title2 = "2-DAY 买量最高";
			ciuc_trade_buy_2.Value1 = "-11";
			ciuc_trade_buy_2.Value2 = "11";
			ciuc_trade_buy_2.Visible1 = true;
			ciuc_trade_buy_2.Visible2 = true;
			ciuc_trade_buy_2.Visible3 = true;
			// 
			// ciuc_trade_buy_1
			// 
			ciuc_trade_buy_1.BackColor = Color.Transparent;
			ciuc_trade_buy_1.Day = "6";
			ciuc_trade_buy_1.Font = new Font("Showcard Gothic", 8F, FontStyle.Bold);
			ciuc_trade_buy_1.ForeColor = Color.LightGray;
			ciuc_trade_buy_1.Location = new Point(0, 42);
			ciuc_trade_buy_1.Margin = new Padding(0);
			ciuc_trade_buy_1.Name = "ciuc_trade_buy_1";
			ciuc_trade_buy_1.RateStatus = 0;
			ciuc_trade_buy_1.Size = new Size(512, 30);
			ciuc_trade_buy_1.TabIndex = 36;
			ciuc_trade_buy_1.Title1 = "1-DAY 买量最低";
			ciuc_trade_buy_1.Title2 = "1-DAY 买量最高";
			ciuc_trade_buy_1.Value1 = "-11";
			ciuc_trade_buy_1.Value2 = "11";
			ciuc_trade_buy_1.Visible1 = true;
			ciuc_trade_buy_1.Visible2 = true;
			ciuc_trade_buy_1.Visible3 = true;
			// 
			// ciuc_trade_buy_0
			// 
			ciuc_trade_buy_0.BackColor = Color.Transparent;
			ciuc_trade_buy_0.Day = "6";
			ciuc_trade_buy_0.Font = new Font("Showcard Gothic", 8F, FontStyle.Bold);
			ciuc_trade_buy_0.ForeColor = Color.LightGray;
			ciuc_trade_buy_0.Location = new Point(0, 12);
			ciuc_trade_buy_0.Margin = new Padding(0);
			ciuc_trade_buy_0.Name = "ciuc_trade_buy_0";
			ciuc_trade_buy_0.RateStatus = 0;
			ciuc_trade_buy_0.Size = new Size(512, 30);
			ciuc_trade_buy_0.TabIndex = 35;
			ciuc_trade_buy_0.Title1 = "N-DAY 买量最低";
			ciuc_trade_buy_0.Title2 = "N-DAY 买量最高";
			ciuc_trade_buy_0.Value1 = "-11";
			ciuc_trade_buy_0.Value2 = "11";
			ciuc_trade_buy_0.Visible1 = true;
			ciuc_trade_buy_0.Visible2 = true;
			ciuc_trade_buy_0.Visible3 = true;
			// 
			// ciuc_market_value
			// 
			ciuc_market_value.BackColor = Color.FromArgb(30, 30, 30);
			ciuc_market_value.Day = "N";
			ciuc_market_value.Font = new Font("Showcard Gothic", 8F, FontStyle.Bold);
			ciuc_market_value.ForeColor = Color.LightGray;
			ciuc_market_value.Location = new Point(-1, 72);
			ciuc_market_value.Margin = new Padding(0);
			ciuc_market_value.Name = "ciuc_market_value";
			ciuc_market_value.RateStatus = 0;
			ciuc_market_value.Size = new Size(512, 31);
			ciuc_market_value.TabIndex = 1;
			ciuc_market_value.Title1 = "Market low";
			ciuc_market_value.Title2 = "market high";
			ciuc_market_value.Value1 = "";
			ciuc_market_value.Value2 = "";
			ciuc_market_value.Visible1 = true;
			ciuc_market_value.Visible2 = true;
			ciuc_market_value.Visible3 = false;
			// 
			// MainUserControl
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(30, 30, 30);
			Controls.Add(panel2);
			Margin = new Padding(0);
			Name = "MainUserControl";
			Size = new Size(1892, 1014);
			Load += MainUserControl_Load;
			groupBox7.ResumeLayout(false);
			groupBox7.PerformLayout();
			bg_days.ResumeLayout(false);
			bg_days.PerformLayout();
			groupBox1.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			groupBox3.ResumeLayout(false);
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			groupBox2.ResumeLayout(false);
			tabControl2.ResumeLayout(false);
			tabPage13.ResumeLayout(false);
			tabPage14.ResumeLayout(false);
			tabPage15.ResumeLayout(false);
			tabPage16.ResumeLayout(false);
			tabPage17.ResumeLayout(false);
			tabPage18.ResumeLayout(false);
			tabPage19.ResumeLayout(false);
			tabPage20.ResumeLayout(false);
			tabPage21.ResumeLayout(false);
			tabPage22.ResumeLayout(false);
			tabPage23.ResumeLayout(false);
			tabPage24.ResumeLayout(false);
			tabPage25.ResumeLayout(false);
			tabPage26.ResumeLayout(false);
			tabPage27.ResumeLayout(false);
			tabPage28.ResumeLayout(false);
			tabPage29.ResumeLayout(false);
			tabPage30.ResumeLayout(false);
			tabPage31.ResumeLayout(false);
			tabPage32.ResumeLayout(false);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			groupBox4.ResumeLayout(false);
			gb_conditions.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			groupBox6.ResumeLayout(false);
			groupBox6.PerformLayout();
			tabPage2.ResumeLayout(false);
			tabPage2.PerformLayout();
			tabPage3.ResumeLayout(false);
			groupBox5.ResumeLayout(false);
			groupBox5.PerformLayout();
			tabPage4.ResumeLayout(false);
			tabPage4.PerformLayout();
			ResumeLayout(false);
		}

		#endregion
		private GroupBox bg_days;
		private RadioButton rbtn_day5;
		private RadioButton rbtn_day4;
		private RadioButton rbtn_day3;
		private Button bt_analyze;
		private GroupBox groupBox7;
		private CheckBox cb_plate_st;
		private CheckBox cb_plate_beijing;
		private CheckBox cb_plate_chuangye;
		private CheckBox cb_plate_kechuang;
		private CheckBox cb_plate_shenzhen;
		private CheckBox cb_plate_shanghai;
		private RatioUserControl uc_ratio;
		private GroupBox groupBox1;
		private ListView lv_analyze_details;
		private Label label15;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private ColumnHeader columnHeader3;
		private ColumnHeader columnHeader4;
		private ColumnHeader columnHeader5;
		private ColumnHeader columnHeader6;
		private ColumnHeader columnHeader7;
		private ColumnHeader columnHeader8;
		private ColumnHeader columnHeader9;
		private ColumnHeader columnHeader10;
		private ConfigInputUserControl ciuc_rate_day_1;
		private ConfigInputUserControl ciuc_rate_day_2;
		private ConfigInputUserControl ciuc_rate_day_5;
		private ConfigInputUserControl ciuc_rate_day_4;
		private ConfigInputUserControl ciuc_rate_day_3;
		private Button bt_solution_4;
		private Button bt_solution_3;
		private Button bt_solution_2;
		private Button bt_solution_1;
		private Button bt_solution_save;
		private ComboBox cb_solution;
		private ConfigInputUserControl ciuc_rate_day_6;
		private ConfigInputUserControl ciuc_rate_day_0;
		private ListView lv_filter_result;
		private ColumnHeader columnHeader11;
		private ColumnHeader columnHeader12;
		private ColumnHeader columnHeader14;
		private ColumnHeader columnHeader15;
		private ColumnHeader columnHeader16;
		private ColumnHeader columnHeader17;
		private ColumnHeader columnHeader18;
		private Panel panel2;
		private Panel panel1;
		private RadioButton rbtn_day6;
		private GroupBox groupBox2;
		private TabControl tabControl2;
		private TabPage tabPage13;
		private TabPage tabPage14;
		private TabPage tabPage15;
		private TabPage tabPage16;
		private TabPage tabPage17;
		private TabPage tabPage18;
		private TabPage tabPage19;
		private TabPage tabPage20;
		private TabPage tabPage21;
		private TabPage tabPage22;
		private TabPage tabPage23;
		private TabPage tabPage24;
		private TabPage tabPage25;
		private TabPage tabPage26;
		private TabPage tabPage27;
		private TabPage tabPage28;
		private TabPage tabPage29;
		private TabPage tabPage30;
		private TabPage tabPage31;
		private TabPage tabPage32;
		private TextBox tb_functions;
		private SolutionUserControl soluc_1;
		private SolutionUserControl soluc_2;
		private SolutionUserControl soluc_3;
		private SolutionUserControl soluc_4;
		private SolutionUserControl soluc_5;
		private SolutionUserControl soluc_6;
		private SolutionUserControl soluc_7;
		private SolutionUserControl soluc_8;
		private SolutionUserControl soluc_9;
		private SolutionUserControl soluc_10;
		private SolutionUserControl soluc_11;
		private SolutionUserControl soluc_12;
		private SolutionUserControl soluc_13;
		private SolutionUserControl soluc_14;
		private SolutionUserControl soluc_15;
		private SolutionUserControl soluc_16;
		private SolutionUserControl soluc_17;
		private SolutionUserControl soluc_18;
		private SolutionUserControl soluc_19;
		private SolutionUserControl soluc_20;
		private ColumnHeader columnHeader19;
		private SolutionUserControl soluc_0;
		private Label lb_target_name_2;
		private Label lb_target_id_2;
		private Label lb_target_id_1;
		private TextBox tb_random_max;
		private Label lb_target_name_1;
		private Label lb_target_name_4;
		private Label lb_target_name_3;
		private Label lb_target_id_3;
		private GroupBox groupBox3;
		private TableLayoutPanel tableLayoutPanel1;
		private ColumnHeader columnHeader13;
		private Label lb_target_id_4;
		private Label label9;
		private Label label10;
		private Label label4;
		private Label label5;
		private Label lb_today_count;
		private Label lb_today_space;
		private TextBox tb_first_day;
		private TextBox tb_last_day;
		private GroupBox groupBox4;
		private TabControl gb_conditions;
		private TabPage tabPage1;
		private TabPage tabPage2;
		private TabPage tabPage3;
		private GroupBox groupBox5;
		private RadioButton rbtn_average_value_none;
		private RadioButton rbtn_average_value_low;
		private RadioButton rbtn_average_value_high;
		private GroupBox groupBox6;
		private RadioButton rbtn_top_status_none;
		private RadioButton rbtn_top_status_low;
		private RadioButton rbtn_top_status_high;
		private TabPage tabPage4;
		private ConfigInputUserControl ciuc_trade_buy_0;
		private ConfigInputUserControl ciuc_trade_buy_5;
		private ConfigInputUserControl ciuc_trade_buy_6;
		private ConfigInputUserControl ciuc_trade_buy_4;
		private ConfigInputUserControl ciuc_trade_buy_3;
		private ConfigInputUserControl ciuc_trade_buy_2;
		private ConfigInputUserControl ciuc_trade_buy_1;
		private Label label1;
		private ConfigInputUserControl ciuc_market_value;
	}
}

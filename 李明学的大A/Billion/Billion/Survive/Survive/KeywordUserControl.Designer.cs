namespace Survive
{
	partial class KeywordUserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lv_no1_days = new ListView();
            btn_no1_generate = new Button();
            tb_no1_input = new TextBox();
            tb_no1_output = new TextBox();
            gb_key1 = new GroupBox();
            cb_no1_keys = new ComboBox();
            gb_key2 = new GroupBox();
            cb_no2_keys = new ComboBox();
            lv_no2_days = new ListView();
            tb_no2_input = new TextBox();
            tb_no2_output = new TextBox();
            btn_no2_generate = new Button();
            tb_days = new TextBox();
            btn_load = new Button();
            label1 = new Label();
            gb_key1.SuspendLayout();
            gb_key2.SuspendLayout();
            SuspendLayout();
            // 
            // lv_no1_days
            // 
            lv_no1_days.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lv_no1_days.BackColor = Color.FromArgb(30, 30, 30);
            lv_no1_days.Font = new Font("文悦新青年体 (非商用) W8", 11.9999981F, FontStyle.Bold);
            lv_no1_days.ForeColor = Color.LightGray;
            lv_no1_days.FullRowSelect = true;
            lv_no1_days.Location = new Point(8, 83);
            lv_no1_days.Margin = new Padding(4);
            lv_no1_days.Name = "lv_no1_days";
            lv_no1_days.Size = new Size(246, 205);
            lv_no1_days.TabIndex = 0;
            lv_no1_days.UseCompatibleStateImageBehavior = false;
            lv_no1_days.View = View.Details;
            // 
            // btn_no1_generate
            // 
            btn_no1_generate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_no1_generate.BackColor = Color.FromArgb(30, 30, 30);
            btn_no1_generate.Font = new Font("文悦新青年体 (非商用) W8", 14F, FontStyle.Bold);
            btn_no1_generate.Location = new Point(261, 241);
            btn_no1_generate.Margin = new Padding(4);
            btn_no1_generate.Name = "btn_no1_generate";
            btn_no1_generate.Size = new Size(210, 47);
            btn_no1_generate.TabIndex = 10;
            btn_no1_generate.Text = "GENERATE";
            btn_no1_generate.UseVisualStyleBackColor = false;
            btn_no1_generate.Click += btn_no1_generate_Click;
            // 
            // tb_no1_input
            // 
            tb_no1_input.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            tb_no1_input.BackColor = Color.FromArgb(30, 30, 30);
            tb_no1_input.Font = new Font("文悦新青年体 (非商用) W8", 11.9999981F, FontStyle.Bold);
            tb_no1_input.ForeColor = Color.LightGray;
            tb_no1_input.Location = new Point(261, 33);
            tb_no1_input.Margin = new Padding(4);
            tb_no1_input.Multiline = true;
            tb_no1_input.Name = "tb_no1_input";
            tb_no1_input.Size = new Size(210, 201);
            tb_no1_input.TabIndex = 11;
            // 
            // tb_no1_output
            // 
            tb_no1_output.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tb_no1_output.BackColor = Color.FromArgb(30, 30, 30);
            tb_no1_output.Font = new Font("文悦新青年体 (非商用) W8", 11.9999981F, FontStyle.Bold);
            tb_no1_output.ForeColor = Color.LightGray;
            tb_no1_output.Location = new Point(479, 32);
            tb_no1_output.Margin = new Padding(4);
            tb_no1_output.Multiline = true;
            tb_no1_output.Name = "tb_no1_output";
            tb_no1_output.Size = new Size(238, 256);
            tb_no1_output.TabIndex = 13;
            // 
            // gb_key1
            // 
            gb_key1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gb_key1.Controls.Add(cb_no1_keys);
            gb_key1.Controls.Add(lv_no1_days);
            gb_key1.Controls.Add(tb_no1_input);
            gb_key1.Controls.Add(tb_no1_output);
            gb_key1.Controls.Add(btn_no1_generate);
            gb_key1.Font = new Font("文悦新青年体 (非商用) W8", 14F, FontStyle.Bold);
            gb_key1.ForeColor = Color.LightGray;
            gb_key1.Location = new Point(224, 4);
            gb_key1.Margin = new Padding(4);
            gb_key1.Name = "gb_key1";
            gb_key1.Padding = new Padding(4);
            gb_key1.Size = new Size(725, 298);
            gb_key1.TabIndex = 14;
            gb_key1.TabStop = false;
            gb_key1.Text = "KEY 1";
            // 
            // cb_no1_keys
            // 
            cb_no1_keys.BackColor = Color.FromArgb(30, 30, 30);
            cb_no1_keys.ForeColor = Color.LightGray;
            cb_no1_keys.FormattingEnabled = true;
            cb_no1_keys.Location = new Point(7, 33);
            cb_no1_keys.Name = "cb_no1_keys";
            cb_no1_keys.Size = new Size(246, 43);
            cb_no1_keys.TabIndex = 14;
            cb_no1_keys.SelectedValueChanged += cb_no1_keys_SelectedValueChanged;
            // 
            // gb_key2
            // 
            gb_key2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            gb_key2.Controls.Add(cb_no2_keys);
            gb_key2.Controls.Add(lv_no2_days);
            gb_key2.Controls.Add(tb_no2_input);
            gb_key2.Controls.Add(tb_no2_output);
            gb_key2.Controls.Add(btn_no2_generate);
            gb_key2.Font = new Font("文悦新青年体 (非商用) W8", 14F, FontStyle.Bold);
            gb_key2.ForeColor = Color.LightGray;
            gb_key2.Location = new Point(224, 310);
            gb_key2.Margin = new Padding(4);
            gb_key2.Name = "gb_key2";
            gb_key2.Padding = new Padding(4);
            gb_key2.Size = new Size(725, 288);
            gb_key2.TabIndex = 15;
            gb_key2.TabStop = false;
            gb_key2.Text = "KEY 2";
            // 
            // cb_no2_keys
            // 
            cb_no2_keys.BackColor = Color.FromArgb(30, 30, 30);
            cb_no2_keys.ForeColor = Color.LightGray;
            cb_no2_keys.FormattingEnabled = true;
            cb_no2_keys.Location = new Point(9, 34);
            cb_no2_keys.Name = "cb_no2_keys";
            cb_no2_keys.Size = new Size(245, 43);
            cb_no2_keys.TabIndex = 15;
            cb_no2_keys.SelectedValueChanged += cb_no2_keys_SelectedValueChanged;
            // 
            // lv_no2_days
            // 
            lv_no2_days.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lv_no2_days.BackColor = Color.FromArgb(30, 30, 30);
            lv_no2_days.Font = new Font("文悦新青年体 (非商用) W8", 11.9999981F, FontStyle.Bold);
            lv_no2_days.ForeColor = Color.LightGray;
            lv_no2_days.FullRowSelect = true;
            lv_no2_days.Location = new Point(9, 84);
            lv_no2_days.Margin = new Padding(4);
            lv_no2_days.Name = "lv_no2_days";
            lv_no2_days.Size = new Size(244, 196);
            lv_no2_days.TabIndex = 0;
            lv_no2_days.UseCompatibleStateImageBehavior = false;
            lv_no2_days.View = View.Details;
            // 
            // tb_no2_input
            // 
            tb_no2_input.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            tb_no2_input.BackColor = Color.FromArgb(30, 30, 30);
            tb_no2_input.Font = new Font("文悦新青年体 (非商用) W8", 11.9999981F, FontStyle.Bold);
            tb_no2_input.ForeColor = Color.LightGray;
            tb_no2_input.Location = new Point(261, 34);
            tb_no2_input.Margin = new Padding(4);
            tb_no2_input.Multiline = true;
            tb_no2_input.Name = "tb_no2_input";
            tb_no2_input.Size = new Size(210, 191);
            tb_no2_input.TabIndex = 11;
            // 
            // tb_no2_output
            // 
            tb_no2_output.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tb_no2_output.BackColor = Color.FromArgb(30, 30, 30);
            tb_no2_output.Font = new Font("文悦新青年体 (非商用) W8", 11.9999981F, FontStyle.Bold);
            tb_no2_output.ForeColor = Color.LightGray;
            tb_no2_output.Location = new Point(479, 34);
            tb_no2_output.Margin = new Padding(4);
            tb_no2_output.Multiline = true;
            tb_no2_output.Name = "tb_no2_output";
            tb_no2_output.Size = new Size(238, 246);
            tb_no2_output.TabIndex = 13;
            // 
            // btn_no2_generate
            // 
            btn_no2_generate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_no2_generate.BackColor = Color.FromArgb(30, 30, 30);
            btn_no2_generate.Font = new Font("文悦新青年体 (非商用) W8", 14F, FontStyle.Bold);
            btn_no2_generate.Location = new Point(261, 233);
            btn_no2_generate.Margin = new Padding(4);
            btn_no2_generate.Name = "btn_no2_generate";
            btn_no2_generate.Size = new Size(210, 47);
            btn_no2_generate.TabIndex = 10;
            btn_no2_generate.Text = "GENERATE";
            btn_no2_generate.UseVisualStyleBackColor = false;
            btn_no2_generate.Click += btn_no2_generate_Click;
            // 
            // tb_days
            // 
            tb_days.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            tb_days.BackColor = Color.FromArgb(30, 30, 30);
            tb_days.Font = new Font("文悦新青年体 (非商用) W8", 16F, FontStyle.Bold);
            tb_days.ForeColor = Color.LightGray;
            tb_days.Location = new Point(4, 32);
            tb_days.Margin = new Padding(4);
            tb_days.Multiline = true;
            tb_days.Name = "tb_days";
            tb_days.Size = new Size(212, 511);
            tb_days.TabIndex = 17;
            tb_days.TextAlign = HorizontalAlignment.Center;
            // 
            // btn_load
            // 
            btn_load.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_load.BackColor = Color.FromArgb(30, 30, 30);
            btn_load.Font = new Font("文悦新青年体 (非商用) W8", 14F, FontStyle.Bold);
            btn_load.Location = new Point(4, 551);
            btn_load.Margin = new Padding(4);
            btn_load.Name = "btn_load";
            btn_load.Size = new Size(212, 47);
            btn_load.TabIndex = 18;
            btn_load.Text = "LOAD";
            btn_load.UseVisualStyleBackColor = false;
            btn_load.Click += btn_load_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("文悦新青年体 (非商用) W8", 14F, FontStyle.Bold);
            label1.Location = new Point(30, 4);
            label1.Name = "label1";
            label1.Size = new Size(148, 35);
            label1.TabIndex = 19;
            label1.Text = "KEY DAYS";
            // 
            // KeywordUserControl
            // 
            AutoScaleDimensions = new SizeF(14F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(953, 601);
            Controls.Add(label1);
            Controls.Add(btn_load);
            Controls.Add(tb_days);
            Controls.Add(gb_key2);
            Controls.Add(gb_key1);
            Font = new Font("文悦新青年体 (非商用) W8", 11.9999981F, FontStyle.Bold);
            ForeColor = Color.LightGray;
            Margin = new Padding(0);
            Name = "KeywordUserControl";
            Load += KeywordUserControl_Load;
            Resize += KeywordUserControl_Resize;
            gb_key1.ResumeLayout(false);
            gb_key1.PerformLayout();
            gb_key2.ResumeLayout(false);
            gb_key2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox3;
		private GroupBox groupBox2;
		private ListView lv_no1_days;
		private GroupBox groupBox11;
		private GroupBox groupBox5;
		private GroupBox groupBox4;
		private ListView lv_day1_keyday;
		private GroupBox groupBox13;
		private Label label4;
		private ComboBox cbb_trade;
		private Label label3;
		private CheckBox cb_day1_tickettype_nost;
		private CheckBox cb_day1_tickettype_main;
		private RadioButton rbtn_day1_bottom_none;
		private RadioButton rbtn_day1_bottom_no;
		private RadioButton rbtn_day1_bottom_yes;
		private CheckBox cb_day1_linetype_rain2;
		private CheckBox cb_day1_linetype_sun2;
		private CheckBox cb_day1_linetype_rain1;
		private CheckBox cb_day1_linetype_none;
		private CheckBox cb_day1_linetype_sun1;
		private RadioButton rbtn_day1_top_none;
		private RadioButton rbtn_day1_top_no;
		private RadioButton rbtn_day1_top_yes;
		private GroupBox groupBox6;
		private GroupBox groupBox7;
		private CheckBox cb_day2_tickettype_nost;
		private CheckBox cb_day2_tickettype_main;
		private GroupBox groupBox8;
		private RadioButton rbtn_day2_bottom_none;
		private RadioButton rbtn_day2_bottom_no;
		private RadioButton rbtn_day2_bottom_yes;
		private GroupBox groupBox9;
		private ListView lv_day2_keyday;
		private GroupBox groupBox10;
		private CheckBox cb_day2_linetype_rain2;
		private CheckBox cb_day2_linetype_sun2;
		private CheckBox cb_day2_linetype_rain1;
		private CheckBox cb_day2_linetype_none;
		private CheckBox cb_day2_linetype_sun1;
		private GroupBox groupBox12;
		private RadioButton rbtn_day2_top_none;
		private RadioButton rbtn_day2_top_no;
		private RadioButton rbtn_day2_top_yes;
		private ListView lv_day2;
		private Button btn_no1_generate;
		private TextBox tb_no1_input;
		private TextBox tb_no1_output;
		private GroupBox gb_key1;
		private GroupBox gb_key2;
		private ListView lv_no2_days;
		private TextBox tb_no2_input;
		private TextBox tb_no2_output;
		private Button btn_no2_generate;
        private TextBox tb_days;
        private Button btn_load;
        private Label label1;
        private ComboBox cb_no1_keys;
        private ComboBox cb_no2_keys;
    }
}

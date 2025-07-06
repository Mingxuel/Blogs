namespace Survive
{
	partial class ConfigInputUserControl
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
			lb_1 = new Label();
			tb_1 = new TextBox();
			lb_2 = new Label();
			tb_2 = new TextBox();
			rbtn_up = new RadioButton();
			rbtn_down = new RadioButton();
			rbtn_none = new RadioButton();
			SuspendLayout();
			// 
			// lb_1
			// 
			lb_1.AutoSize = true;
			lb_1.ForeColor = Color.LightGray;
			lb_1.Location = new Point(8, 8);
			lb_1.Name = "lb_1";
			lb_1.Size = new Size(102, 14);
			lb_1.TabIndex = 0;
			lb_1.Text = "N-DAY 涨幅最低";
			lb_1.TextAlign = ContentAlignment.MiddleRight;
			// 
			// tb_1
			// 
			tb_1.Location = new Point(113, 5);
			tb_1.Name = "tb_1";
			tb_1.Size = new Size(36, 21);
			tb_1.TabIndex = 1;
			// 
			// lb_2
			// 
			lb_2.AutoSize = true;
			lb_2.ForeColor = Color.LightGray;
			lb_2.Location = new Point(164, 8);
			lb_2.Name = "lb_2";
			lb_2.Size = new Size(102, 14);
			lb_2.TabIndex = 2;
			lb_2.Text = "N-DAY 涨幅最高";
			lb_2.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// tb_2
			// 
			tb_2.Location = new Point(269, 5);
			tb_2.Name = "tb_2";
			tb_2.Size = new Size(36, 21);
			tb_2.TabIndex = 3;
			// 
			// rbtn_up
			// 
			rbtn_up.AutoSize = true;
			rbtn_up.ForeColor = Color.LightGray;
			rbtn_up.Location = new Point(320, 6);
			rbtn_up.Name = "rbtn_up";
			rbtn_up.Size = new Size(42, 18);
			rbtn_up.TabIndex = 4;
			rbtn_up.TabStop = true;
			rbtn_up.Text = "UP";
			rbtn_up.UseVisualStyleBackColor = true;
			rbtn_up.CheckedChanged += CheckChanged;
			// 
			// rbtn_down
			// 
			rbtn_down.AutoSize = true;
			rbtn_down.ForeColor = Color.LightGray;
			rbtn_down.Location = new Point(366, 6);
			rbtn_down.Name = "rbtn_down";
			rbtn_down.Size = new Size(65, 18);
			rbtn_down.TabIndex = 5;
			rbtn_down.TabStop = true;
			rbtn_down.Text = "DOWN";
			rbtn_down.UseVisualStyleBackColor = true;
			rbtn_down.CheckedChanged += CheckChanged;
			// 
			// rbtn_none
			// 
			rbtn_none.AutoSize = true;
			rbtn_none.ForeColor = Color.LightGray;
			rbtn_none.Location = new Point(435, 6);
			rbtn_none.Name = "rbtn_none";
			rbtn_none.Size = new Size(59, 18);
			rbtn_none.TabIndex = 6;
			rbtn_none.TabStop = true;
			rbtn_none.Text = "NONE";
			rbtn_none.UseVisualStyleBackColor = true;
			// 
			// ConfigInputUserControl
			// 
			AutoScaleDimensions = new SizeF(8F, 14F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(30, 30, 30);
			Controls.Add(rbtn_none);
			Controls.Add(rbtn_down);
			Controls.Add(rbtn_up);
			Controls.Add(tb_2);
			Controls.Add(lb_2);
			Controls.Add(tb_1);
			Controls.Add(lb_1);
			Font = new Font("Showcard Gothic", 8F, FontStyle.Bold);
			ForeColor = Color.LightGray;
			Margin = new Padding(0);
			Name = "ConfigInputUserControl";
			Size = new Size(512, 31);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lb_1;
		private TextBox tb_1;
		private Label lb_2;
		private TextBox tb_2;
		private RadioButton rbtn_up;
		private RadioButton rbtn_down;
		private RadioButton rbtn_none;
	}
}

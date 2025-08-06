using System;
using System.Diagnostics;

namespace MyDream
{
    public class Record
    {
        public string? Time { get; set; }
        public string Open { get; set; } = "0.0";
        public string High { get; set; } = "0.0";
		public string Low { get; set; } = "0.0";
		public string Close { get; set; } = "0.0";
		public string Volume { get; set; } = "0.0";
		public string Amount { get; set; } = "0.0";
		public string SettelementPrice { get; set; } = "0.0";
		public string OpenInterest { get; set; } = "0.0";
		public string PreClose { get; set; } = "0.0";
		public string SuspendFlag { get; set; } = "0.0";
		public string Top { get => ConvertToLIMIT(1.1); }
		public string Top1 { get => ConvertToLIMIT(1.2); }
		public string Top2 { get => ConvertToLIMIT(1.3); }
		public string Bottom { get => ConvertToLIMIT(0.9); }
		public string Bottom1 { get => ConvertToLIMIT(0.8); }
		public string Bottom2 { get => ConvertToLIMIT(0.7); }
        public bool IsTop { get => Close == Top; }
		public bool IsTop1 { get => Close == Top1; }
		public bool IsTop2 { get => Close == Top2; }
		public bool IsBottom { get => Close == Bottom; }
		public bool IsBottom1 { get => Close == Bottom1; }
		public bool IsBottom2 { get => Close == Bottom2; }

		private string ConvertToLIMIT(double rate)
		{
			var pre_close = double.Parse(PreClose);
			return Math.Round(Math.Round(pre_close * rate, 3), 2).ToString();
		}
	}
}

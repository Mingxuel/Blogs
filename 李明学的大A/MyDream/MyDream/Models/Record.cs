using System;
using System.Diagnostics;

namespace MyDream
{
    public class Record
    {
        public string? Time { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public double Volume { get; set; }
        public double Amount { get; set; }
        public double SettelementPrice { get; set; }
        public double OpenInterest { get; set; }
        public double PreClose { get; set; }
        public double SuspendFlag { get; set; }
        public double Top { get => Math.Round(Math.Round(PreClose * 1.1, 3), 2); }
        public double Top1 { get => Math.Round(Math.Round(PreClose * 1.2, 3), 2); }
        public double Top2 { get => Math.Round(Math.Round(PreClose * 1.3, 3), 2); }
        public double Bottom { get => Math.Round(Math.Round(PreClose * 0.9, 3), 2); }
        public double Bottom1 { get => Math.Round(Math.Round(PreClose * 0.8, 3), 2); }
        public double Bottom2 { get => Math.Round(Math.Round(PreClose * 0.7, 3), 2); }
        public bool IsTop { get => Math.Abs(Close - Top) < 0.0001; }
		public bool IsTop1 { get => Math.Abs(Close - Top1) < 0.0001; }
		public bool IsTop2 { get => Math.Abs(Close - Top2) < 0.0001; }
		public bool IsBottom { get => Math.Abs(Close - Bottom) < 0.0001; }
		public bool IsBottom1 { get => Math.Abs(Close - Bottom1) < 0.0001; }
		public bool IsBottom2 { get => Math.Abs(Close - Bottom2) < 0.0001; }
	}
}

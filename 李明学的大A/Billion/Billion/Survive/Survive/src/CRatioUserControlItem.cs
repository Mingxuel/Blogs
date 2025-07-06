using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survive
{
	internal class CRatioUserControlItem
	{
		public string Range {  get; set; }
		public string Count { get; set; }
		public string Ratio { get; set; }
		public CRatioUserControlItem(string range, string count, string ratio)
		{
			Range = range;
			Count = count;
			Ratio = ratio;
		}
	}
}

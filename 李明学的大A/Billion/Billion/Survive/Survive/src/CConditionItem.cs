using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survive
{
	internal class CConditionItem
	{
		public string LowValue { get; set; }
		public string HighValue { get; set; }
		public int RateStatus { get; set; }

		public CConditionItem()
		{
			LowValue = "-11";
			HighValue = "11";
			RateStatus = 0;
		}
	}
}

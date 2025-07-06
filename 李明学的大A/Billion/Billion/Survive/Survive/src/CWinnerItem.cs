using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Survive
{
	internal class CWinnerItem
	{
		public int Count { get; set; }
		public double Total { get; set; }
		
		public void Add(double value)
		{
			Count++;
			Total += value;
		}
	}
}

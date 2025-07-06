using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Survive
{
	class CWinner
	{
		public Dictionary<int, CWinnerItem> Winners = new Dictionary<int, CWinnerItem>();

		public void Add(double pratio)
		{
			if (Winners.Count == 0)
			{
				for (int i = 1; i <= 20; i++)
				{
					Winners[i] = new CWinnerItem();
				}
			}

			if (pratio > 11)
			{
				return;
			}

			int ID = -1;
			if (pratio >= 9.0)
			{
				ID = 1;
			}
			else if (pratio <= -9.0)
			{
				ID = 20;
			}
			else if (pratio >= 0)
			{
				ID = 10 - Math.Abs((int)(pratio));
			}
			else 
			{
				ID = 11 + Math.Abs((int)(pratio));
			}

			Winners[ID].Add(pratio);
		}

		public void Clear()
		{
			Winners.Clear();
		}
	}
}

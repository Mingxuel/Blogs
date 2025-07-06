using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace Survive
{
	class CListViewItemComparer : IComparer
	{
		private int columnIndex;
		private SortOrder sortOrder;

		public CListViewItemComparer(int columnIndex, SortOrder sortOrder)
		{
			this.columnIndex = columnIndex;
			this.sortOrder = sortOrder;
		}

		public int Compare(object x, object y)
		{
			ListViewItem item1 = x as ListViewItem;
			ListViewItem item2 = y as ListViewItem;

			if (item1 == null || item2 == null)
			{
				return 0;
			}

			int result;
			if (int.TryParse(item1.SubItems[columnIndex].Text, out int intValue1) && int.TryParse(item2.SubItems[columnIndex].Text, out int intValue2))
			{
				result = intValue1.CompareTo(intValue2);
			}
			else
			{
				result = string.Compare(item1.SubItems[columnIndex].Text, item2.SubItems[columnIndex].Text);
			}

			return sortOrder == SortOrder.Ascending ? result : -result;
		}
	}
}

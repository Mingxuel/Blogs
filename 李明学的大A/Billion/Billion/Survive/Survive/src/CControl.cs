using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survive
{
	class CControl
	{
		public static Control FindControlByName(Control.ControlCollection controls, string name)
		{
			foreach (Control control in controls)
			{
				if (control.Name == name)
				{
					return control;
				}

				// 如果控件是容器控件（如Panel等），则递归查找其内部的控件
				if (control.HasChildren)
				{
					Control foundInChildren = FindControlByName(control.Controls, name);
					if (foundInChildren != null)
					{
						return foundInChildren;
					}
				}
			}

			return null;
		}
	}
}

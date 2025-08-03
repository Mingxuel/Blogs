using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDream
{
	public class Common
	{
		private static Common? _instance = null;
		public static Common? Instance { get =>  _instance == null ? _instance = new Common() : _instance; }
		private Common() { }
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDream
{
	public class Update
	{
		private const string _file_update = @"../../Miniqmt/src/UpdateForCSharp.py";
		private const string _update_trading_dates = "--update_trading_dates";

		private static Update? _instance = null;
		public static Update? Instance { get => _instance == null ? _instance = new Update() : _instance; }
		private Update() { }

		public string? UpdateTradingDates()
		{
			return Call(_update_trading_dates);
		}

		private string? Call(string param)
		{
			var start_info = new ProcessStartInfo
			{
				FileName = "python",
				Arguments = string.Format("{0} {1}", _file_update, param),
				RedirectStandardOutput = true,
				UseShellExecute = false
			};
			var process = Process.Start(start_info);
			var output = process?.StandardOutput.ReadToEnd();
			process?.WaitForExit();
			return output ?? null;
		}
	}
}

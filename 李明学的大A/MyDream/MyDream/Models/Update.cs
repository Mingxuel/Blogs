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
		private static Update? _instance = null;
		public static Update? Instance { get => _instance == null ? _instance = new Update() : _instance; }
		private Update() { }

		public void Call()
		{
			var start_info = new ProcessStartInfo
			{
				FileName = "python",
				Arguments = "your_script.py 参数",
				RedirectStandardOutput = true,
				UseShellExecute = false
			};
			var process = Process.Start(start_info);
			string output = process.StandardOutput.ReadToEnd();
			process.WaitForExit();
			Console.WriteLine(output);
		}
	}
}

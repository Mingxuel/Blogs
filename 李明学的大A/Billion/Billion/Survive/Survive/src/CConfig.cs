using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Survive
{
	internal class CConfig
	{
		private static List<string> _solutions = [
			@"../../../../../Data/Config/Solution_0.ini",
			@"../../../../../Data/Config/Solution_1.ini",
			@"../../../../../Data/Config/Solution_2.ini",
			@"../../../../../Data/Config/Solution_3.ini",
			@"../../../../../Data/Config/Solution_4.ini",
			@"../../../../../Data/Config/Solution_5.ini",
			@"../../../../../Data/Config/Solution_6.ini",
			@"../../../../../Data/Config/Solution_7.ini",
			@"../../../../../Data/Config/Solution_8.ini",
			@"../../../../../Data/Config/Solution_9.ini",
			@"../../../../../Data/Config/Solution_10.ini",
			@"../../../../../Data/Config/Solution_11.ini",
			@"../../../../../Data/Config/Solution_12.ini",
			@"../../../../../Data/Config/Solution_13.ini",
			@"../../../../../Data/Config/Solution_14.ini",
			@"../../../../../Data/Config/Solution_15.ini",
			@"../../../../../Data/Config/Solution_16.ini",
			@"../../../../../Data/Config/Solution_17.ini",
			@"../../../../../Data/Config/Solution_18.ini",
			@"../../../../../Data/Config/Solution_19.ini",
			@"../../../../../Data/Config/Solution_20.ini"];
		private static string _keydays = @"../../../../../Data/Config/KeyDays.config";

		private static void SaveIniFile(string filePath, string section, string key, string value)
		{
			List<string> lines = new List<string>();
			bool sectionFound = false;
			bool keyFound = false;
			if (File.Exists(filePath))
			{
				lines = File.ReadAllLines(filePath).ToList();
				for (int i = 0; i < lines.Count; i++)
				{
					if (lines[i].StartsWith("[" + section + "]"))
					{
						sectionFound = true;
						for (int j = i + 1; j < lines.Count; j++)
						{
							if (lines[j].StartsWith(key + "="))
							{
								lines[j] = key + "=" + value;
								keyFound = true;
								break;
							}
							else if (lines[j].StartsWith("["))
							{
								break;
							}
						}
						if (!keyFound)
						{
							lines.Insert(i + 1, key + "=" + value);
						}
						break;
					}
				}
				if (!sectionFound)
				{
					lines.Add("[" + section + "]");
					lines.Add(key + "=" + value);
				}
			}
			else
			{
				lines.Add("[" + section + "]");
				lines.Add(key + "=" + value);
			}
			
			try {
				File.WriteAllLines(filePath, lines);
			} catch (Exception ex) {

			}
			finally {
			
			}
		}

		private static string ReadIniValue(string filePath, string section, string key)
		{
			if (!File.Exists(filePath))
			{
				return "";
			}
			bool inSection = false;
			foreach (string line in File.ReadLines(filePath))
			{
				if (line.StartsWith("[" + section + "]"))
				{
					inSection = true;
					continue;
				}
				if (inSection && line.StartsWith(key + "="))
				{
					return line.Substring(key.Length + 1);
				}
				if (inSection && line.StartsWith("["))
				{
					break;
				}
			}
			return "";
		}

		static public bool StrategyExists(int solution_id)
		{
			if (!System.IO.File.Exists(_solutions[solution_id]))
			{
				return false;
			}

			return true;
		}

		static public void SaveStrategy(int solution_id, string key, string value)
		{
			SaveIniFile(_solutions[solution_id], "DATA", key, value);
		}

		static public string LoadStrategy(int solution_id, string key)
		{
			try
			{
				return ReadIniValue(_solutions[solution_id], "DATA", key);
			}
			catch (Exception e)
			{
				
			}

			return "";
		}

		static public void SaveSolution(int solution_id, string key, string value)
		{
			SaveIniFile(_solutions[solution_id], "SOLUTION", key, value);
		}

		static public string LoadSolution(int solution_id, string key)
		{
			return ReadIniValue(_solutions[solution_id], "SOLUTION", key);
		}

        static public void SaveKeyDays(string days)
        {
			File.WriteAllText(_keydays, days);
        }

        static public string LoadKeyDays()
        {
            return File.ReadAllText(_keydays);
        }
    }
}

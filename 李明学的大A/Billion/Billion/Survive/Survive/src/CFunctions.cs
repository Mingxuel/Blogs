using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Survive
{
	internal class CFunctions
	{
		private string Bigger = ">";
		private string BiggerNEqual = ">=";
		private string Equal = "=";
		private string EqualNSmaller = "<";
		private string Smaller = "<=";
		private string Absolute = "|";

		private List<CFunctionsItem> _opcodes = new List<CFunctionsItem>();
		List<double> _variables = new List<double>();
		List<double> _days = new List<double>();

		public bool Compile(string code)
		{
			if (code == "")	return true;

			_opcodes.Clear();

			string[] codes = code.Split("#");
			foreach (string line in codes)
			{
				CFunctionsItem opcode = new CFunctionsItem();
				string[] items = line.Split(" ");
				if (items[1] == CFuncionFlag.Flag[EFunctionFlag.Assigned])
				{
					//是等式
					opcode.Assigned = true;
					opcode.Left = items[0];
					string right = "";
					EFunctionFlag flag = EFunctionFlag.None;
					ConvertItem(items[2], out right, out flag);
					opcode.Right1 = right;
					opcode.Flag1 = flag;
					if (items.Length == 5)
					{
						opcode.Symble = ConvertSymble(items[3]);
						ConvertItem(items[4], out right, out flag);
						opcode.Right2 = right;
						opcode.Flag2 = flag;
					}
				}
				else
				{
					//不是等式
					opcode.Assigned = false;
					opcode.Symble = ConvertSymble(items[1]);
					string right = "";
					EFunctionFlag flag = EFunctionFlag.None;
					ConvertItem(items[0], out right, out flag);
					opcode.Right1 = right;
					opcode.Flag1 = flag;
					ConvertItem(items[2], out right, out flag);
					opcode.Right2 = right;
					opcode.Flag2 = flag;
				}

				_opcodes.Add(opcode);
			}

			return true;
		}

		public bool Run(List<double> days)
		{
			if (_opcodes.Count == 0) return true;

			_variables.Clear();
			for (int i = 0; i < 10; i++)
			{
				_variables.Add(0.0);
			}

			_days.Clear();
			for (int i = 0; i < days.Count; i++)
			{
				_days.Add(days[i]);
			}

			foreach(var opcode in _opcodes)
			{
				if (opcode.Assigned)
				{
					double value = 0.0;
					double r1 = GetItemValue(opcode.Right1, opcode.Flag1);
					double r2 = GetItemValue(opcode.Right2, opcode.Flag2);
					switch (opcode.Symble)
					{
						case EFunctionFlag.Plus:
							value =  r1 + r2;
							break;
						case EFunctionFlag.Minus:
							value = r1 - r2;
							break;
						case EFunctionFlag.Times:
							value = r1 * r2;
							break;
						case EFunctionFlag.Divide:
							value = r1 / r2;
							break;
					}
					SetItemValue(opcode.Left, value);
					continue;
				}
				else
				{
					double r1 = GetItemValue(opcode.Right1, opcode.Flag1);
					double r2 = GetItemValue(opcode.Right2, opcode.Flag2);
					switch (opcode.Symble)
					{
						case EFunctionFlag.Bigger:
							if (r1 <= r2) return false;
							break;
						case EFunctionFlag.BiggerNEqual:
							if (r1 < r2) return false;
							break;
						case EFunctionFlag.Equal:
							if (r1 != r2) return false;
							break;
						case EFunctionFlag.EqualNSmaller:
							if (r1 > r2) return false;
							break;
						case EFunctionFlag.Smaller:
							if (r1 >= r2) return false;
							break;
					}
				}
			}

			return true;
		}

		private EFunctionFlag ConvertSymble(string code)
		{
			if (code == CFuncionFlag.Flag[EFunctionFlag.Bigger]) { return EFunctionFlag.Bigger; }
			else if (code == CFuncionFlag.Flag[EFunctionFlag.BiggerNEqual]) { return EFunctionFlag.BiggerNEqual; }
			else if (code == CFuncionFlag.Flag[EFunctionFlag.Equal]) { return EFunctionFlag.Equal; }
			else if (code == CFuncionFlag.Flag[EFunctionFlag.EqualNSmaller]) { return EFunctionFlag.EqualNSmaller; }
			else if (code == CFuncionFlag.Flag[EFunctionFlag.Smaller]) { return EFunctionFlag.Smaller; }
			else if (code == CFuncionFlag.Flag[EFunctionFlag.Plus]) { return EFunctionFlag.Plus; }
			else if (code == CFuncionFlag.Flag[EFunctionFlag.Minus]) { return EFunctionFlag.Minus; }
			else if (code == CFuncionFlag.Flag[EFunctionFlag.Times]) { return EFunctionFlag.Times; }
			else if (code == CFuncionFlag.Flag[EFunctionFlag.Divide]) { return EFunctionFlag.Divide; }

			return EFunctionFlag.None;
		}

		private void ConvertItem(string code, out string right, out EFunctionFlag flag)
		{
			if (code.Contains(Absolute))
			{
				code = code.Replace(Absolute, "");
				flag = EFunctionFlag.Absolute;
			}
			else
			{
				flag = EFunctionFlag.None;
			}

			right = code;
		}

		private double GetItemValue(string right, EFunctionFlag flag)
		{
			double result = 0.0;
			if (right.Contains("D") || right.Contains("d"))
			{
				right = right.Replace("D", "").Replace("d", "");
				int index = int.Parse(right);
				result = _days[index];
			}
			else if (right.Contains("V") || right.Contains("v"))
			{
				right = right.Replace("V", "").Replace("v", "");
				int index = int.Parse(right);
				result = _variables[index];
			}
			else
			{
				result = double.Parse(right);
			}

			if (flag == EFunctionFlag.Absolute)
			{
				result = Math.Abs(result);
			}

			return result;
		}

		private void SetItemValue(string left, double value)
		{
			if (left.Contains("D") || left.Contains("d"))
			{
				left = left.Replace("D", "").Replace("d", "");
				int index = int.Parse(left);
				_days[index] = value;
			}
			else if (left.Contains("V") || left.Contains("v"))
			{
				left = left.Replace("V", "").Replace("v", "");
				int index = int.Parse(left);
				_variables[index] = value;
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survive
{
	enum EFunctionFlag
	{
		None = 0,
		//Symbles
		Bigger = 1,		//大于
		BiggerNEqual,	//大于等于
		Equal,			//等于
		EqualNSmaller,	//小于等于
		Smaller,		//小于
		Assigned,		//"="号
		Plus,			//"+"号
		Minus,			//"-"号
		Times,			//"*"号
		Divide,			//"/"号
		Absolute		//绝对值
	}

	class CFuncionFlag
	{
		static public Dictionary<EFunctionFlag, string> Flag = new Dictionary<EFunctionFlag, string> {
			{EFunctionFlag.Bigger, ">"},
			{EFunctionFlag.BiggerNEqual, ">="},
			{EFunctionFlag.Equal, "=="},
			{EFunctionFlag.EqualNSmaller, "<="},
			{EFunctionFlag.Smaller,	"<"},
			{EFunctionFlag.Assigned, "="},
			{EFunctionFlag.Plus, "+"},
			{EFunctionFlag.Minus, "-"},
			{EFunctionFlag.Times, "*"},
			{EFunctionFlag.Divide, "/"},
			{EFunctionFlag.Absolute, "|"}
		};
	}
}

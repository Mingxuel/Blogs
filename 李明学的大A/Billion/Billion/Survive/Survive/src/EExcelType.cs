using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peace
{
	//根据不同的Excel类型配置不同数据
	enum EExcelType : int
	{
		None = 0,				//啥也不是
		Top = 1,				//涨停板Excel
		All = 2,				//所有票的Excel
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Survive
{
	//根据不同的Excel类型配置不同数据
	enum EDataType : int
	{
		None = 0,			//啥也不是
		Num = 1,			//数字类数据, 数据类型为double, 实际还是按照string存储
		String,				//字符串数据, 数据类型为string
		Collection,			//集合类数据, 数据类型为List<string>
		TimeSpan,			//时间类数据, 数据类型为TimeSpan
	}

	class CDataType
	{
		public static object New(EDataType pdatatype)
		{
			switch (pdatatype)
			{
				case EDataType.String:
				case EDataType.Num:
					return (string)"";
				case EDataType.Collection:
					return new List<string>();
				case EDataType.TimeSpan:
					return new TimeSpan();
			}

			return (string)"";
		}

		public static object ConvertToOrigin(EDataType pdatatype, string pvalue)
		{
			switch (pdatatype)
			{
				case EDataType.String:
				case EDataType.Num:
					return pvalue;
				case EDataType.Collection:
					string[] subjects;
					if (pvalue.Contains(';'))
					{
						subjects = pvalue.Split(';');
					}
					else
					{
						subjects = pvalue.Split(',');
					}

					return new List<string>(subjects);

				case EDataType.TimeSpan:
					return TimeSpan.Parse(pvalue);
			}

			return pvalue;
		}

		public static string ConvertToString(EDataType pdatatype, object pvalue)
		{
			switch (pdatatype)
			{
				case EDataType.String:
				case EDataType.Num:
					return (string)pvalue;
				case EDataType.Collection:
					if (pvalue is List<string>) {
						return string.Join(",", ((List<string>)pvalue));
					}
					return (string)pvalue;
				case EDataType.TimeSpan:
					if (pvalue is TimeSpan)
					{
						return ((TimeSpan)pvalue).ToString();
					}
					return (string)pvalue;
			}

			return (string)pvalue;
		}
	}
}

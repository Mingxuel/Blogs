using Peace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peace
{
	//股票中的各种数据类型
	enum ETicketObjectID : int
	{
		None = -1,				//未知
		ID,						//股票号码
		Name,                   //股票名称
		Value,                  //股票价格
		TopType,				//股票涨停类型
		ContinueTopTimes,		//股票连续涨停次数
		TopTimes,				//股票涨停次数
		TopStarttime,			//股票首涨停时间
		Subjects,				//股票概念合集
		Industry,				//所属行业
		ValueStart,				//开盘价
		ValueTop,				//最高价
		ValueBottom,			//最低价
		ValueEnd,				//收盘价
		MainForce,				//主力净额
		MainBuy,				//主力买入
		MainSell,				//主力卖出
		ChangeHand,				//换手率
		Trade,					//成交量
		MarketValue,			//市值
		VolumnRatio,			//量比
		Rate,					//涨跌幅
		Range,					//振幅
	}
}
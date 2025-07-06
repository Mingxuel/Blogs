

using Microsoft.Office.Interop.Excel;
using Survive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Reflection.Emit;
using System.Windows.Input;

namespace Peace
{
	class CTicket
	{
		//股票数据: 股票数据ID+股票数据字符串+股票数据
		public List<CTicketItem> Items {  get; set; }

		public CTicket() {
			Items = new List<CTicketItem>();
			Items.Add(new CTicketItem(ETicketObjectID.ID,					" 股票代码",					EDataType.String,		CDataType.New(EDataType.String		)));
			Items.Add(new CTicketItem(ETicketObjectID.Name,					" 股票简称",					EDataType.String,		CDataType.New(EDataType.String		)));
			Items.Add(new CTicketItem(ETicketObjectID.Value,				" 现价",						EDataType.String,		CDataType.New(EDataType.String		)));
			Items.Add(new CTicketItem(ETicketObjectID.TopType,				"  板型  ",					EDataType.String,		CDataType.New(EDataType.String		)));
			Items.Add(new CTicketItem(ETicketObjectID.ContinueTopTimes,		"连续涨停天数",				EDataType.String,		CDataType.New(EDataType.String		)));
			Items.Add(new CTicketItem(ETicketObjectID.TopTimes,				" 几板",						EDataType.String,		CDataType.New(EDataType.String		)));
			Items.Add(new CTicketItem(ETicketObjectID.TopStarttime,			"首次涨停时间",				EDataType.TimeSpan,		CDataType.New(EDataType.TimeSpan	)));
			Items.Add(new CTicketItem(ETicketObjectID.Subjects,				"       短线主题名称       ",	EDataType.Collection,	CDataType.New(EDataType.Collection	)));
			Items.Add(new CTicketItem(ETicketObjectID.Industry,				" 所属行业",					EDataType.String,		CDataType.New(EDataType.String		)));
			Items.Add(new CTicketItem(ETicketObjectID.ValueStart,			" 开盘价",					EDataType.String,		CDataType.New(EDataType.String		)));
			Items.Add(new CTicketItem(ETicketObjectID.ValueTop,				" 最高价",					EDataType.String,		CDataType.New(EDataType.String		)));
			Items.Add(new CTicketItem(ETicketObjectID.ValueBottom,			" 最低价",					EDataType.String,		CDataType.New(EDataType.String		)));
			Items.Add(new CTicketItem(ETicketObjectID.ValueEnd,				" 收盘价",					EDataType.String,		CDataType.New(EDataType.String		)));
			Items.Add(new CTicketItem(ETicketObjectID.MainForce,			" 主力净额",					EDataType.String,		CDataType.New(EDataType.String		)));
			Items.Add(new CTicketItem(ETicketObjectID.MainBuy,				" 主力买量",					EDataType.String,		CDataType.New(EDataType.String		)));
			Items.Add(new CTicketItem(ETicketObjectID.MainSell,				" 主力卖量",					EDataType.String,		CDataType.New(EDataType.String		)));
			Items.Add(new CTicketItem(ETicketObjectID.ChangeHand,			" 换手率",					EDataType.String,		CDataType.New(EDataType.String		)));
			Items.Add(new CTicketItem(ETicketObjectID.Trade,				" 成交量",					EDataType.String,		CDataType.New(EDataType.String		)));
			Items.Add(new CTicketItem(ETicketObjectID.MarketValue,			" 自由流通市值",				EDataType.String,		CDataType.New(EDataType.String		)));
			Items.Add(new CTicketItem(ETicketObjectID.VolumnRatio,			" 量比",						EDataType.String,		CDataType.New(EDataType.String		)));
			Items.Add(new CTicketItem(ETicketObjectID.Rate,					" 涨跌幅",					EDataType.String,		CDataType.New(EDataType.String		)));
			Items.Add(new CTicketItem(ETicketObjectID.Range,				" 振幅",						EDataType.String,		CDataType.New(EDataType.String		)));
			Items.Add(new CTicketItem(ETicketObjectID.Subjects,				" 所属主题",					EDataType.Collection,	CDataType.New(EDataType.Collection	)));

			//此处添加新数据类型, 如果出现相同数据有两个字符串时我们再考虑那个问题, 比如字符串通过特殊符号"#"进行分割之类的
		}

		//序列化构造函数, Json序列化必须的初始化函数
		public CTicket(List<CTicketItem> items)
		{
			Items = items;
		}

		public CTicketItem this[ETicketObjectID pid]
		{
			get
			{
				return Items.ElementAt((int)pid);
			}
		}

		public CTicketItem this[string pname]
		{
			get
			{
				foreach (CTicketItem item in Items)
				{
					if (pname.Contains(item.Name.Trim()))
					{
						return item;
					}
				}
				return null;
			}
		}

		//通过股票数据ID直接设置数据
		public void SetValue(ETicketObjectID pid, string pvalue)
		{
			EDataType type = this[pid].Datatype;
			this[pid].Item = CDataType.ConvertToOrigin(type, pvalue);
		}

		public void SetValue(string pname, string pvalue)
		{
			EDataType type = this[pname].Datatype;
			this[pname].Item = CDataType.ConvertToOrigin(type, pvalue);
		}

		//获取股票字符串数据
		public string GetValue(ETicketObjectID pid)
		{
			EDataType type = this[pid].Datatype;
			return CDataType.ConvertToString(type, this[pid].Item);
		}

		public bool IsEmpty()
		{
			if (((string)this[ETicketObjectID.ID].Item).Length == 0)
			{
				return true;
			}

			return false;
		}
	}
}

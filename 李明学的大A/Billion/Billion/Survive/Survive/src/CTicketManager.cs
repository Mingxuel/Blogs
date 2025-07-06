using System.IO;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.Json;
using System;
using Microsoft.Office.Interop.Excel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Survive;

namespace Peace
{
	class CTicketManager
	{
		//根据不同的Excel采用不同的数据类型
		private Dictionary<EExcelType, List<ETicketObjectID>> _excel_types = new Dictionary<EExcelType, List<ETicketObjectID>>();
		private Dictionary<EExcelType, string> _excel_path = new Dictionary<EExcelType, string>();
		private string _file_xlsx_format = @"{0}.xlsx";
		private string _file_json_format = @"{0}.json";

		//所有股票
		public List<CTicket> Tickets { get; set; }

		//Excel第一个Sheet的行数
		public int Row_Count { get; set; }
		//Excel第一个Sheet的列数
		public int Column_Count { get; set; }

		public CTicketManager()
		{
			InitExcelTypes();
			Tickets = new List<CTicket>();
		}

		//序列化构造函数
		public CTicketManager(List<CTicket> tickets, int row_count, int column_count)
		{
			InitExcelTypes();
			Tickets = tickets;
			Row_Count = row_count;
			Column_Count = column_count;
		}

		public void Init(CTicketManager pticket_manager)
		{
			Tickets = pticket_manager.Tickets;
			Row_Count = pticket_manager.Row_Count;
			Column_Count = pticket_manager.Column_Count;
		}

		// 通过EExcelType限定数据类型的设置
		private void InitExcelTypes()
		{
			_excel_types[EExcelType.Top] = new List<ETicketObjectID>{
												ETicketObjectID.ID,
												ETicketObjectID.Name,
												ETicketObjectID.Value,
												ETicketObjectID.TopType,
												ETicketObjectID.ContinueTopTimes,
												ETicketObjectID.TopTimes,
												ETicketObjectID.TopStarttime,
												ETicketObjectID.Subjects,
											};

			_excel_types[EExcelType.All] = new List<ETicketObjectID>{
												ETicketObjectID.ID,
												ETicketObjectID.Name,
												ETicketObjectID.Industry,
												ETicketObjectID.ValueStart,
												ETicketObjectID.ValueTop,
												ETicketObjectID.ValueBottom,
												ETicketObjectID.ValueEnd,
												ETicketObjectID.MainForce,
												ETicketObjectID.MainBuy,
												ETicketObjectID.MainSell,
												ETicketObjectID.ChangeHand,
												ETicketObjectID.Trade,
												ETicketObjectID.MarketValue,
												ETicketObjectID.VolumnRatio,
												ETicketObjectID.Rate,
												ETicketObjectID.Range,
												ETicketObjectID.Subjects
											};

			_excel_path[EExcelType.Top] = @"../../../../../Data/Top/";
			_excel_path[EExcelType.All] = @"../../../../../Data/All/";
		}

		public List<ETicketObjectID> GetExcelTypes(EExcelType ptype) 
		{
			return _excel_types[ptype];
		}

		public bool LoadExcel(EExcelType pexcel_type, string pfile) {
			Clear();

			string file_xlsx = Path.GetFullPath(string.Format(_excel_path[pexcel_type] + _file_xlsx_format, pfile));
			string file_json = Path.GetFullPath(string.Format(_excel_path[pexcel_type] + _file_json_format, pfile));

			if (System.IO.File.Exists(file_json) == true)
			{
				JsonToData(file_json);
			}
			else if (System.IO.File.Exists(file_xlsx) == false)
			{
				return false;
			}
			else if (pfile.StartsWith('~') == false)
			{
				LoadExcelWithExcel(pexcel_type, pfile);
			}

			return true;
		}

		public void LoadExcelWithExcel(EExcelType pexcel_type, string pfile) {
			string file_xlsx = string.Format(_excel_path[pexcel_type] + _file_xlsx_format, pfile);
			file_xlsx = Path.GetFullPath(file_xlsx);

						//打开Excel并获取第一个Sheet,行数和列数
			Excel.Application excelApp = new Excel.Application();
			Excel.Workbook workbook = excelApp.Workbooks.Open(file_xlsx);
			Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];
			Row_Count = worksheet.UsedRange.Rows.Count;
			Column_Count = worksheet.UsedRange.Columns.Count;

			Excel.Range range = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[Row_Count, Column_Count]];
			object[,] cells = (object[,])range.Value;

			//关闭Excel
			workbook.Close(false);
			excelApp.Quit();

			int start_row = 2;
			
			if (pexcel_type == EExcelType.All)
			{
				start_row = 3;
			}

			//读取Excel数据到tickets
			for (int i = start_row; i <= Row_Count; i++)
			{
				CTicket ticket = new CTicket();
				for (int j = 1; j <= Column_Count; j++)
				{
					string name = cells[1, j].ToString().Trim();
					string value = cells[i, j].ToString().Trim();

					if (ticket[name] != null && _excel_types[pexcel_type].Contains(ticket[name].ID))
					{
						ticket.SetValue(name, value);
					}
				}
				Tickets.Add(ticket);
			}

			DataToJson(string.Format(_excel_path[pexcel_type] + _file_json_format, pfile));
		}

		private void DataToJson(string pfile)
		{
			string jsonString = JsonSerializer.Serialize(this);
			System.IO.File.WriteAllText(pfile, jsonString);
		}

		private void JsonToData(string pfile)
		{
			string jsonString = System.IO.File.ReadAllText(pfile);
			CTicketManager? ticket_manager = JsonSerializer.Deserialize<CTicketManager>(jsonString);
			if (ticket_manager != null) {
				Init(ticket_manager);
			}
		}

		//清除票数据
		public void Clear()
		{
			Tickets.Clear();
		}
	}
}

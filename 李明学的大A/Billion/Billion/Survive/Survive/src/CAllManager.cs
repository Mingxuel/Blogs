using Peace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survive
{
	internal class CAllManager
	{
		private Dictionary<DateTime, CTicketManager> _data = new Dictionary<DateTime, CTicketManager>();
		private Dictionary<string, Dictionary<int, CTicket>> _organized_data = new Dictionary<string, Dictionary<int, CTicket>>();
		private List<CWinnerDetailsItem> _winner_details = new List<CWinnerDetailsItem>();
		private List<CWinnerDetailsItem> _filter_details = new List<CWinnerDetailsItem>();

		public Dictionary<DateTime, CTicketManager> Data { get { return _data; } }
		public Dictionary<string, Dictionary<int, CTicket>> Organized_Data { get { return _organized_data; } }
		public List<CWinnerDetailsItem> Winner_Details { get { return _winner_details; } }
		public List<CWinnerDetailsItem> Filter_Details { get { return _filter_details; } }

		public int Days {
			get
			{ 
				return _data.Count; 
			}
		}

		public int Count
		{
			get
			{
				return _organized_data.Count;
			}
		}

		public void Clear()
		{
			_organized_data.Clear();
			_winner_details.Clear();
			_filter_details.Clear();
		}

		public void Organize()
		{
			foreach (CTicket ticket in _data.Last().Value.Tickets)
			{
				_organized_data[(string)ticket[ETicketObjectID.ID].Item] = new Dictionary<int, CTicket>();
				for (int day = 1; day <= Days; day++)
				{
					_organized_data[(string)ticket[ETicketObjectID.ID].Item][day] = new CTicket();
				}
			}

			for (int day = 1; day <= Days; day++) {
				foreach (CTicket ticket in _data.ElementAt(day-1).Value.Tickets)
				{
					if (_organized_data.ContainsKey((string)ticket[ETicketObjectID.ID].Item))
					{
						_organized_data[(string)ticket[ETicketObjectID.ID].Item][day] = ticket;
					}
				}
			}
		}

		public void AddWinnerDetail(string id, int day, int condition_days)
		{
			CWinnerDetailsItem item = new CWinnerDetailsItem();
			item.ID = id;
			item.Name = (string)_organized_data[id][Days][ETicketObjectID.Name].Item;
			item.Start_Day = Data.ElementAt(day-1).Key.ToString("yyyy-MM-dd");
			item.Check_Day = Data.ElementAt(day + condition_days - 1).Key.ToString("yyyy-MM-dd");
			if (_organized_data[id].ContainsKey(day)) item.Day1 = (string)_organized_data[id][day][ETicketObjectID.Rate].Item;
			if (_organized_data[id].ContainsKey(day+1)) item.Day2 = (string)_organized_data[id][day+1][ETicketObjectID.Rate].Item;
			if (_organized_data[id].ContainsKey(day+2)) item.Day3 = (string)_organized_data[id][day+2][ETicketObjectID.Rate].Item;
			if (_organized_data[id].ContainsKey(day+3)) item.Day4 = (string)_organized_data[id][day+3][ETicketObjectID.Rate].Item;
			if (_organized_data[id].ContainsKey(day+4)) item.Day5 = (string)_organized_data[id][day+4][ETicketObjectID.Rate].Item;
			if (_organized_data[id].ContainsKey(day+5)) item.Day6 = (string)_organized_data[id][day+5][ETicketObjectID.Rate].Item;
			_winner_details.Add(item);
		}

		public void AddFilterDetail(string id, int day, int condition_days)
		{
			CWinnerDetailsItem item = new CWinnerDetailsItem();
			item.ID = id;
			item.Name = (string)_organized_data[id][Days][ETicketObjectID.Name].Item;
			item.Start_Day = Data.ElementAt(day - 1).Key.ToString("yyyy-MM-dd");
			if (condition_days == 3)
			{
				if (_organized_data[id].ContainsKey(day)) item.Day1 = (string)_organized_data[id][day][ETicketObjectID.Rate].Item;
				if (_organized_data[id].ContainsKey(day + 1)) item.Day2 = (string)_organized_data[id][day + 1][ETicketObjectID.Rate].Item;
				if (_organized_data[id].ContainsKey(day + 2)) item.Day3 = (string)_organized_data[id][day + 2][ETicketObjectID.Rate].Item;
			}
			else if (condition_days == 4)
			{
				if (_organized_data[id].ContainsKey(day)) item.Day1 = (string)_organized_data[id][day][ETicketObjectID.Rate].Item;
				if (_organized_data[id].ContainsKey(day + 1)) item.Day2 = (string)_organized_data[id][day + 1][ETicketObjectID.Rate].Item;
				if (_organized_data[id].ContainsKey(day + 2)) item.Day3 = (string)_organized_data[id][day + 2][ETicketObjectID.Rate].Item;
				if (_organized_data[id].ContainsKey(day + 3)) item.Day4 = (string)_organized_data[id][day + 3][ETicketObjectID.Rate].Item;
			}
			else if (condition_days == 5)
			{
				if (_organized_data[id].ContainsKey(day)) item.Day1 = (string)_organized_data[id][day][ETicketObjectID.Rate].Item;
				if (_organized_data[id].ContainsKey(day + 1)) item.Day2 = (string)_organized_data[id][day + 1][ETicketObjectID.Rate].Item;
				if (_organized_data[id].ContainsKey(day + 2)) item.Day3 = (string)_organized_data[id][day + 2][ETicketObjectID.Rate].Item;
				if (_organized_data[id].ContainsKey(day + 3)) item.Day4 = (string)_organized_data[id][day + 3][ETicketObjectID.Rate].Item;
				if (_organized_data[id].ContainsKey(day + 4)) item.Day5 = (string)_organized_data[id][day + 4][ETicketObjectID.Rate].Item;
			}
			else if (condition_days == 6)
			{
				if (_organized_data[id].ContainsKey(day)) item.Day1 = (string)_organized_data[id][day][ETicketObjectID.Rate].Item;
				if (_organized_data[id].ContainsKey(day + 1)) item.Day2 = (string)_organized_data[id][day + 1][ETicketObjectID.Rate].Item;
				if (_organized_data[id].ContainsKey(day + 2)) item.Day3 = (string)_organized_data[id][day + 2][ETicketObjectID.Rate].Item;
				if (_organized_data[id].ContainsKey(day + 3)) item.Day4 = (string)_organized_data[id][day + 3][ETicketObjectID.Rate].Item;
				if (_organized_data[id].ContainsKey(day + 4)) item.Day5 = (string)_organized_data[id][day + 4][ETicketObjectID.Rate].Item;
				if (_organized_data[id].ContainsKey(day + 5)) item.Day6 = (string)_organized_data[id][day + 5][ETicketObjectID.Rate].Item;
			}
			_filter_details.Add(item);
		}
	}
}

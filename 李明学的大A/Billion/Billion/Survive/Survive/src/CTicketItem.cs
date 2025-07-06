
using Peace;
using System;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Survive
{
	internal class CTicketItem
	{
		public ETicketObjectID ID {  get; set; }
		public string Name { get; set; }
		public EDataType Datatype { get; set; }

		private object _item;
		public object Item
		{
			get
			{
				return _item;
			}
			set
			{
				if (value is JsonElement)
				{
					switch (((JsonElement)value).ValueKind)
					{
						case JsonValueKind.String:
						case JsonValueKind.Number:
							_item = value.ToString();
							break;
						case JsonValueKind.Array:
							List<string> temps = new List<string>();
							foreach (var item in ((JsonElement)value).EnumerateArray())
							{
								temps.Add(item.GetString());
							}
							_item = temps;
							break;
					}
				}
				else
				{
					_item = value;
				}
			}
		}

		//序列化构造函数
		public CTicketItem(ETicketObjectID id, string name, EDataType datatype ,object item)
		{
			ID = id;
			Name = name;
			Datatype = datatype;
			Item = item;
		}
	}
}

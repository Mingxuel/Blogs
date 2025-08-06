using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyDream
{
    public class Item
    {
        public int Count { get => StockCodes.Count; }
        public string? Time { get; set; }
        public List<string> StockCodes { get; set; } = new List<string>();
    }
}

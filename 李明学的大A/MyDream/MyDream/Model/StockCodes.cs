using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyDream
{
    public class StockCodes
    {
        private static StockCodes? _instance = null;
        public static StockCodes Instance { get => _instance == null ? _instance = new StockCodes() : _instance; }

        private static string _dates = @"../../../../../Miniqmt/src/Config/主板代码";
        public List<string> Codes { get; } = new List<string>();

        private StockCodes()
        {
            foreach (var line in File.ReadLines(_dates))
            {
                var date = line.Trim();
                if (!string.IsNullOrEmpty(date)) Codes.Add(date);
            }
        }
    }
}

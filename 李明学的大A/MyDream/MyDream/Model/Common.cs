using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyDream
{
    public class Common
    {
        public static int Compare(string a, string b)
        {
            double da = double.Parse(a);
            double db = double.Parse(b);
            return da.CompareTo(db);
        }

        public static Record? PreRecord(string stock_code, string date, int count = 1)
        {
            var pre_date = TradingDates.Instance.PreDate(date);
            while(pre_date != null)
            {
                var record = Records1D.Instance.Records[stock_code]?[pre_date];
                if (record != null)
                {
                    count--;
                    if (count == 0) return record;
                }
                pre_date = TradingDates.Instance.PreDate(pre_date);
            }

            return null;
        }

        public static Record? NextRecord(string stock_code, string date, int count = 1)
        {
            var next_date = TradingDates.Instance.NextDate(date);
            while (next_date != null)
            {
                var record = Records1D.Instance.Records[stock_code]?[next_date];
                if (record != null)
                {
                    count--;
                    if (count == 0) return record;
                }
                next_date = TradingDates.Instance.NextDate(next_date);
            }
            return null;
        }
    }
}

using Peace;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Survive
{
    internal class CContinueManager
    {
        //Day | ContinueTimes | IsMorning | Count
        public Dictionary<int, Dictionary<int, Dictionary<bool, int>>> ContinueData { get; set; }

        public CContinueManager()
        {
            ContinueData = new Dictionary<int, Dictionary<int, Dictionary<bool, int>>>();
            Init();
        }

        private void Init()
        {
            for (int day = 1; day <= 15; day++)
            {
                ContinueData[day] = new Dictionary<int, Dictionary<bool, int>>();
                for (int continuetimes = 1; continuetimes <= 15; continuetimes++)
                {
                    ContinueData[day][continuetimes] = new Dictionary<bool, int>();
                    ContinueData[day][continuetimes][true] = 0;
                    ContinueData[day][continuetimes][false] = 0;
                }
            }
        }

        public void Add(int day, TimeSpan toptime, int continuetimes)
        {
            bool is_morning = false;
            if (toptime.Hours < 12)
            {
                is_morning = true;
            }

            continuetimes = continuetimes > 15 ? 15 : continuetimes;

            ContinueData[day][continuetimes][is_morning] += 1;
        }

        public string[] Total(int continuetimes)
        {
            string[] data = new string[16];
            data[0] = continuetimes.ToString();
            for (int day = 1; day <= 15; day++)
            {
                data[day] = (ContinueData[day][continuetimes][true] + ContinueData[day][continuetimes][false]).ToString();
                data[day] = data[day] == "0" ? "" : data[day];
            }

            return data;
        }

        public string[] Ratio(int continuetimes)
        {
            string[] data = new string[16];

            if (continuetimes < 2) return data;

            data[0] = continuetimes.ToString();
            for (int day = 1; day <= 14; day++)
            {
                int up = ContinueData[day][continuetimes][true] + ContinueData[day][continuetimes][false];
                int down = ContinueData[day + 1][continuetimes - 1][true] + ContinueData[day + 1][continuetimes - 1][false];
                double ratio = 0;
                if (down != 0)
                {
                    ratio = up / (double)down;
                }
                data[day] = ratio.ToString("P0");
            }
            data[15] = "";

            return data;
        }

        public void Clear()
        {
            ContinueData.Clear();
            Init();
        }
    }
}

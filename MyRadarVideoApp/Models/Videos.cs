using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRadarQuizApp.Models
{
    public class Videos
    {
        public List<Video> Video { get; set; }
    }

    public class Video
    {
        public string title { get; set; }
        public string bulletText { get; set; }
        public string description { get; set; }
        public string id { get; set; }
        public decimal runningTime { get; set; }
        public string runningTimeFormatted { get; set; }


        //Formats the time string into HH:MM:SS
        public void FormatTime()
        {
            //Finds the number of hours by divinding by 3600 and rounding
            //down to the nearest int
            string h = Decimal.ToInt32(runningTime / 3600).ToString();

            //Adds zeros to the front to make a two digit number
            while (h.Length < 2)
            {
                h = h.Insert(0, "0");
            }

            //Finds minutes by converting to mins, and then removing minutes equal
            //to the number of hours times 60
            string m = Decimal.ToInt32(runningTime / 60 - (Int32.Parse(h) * 60)).ToString();
            while (m.Length < 2)
            {
                m = m.Insert(0, "0");
            }

            //Finds seconds by removing seconds equal to the number of minutes times 60
            //and the number of hours times 3600
            string s = Decimal.ToInt32(runningTime - (Int32.Parse(h) * 3600) - (Int32.Parse(m) * 60)).ToString();
            while (s.Length < 2)
            {
                s = s.Insert(0, "0");
            }

            //Sets the new value
            runningTimeFormatted = String.Format("{0}:{1}:{2}", h, m, s);
        }
    }
}

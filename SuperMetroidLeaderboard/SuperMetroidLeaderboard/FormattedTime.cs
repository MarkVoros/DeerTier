using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMetroidLeaderboard
{
    public class FormattedTime
    {
        int timeSeconds;
        string timeString;

        public FormattedTime(int timeSeconds, string timeString)
        {
            this.timeSeconds = timeSeconds;
            this.timeString = timeString;
        }

        public int getTimeSeconds()
        {
            return timeSeconds;
        }

        public string getTimeString()
        {
            return timeString;
        }
    }
}
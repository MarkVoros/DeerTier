using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace SuperMetroidLeaderboard
{
    public static class TimeValidator
    {
        public static FormattedTime GetFormattedTime(string timeString)
        {
            Regex r = new Regex("^(\\d\\d?):(\\d\\d):(\\d\\d?)$");
            Match m = r.Match(timeString);

            int timeInSeconds = 0;

            if (m.Success)
            {
                int hours = int.Parse(m.Groups[1].Value);
                int minutes = int.Parse(m.Groups[2].Value);
                int seconds = int.Parse(m.Groups[3].Value);

                timeInSeconds = seconds + (minutes * 60) + (hours * 60 * 60);

                string hoursString = hours.ToString();
                string minutesString = minutes.ToString();
                string secondsString = seconds.ToString();

                if (hours < 10) { hoursString = "0" + hoursString; }
                if (minutes < 10) { minutesString = "0" + minutesString; }
                if (seconds < 10) { secondsString = "0" + secondsString; }

                string newTimeString = hoursString + ":" + minutesString + ":" + secondsString;

                if (hours < 0 || minutes < 0 || seconds < 0 || minutes >= 60 || seconds >= 60)
                {
                    return new FormattedTime(-1, "-1");
                }

                return new FormattedTime(timeInSeconds, newTimeString);
            }
            else
            {
                r = new Regex("^(\\d\\d?):(\\d\\d)$");
                m = r.Match(timeString);

                if (m.Success)
                {
                    int minutes = int.Parse(m.Groups[1].Value);
                    int seconds = int.Parse(m.Groups[2].Value);

                    timeInSeconds = seconds + (minutes * 60);

                    string minutesString = minutes.ToString();
                    string secondsString = seconds.ToString();

                    if (minutes < 10) { minutesString = "0" + minutesString; }
                    if (seconds < 10) { secondsString = "0" + secondsString; }

                    string newTimeString = minutesString + ":" + secondsString;

                    if (minutes < 0 || seconds < 0 || minutes >= 60 || seconds >= 60)
                    {
                        return new FormattedTime(-1, "-1");
                    }

                    return new FormattedTime(timeInSeconds, newTimeString);
                }
            }

            return new FormattedTime(-1, "-1");
        }
    }
}
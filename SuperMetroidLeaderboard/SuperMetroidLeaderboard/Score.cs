using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMetroidLeaderboard
{
    public class Score
    {
        private string mode;
        private string player;
        private string videoURL;

        private string realTimeString;
        private string gameTimeString;

        private int realTimeSeconds;
        private int gameTimeSeconds;
        private int rank;

        private string comment;

        public Score(string mode, string player, string realTimeString, int realTimeSeconds, string gameTimeString, int gameTimeSeconds, 
                     string videoURL, string comment)
        {
            this.mode = mode;
            this.player = player;
            this.realTimeString = realTimeString;
            this.realTimeSeconds = realTimeSeconds;
            this.gameTimeString = gameTimeString;
            this.gameTimeSeconds = gameTimeSeconds;
            this.videoURL = videoURL;
            this.comment = comment;
        }

        public Score(string mode, string player, string realTimeString, int realTimeSeconds, string videoURL, string comment)
        {
            this.mode = mode;
            this.player = player;
            this.realTimeString = realTimeString;
            this.realTimeSeconds = realTimeSeconds;
            this.videoURL = videoURL;
            this.comment = comment;
        }

        public string getMode() { return mode; }
        public string getPlayer() { return player; }
        public string getRealTimeString() { return realTimeString; }
        public string getGameTimeString() { return gameTimeString; }
        public int getRealTimeSeconds() { return realTimeSeconds; }
        public int getGameTimeSeconds() { return gameTimeSeconds; }
        public string getComment() { return comment; }
        public string getVideoURL() { return videoURL; }
        public int getRank() { return rank; }

        public void setRank(int rank) { this.rank = rank; }

        public string getVideoURLAsLink()
        {
            if (string.IsNullOrWhiteSpace(videoURL))
            {
                return "";
            }
            else
            {
                return "<a href=\"" + videoURL + "\" target=\"_blank\">Watch</a>";
            }
        }
    }
}
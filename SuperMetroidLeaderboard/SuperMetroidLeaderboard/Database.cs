using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlServerCe;
using System.Configuration;

namespace SuperMetroidLeaderboard
{
    public class Database
    {
        //variables
        private SqlCeConnection con;

        //constructor

        //methods
        public void Connect()
        {
            con = new SqlCeConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            con.Open();
        }

        public void Close()
        {
            con.Dispose();
        }

        public bool UserExists(string username)
        {
            username = EscapeString(username);

            SqlCeDataReader reader = ExecuteQuery("SELECT * FROM Users WHERE Name = '" + username + "';");

            if (reader.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PasswordsMatch(string username, string hashedPassword)
        {
            username = EscapeString(username);

            SqlCeDataReader reader = ExecuteQuery("SELECT * FROM Users WHERE Name = '" + username + "';");

            if (reader.Read())
            {
                if ((string)reader["Password"] == hashedPassword)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void AddUser(string username, string password)
        {
            username = EscapeString(username);
            password = EscapeString(password);

            ExecuteUpdate("INSERT INTO Users (Name, Password) VALUES('" + username + "', '" + password + "');");
        }

        public void AddTime(Score score)
        {
            string player = EscapeString(score.getPlayer());
            string mode = EscapeString(score.getMode());
            string realTimeString = EscapeString(score.getRealTimeString());
            string gameTimeString = EscapeString(score.getGameTimeString());
            int realTimeSeconds = score.getRealTimeSeconds();
            int gameTimeSeconds = score.getGameTimeSeconds() * 60;
            string videoURL = EscapeString(score.getVideoURL());
            string comment = EscapeString(score.getComment());

            SqlCeDataReader reader = ExecuteQuery("SELECT * FROM Scores WHERE Player = '" + player + "' AND Mode = '" + mode + "';");

            if (reader.Read())
            {
                //delete existing record
                ExecuteUpdate("DELETE FROM Scores WHERE Player = '" + player + "' AND Mode = '" + mode + "';");
                
                //insert new record
                ExecuteUpdate("INSERT INTO Scores (Mode, Player, RealTimeSeconds, RealTimeString, GameTimeSeconds, GameTimeString, Comment, VideoURL)" +
                          "VALUES ('" + mode + "', '" + player + "', " + realTimeSeconds + ", '" + realTimeString + "', " + gameTimeSeconds + ", " +
                          "'" + gameTimeString + "', '" + comment + "', '" + videoURL + "');");
            }
            else
            {
                ExecuteUpdate("INSERT INTO Scores (Mode, Player, RealTimeSeconds, RealTimeString, GameTimeSeconds, GameTimeString, Comment, VideoURL)" +
                          "VALUES ('" + mode + "', '" + player + "', " + realTimeSeconds + ", '" + realTimeString + "', " + gameTimeSeconds + ", " +
                          "'" + gameTimeString + "', '" + comment + "', '" + videoURL + "');");
            }
            
        }

        public List<Score> GetTimes(string mode)
        {
            SqlCeDataReader reader;
            List<Score> scoreList = new List<Score>();
            int rank = 1;

            EscapeString(mode);

            if (mode == "Any%GT")
            {
                reader = ExecuteQuery("SELECT * FROM Scores WHERE Mode = '" + mode + "' ORDER BY GameTimeSeconds, RealTimeSeconds;");
            }
            else
            {
                reader = ExecuteQuery("SELECT * FROM Scores WHERE Mode = '" + mode + "' ORDER BY RealTimeSeconds;");
            }

            while (reader.Read())
            {
                string player = (string)reader["Player"];
                string realTimeString = (string)reader["RealTimeString"];
                string gameTimeString = (string)reader["GameTimeString"];
                int realTimeSeconds = (int)reader["RealTimeSeconds"];
                int gameTimeSeconds = (int)reader["GameTimeSeconds"] * 60;
                string comment = HttpUtility.HtmlEncode((string)reader["Comment"]);
                string videoURL = (string)reader["VideoURL"];
                
                Score score = new Score(mode, player, realTimeString, realTimeSeconds, gameTimeString, gameTimeSeconds, videoURL, comment);
                score.setRank(rank);

                scoreList.Add(score);
                rank++;
            }

            return scoreList;
        }

        public void ExecuteUpdate(string sqlCommand)
        {
            SqlCeCommand cmd = new SqlCeCommand(sqlCommand, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public SqlCeDataReader ExecuteQuery(string sqlCommand)
        {
            SqlCeCommand cmd = new SqlCeCommand(sqlCommand, con);
            SqlCeDataReader reader = cmd.ExecuteReader();
            cmd.Dispose();

            return reader;
        }

        public string EscapeString(string stringValue)
        {
            if (stringValue == null)
            {
                return null;
            }
            else
            {
                return stringValue.Replace("'", "''");
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperMetroidLeaderboard
{
    public partial class AddTime : System.Web.UI.Page
    {
        bool isAnyGameTimeForm;
        string leaderboardType;
        string mode;

        protected void Page_Load(object sender, EventArgs e)
        {
            submitButton.Click += new EventHandler(submitButton_Click);

            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (Request.QueryString["mode"] == null)
            {
                Response.Redirect("Main.aspx");
            }

            switch(Request.QueryString["mode"])
            {
                case "anyrealtime":
                    gameTimePlaceHolder.Visible = false;
                    titleLiteral.Text = "<h2>Add Time: Real Time</h2>";
                    leaderboardType = "Any%RealTime";
                    mode = "Any%RT";
                    break;
                case "anygametime":
                    gameTimePlaceHolder.Visible = true;
                    titleLiteral.Text = "<h2>Add Time: Game Time</h2>";
                    leaderboardType = "Any%GameTime";
                    mode = "Any%GT";
                    break;
                case "100percent":
                    gameTimePlaceHolder.Visible = false;
                    titleLiteral.Text = "<h2>Add Time: 100%</h2>";
                    leaderboardType = "100%";
                    mode = "100%RT";
                    break;
                case "100percentmap":
                    gameTimePlaceHolder.Visible = false;
                    titleLiteral.Text = "<h2>Add Time: 100% Map Completion</h2>";
                    leaderboardType = "100%Map";
                    mode = "100%Map";
                    break;
                case "lowpercentice":
                    gameTimePlaceHolder.Visible = false;
                    titleLiteral.Text = "<h2>Add Time: Low% Ice Beam Route</h2>";
                    leaderboardType = "Low%Ice";
                    mode = "Low%Ice";
                    break;
                case "lowpercentspeed":
                    gameTimePlaceHolder.Visible = false;
                    titleLiteral.Text = "<h2>Add Time: Low% Speed Booster Route</h2>";
                    leaderboardType = "Low%Speed";
                    mode = "Low%Speed";
                    break;
            }
        }

        void submitButton_Click(object sender, EventArgs e)
        {
            string realTimeString = realTimeTextBox.Text;
            string gameTimeString = gameTimeTextBox.Text;
            string comment = commentTextBot.Text;
            string videoURL = videoLinkTextBox.Text;
            string player = Session["username"].ToString();

            int realTimeSeconds;
            int gameTimeSeconds;

            if (leaderboardType == "Any%GameTime")
            {
                if (realTimeString == "" || gameTimeString == "")
                {
                    StatusLiteral.Text = "Please fill out the time fields";
                }
                else
                {
                    FormattedTime formattedRealTime = TimeValidator.GetFormattedTime(realTimeString);
                    FormattedTime formattedGameTime = TimeValidator.GetFormattedTime(gameTimeString);

                    if (formattedRealTime.getTimeSeconds() == -1 || formattedGameTime.getTimeSeconds() == -1)
                    {
                        StatusLiteral.Text = "Invalid times";
                    }
                    else
                    {
                        realTimeSeconds = formattedRealTime.getTimeSeconds();
                        gameTimeSeconds = formattedGameTime.getTimeSeconds();
                        realTimeString = formattedRealTime.getTimeString();
                        gameTimeString = formattedGameTime.getTimeString();

                        Score score = new Score(mode, player, realTimeString, realTimeSeconds, gameTimeString, gameTimeSeconds, videoURL, comment);

                        Database db = new Database();
                        db.Connect();
                        db.AddTime(score);
                        db.Close();

                        StatusLiteral.Text = "Successfully added time";

                        Response.Redirect("SuccessPage.aspx?successCode=addGameTime");
                    }
                }
            }
            else if (leaderboardType == "Any%RealTime" || leaderboardType == "100%" || leaderboardType == "Low%Ice" || leaderboardType == "Low%Speed" 
                  || leaderboardType == "100%Map")
            {
                if (realTimeString == "")
                {
                    StatusLiteral.Text = "Please fill out the time field";
                }
                else
                {
                    FormattedTime formattedRealTime = TimeValidator.GetFormattedTime(realTimeString);

                    if (formattedRealTime.getTimeSeconds() == -1)
                    {
                        StatusLiteral.Text = "Invalid time";
                    }
                    else
                    {
                        realTimeSeconds = formattedRealTime.getTimeSeconds();
                        realTimeString = formattedRealTime.getTimeString();

                        Score score = new Score(mode, player, realTimeString, realTimeSeconds, videoURL, comment);

                        Database db = new Database();
                        db.Connect();
                        db.AddTime(score);
                        db.Close();

                        StatusLiteral.Text = "Successfully added time";

                        Response.Redirect("SuccessPage.aspx?successCode=addRealTime");
                    }
                }
            }
        }
    }
}
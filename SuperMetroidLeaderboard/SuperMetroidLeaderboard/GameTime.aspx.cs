﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperMetroidLeaderboard
{
    public partial class GameTime : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            aspSubmitButton.Click += new EventHandler(aspSubmitButton_Click);

            Database db = new Database();
            db.Connect();
            List<Score> scoreList = db.GetTimes("Any%GT");
            db.Close();

            GameTimeRepeater.DataSource = scoreList;
            GameTimeRepeater.DataBind();
        }

        void aspSubmitButton_Click(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Response.Redirect("AddTime.aspx?mode=anygametime");
            }
            else
            {
                Response.Redirect("Login.aspx?redirect=anygametime");
            }
        }
    }
}
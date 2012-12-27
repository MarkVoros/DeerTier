using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperMetroidLeaderboard
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LogOutButton.Click += new EventHandler(LogOutButton_Click);

            if (Session["username"] != null)
            {
                loggedOutControls.Visible = false;
                usernameLiteral.Text = Session["username"].ToString();
            }
            else
            {
                loggedInControls.Visible = false;
            }
        }

        void LogOutButton_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Main.aspx");
        }
    }
}
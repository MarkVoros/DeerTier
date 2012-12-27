using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperMetroidLeaderboard
{
    public partial class SuccessPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request.QueryString["successCode"])
            {
                case "addRealTime":
                    SuccessMessageLiteral.Text = "Successfully added time!";
                    break;
                case "addGameTime":
                    SuccessMessageLiteral.Text = "Successfully added Game Time!";
                    break;
                case "signUp":
                    SuccessMessageLiteral.Text = "Registration successful!";
                    break;
                default:
                    Response.Redirect("Main.aspx");
                    break;
            }
        }
    }
}
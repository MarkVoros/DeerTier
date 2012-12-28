using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperMetroidLeaderboard
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SubmitButton.Click += new EventHandler(SubmitButton_Click);

            if (Session["username"] != null)
            {
                Response.Redirect("Main.aspx");
            }
        }

        void SubmitButton_Click(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text == "" || PasswordTextBox.Text == "")
            {
                StatusLiteral.Text = "Please complete all of the fields";
            }
            else
            {
                string username = UsernameTextBox.Text;
                string password = PasswordTextBox.Text;
                string hashedPassword = MD5Util.EncodePassword(password);
                
                Database db = new Database();
                db.Connect();

                if (db.UserExists(username) == false)
                {
                    StatusLiteral.Text = "Username does not exist";
                }
                else
                {
                    //check password
                    if (db.PasswordsMatch(username, hashedPassword))
                    {
                        db.Close();

                        Session["username"] = username;
                        string redirectPath = getRedirectPath();
                        Response.Redirect(redirectPath);
                    }
                    else
                    {
                        StatusLiteral.Text = "Incorrect password";
                        db.Close();
                    }
                }
            }
        }

        public string getRedirectPath()
        {
            string redirectQueryString = Request.QueryString["redirect"];
            string redirectPath;

            switch (redirectQueryString)
            {
                case "Main":
                    redirectPath = "Main.aspx";
                    return redirectPath;
                case "anyrealtime":
                    redirectPath = "AddTime.aspx?mode=anyrealtime";
                    return redirectPath;
                case "anygametime":
                    redirectPath = "AddTime.aspx?mode=anygametime";
                    return redirectPath;
                case "100percent":
                    redirectPath = "AddTime.aspx?mode=100percent";
                    return redirectPath;
                case "100percentmap":
                    redirectPath = "AddTime.aspx?mode=100percentmap";
                    return redirectPath;
                case "lowpercentice":
                    redirectPath = "AddTime.aspx?mode=lowpercentice";
                    return redirectPath;
                case "lowpercentspeed":
                    redirectPath = "AddTime.aspx?mode=lowpercentspeed";
                    return redirectPath;
                case "gtcode":
                    redirectPath = "AddTime.aspx?mode=gtcode";
                    return redirectPath;
                case "rbo":
                    redirectPath = "AddTime.aspx?mode=rbo";
                    return redirectPath;
                case "powerbombs":
                    redirectPath = "AddTime.aspx?mode=powerbombs";
                    return redirectPath;
                default:
                    return "Main.aspx";
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperMetroidLeaderboard
{
    public partial class SignUp : System.Web.UI.Page
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
            if (UsernameTextbox.Text == "" || PasswordTextbox.Text == "" || ConfirmedPasswordTextbox.Text == "")
            {
                StatusLiteral.Text = "Please complete all of the fields";
            }
            else if (PasswordTextbox.Text != ConfirmedPasswordTextbox.Text)
            {
                StatusLiteral.Text = "Passwords do not match";
            }
            else
            {
                string username = UsernameTextbox.Text;
                string password = PasswordTextbox.Text;
                string hashedPassword;
                
                Database db = new Database();
                db.Connect();

                if (db.UserExists(username))
                {
                    StatusLiteral.Text = "Username already exists";
                    db.Close();
                }
                else
                {
                    hashedPassword = MD5Util.EncodePassword(password);
                    db.AddUser(username, hashedPassword);
                    db.Close();

                    Session["username"] = username;
                    Response.Redirect("SuccessPage.aspx?successCode=signUp");
                }
            }
        }
    }
}
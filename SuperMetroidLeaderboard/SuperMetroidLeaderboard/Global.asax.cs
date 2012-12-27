using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace SuperMetroidLeaderboard
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //var routes = RouteTable.Routes;
            //routes.MapPageRoute("Main", "", "~/Main.aspx");
            //routes.MapPageRoute("Login", "login", "~/Login.aspx");
            //routes.MapPageRoute("SignUp", "signup", "~/SignUp.aspx");
            //routes.MapPageRoute("Success", "success", "~/SuccessPage.aspx");
            //routes.MapPageRoute("Any%GameTime", "gametime", "~/GameTime.aspx");
            //routes.MapPageRoute("Any%RealTime", "realtime", "~/RealTime.aspx");
            //routes.MapPageRoute("AddTime", "addtime", "~/AddTime.aspx");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
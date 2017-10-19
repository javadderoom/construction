using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebPages
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(System.Web.Routing.RouteTable.Routes);
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
        void RegisterRoutes(System.Web.Routing.RouteCollection routes)
        {
            //routes.MapPageRoute("R1", "Default", "~/Default.aspx");
            //routes.MapPageRoute("R2", "CityinfoManager", "~/CityData.aspx");
            //routes.MapPageRoute("R7", "ورود", "~/Login.aspx");
            //routes.MapPageRoute("R3", "City/{cityID}", "~/ShowCity.aspx");
            //routes.MapPageRoute("R4", "City", "~/ShowCity.aspx");
            //routes.MapPageRoute("R5", "Software/{categoryName}/{softID}", "~/SoftwareInfo.aspx");

        }
    }
}
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
            routes.MapPageRoute("R1", "ناحیه_کاربری", "~/Panels/EmployeePanel/profile.aspx");
            routes.MapPageRoute("R2", "ناحیه-کاربری", "~/Panels/UserPanel/profile.aspx");
            routes.MapPageRoute("R3", "مدیریت-وبلاگ-ها", "~/Panels/Admin/ManageBlogs.aspx");
            routes.MapPageRoute("R4", "ارسال-پیام-دسته-جمعی", "~/Panels/Admin/NewMessageGroup.aspx");
            routes.MapPageRoute("R5", "ارسال__پیام__جدید", "~/Panels/Admin/newMesaageAdmin.aspx");
            routes.MapPageRoute("R6", "ویرایش-وبلاگ", "~/Panels/Admin/EditPost.aspx");
            routes.MapPageRoute("R7", "همه__پیام__ها", "~/Panels/Admin/MessagesAdmin.aspx");
            routes.MapPageRoute("R8", "همه_پیام_ها", "~/Panels/EmployeePanel/MessagesEmployee.aspx");
            routes.MapPageRoute("R9", "پیام-ها", "~/Panels/UserPanel/Messages.aspx");
            routes.MapPageRoute("R10", "ورود", "~/Login.aspx");
            routes.MapPageRoute("R11", "", "~/_construction/Index.aspx");
            routes.MapPageRoute("R11.5", "وبلاگ-ها", "~/_construction/Blogs.aspx");

            //routes.MapPageRoute("R12", "وبلاگ-ها/{id}", "~/_construction/BlogPost.aspx");
            routes.MapPageRoute("R12", "وبلاگ-ها{id}/", "~/_construction/BlogPost.aspx");




            routes.MapPageRoute("R13", "افزودن-وبلاگ-جدید", "~/Panels/Admin/AddBlog.aspx");
            //routes.MapPageRoute("R14", "", "");
            //routes.MapPageRoute("R15", "", "");
            //routes.MapPageRoute("R16", "", "");
            //routes.MapPageRoute("R17", "", "");
            //routes.MapPageRoute("R18", "", "");
            //routes.MapPageRoute("R19", "", "");
            //routes.MapPageRoute("R20", "", "");
            //routes.MapPageRoute("R21", "", "");
            //routes.MapPageRoute("R22", "", "");
            //routes.MapPageRoute("R23", "", "");
            //routes.MapPageRoute("R24", "", "");
            //routes.MapPageRoute("R5", "Software/{categoryName}/{softID}", "~/SoftwareInfo.aspx");

        }
    }
}
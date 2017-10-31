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
            //matual
            routes.MapPageRoute("R1", "Blogs/{id}/{text}", "~/_construction/BlogPost.aspx");
            routes.MapPageRoute("R2", "Blogs", "~/_construction/Blogs.aspx");
            routes.MapPageRoute("R3", "", "~/_construction/Index.aspx");
            routes.MapPageRoute("R4", "Projects", "~/_construction/Projects.aspx");
            routes.MapPageRoute("R5", "Projects/{id}/{text}", "~/_construction/ShowProject.aspx");
            routes.MapPageRoute("R6", "Login", "~/Login.aspx");
            routes.MapPageRoute("R7", "AboutUs", "~/_construction/AboutUs.aspx");
            routes.MapPageRoute("R8", "Services", "~/_construction/Services.aspx");

            //admin
            routes.MapPageRoute("R16", "Admin/AddBlog", "~/Panels/Admin/AddBlog.aspx");
            //routes.MapPageRoute("R7", "Admin/AddProject", "~/Panels/Admin/AddProject.aspx");
            routes.MapPageRoute("R8", "Admin/EditBlog", "~/Panels/Admin/EditPost.aspx");
            routes.MapPageRoute("R9", "Admin/EditProject", "~/Panels/Admin/EditProject.aspx");
            routes.MapPageRoute("R10", "Admin/EditSlider/{id}", "~/Panels/Admin/EditSlider.aspx");
            //routes.MapPageRoute("R11", "Admin/EmployeeInfo", "~/Panels/Admin/EmployeeInfo.aspx");


            routes.MapPageRoute("R14", "Admin/ManageBlogs", "~/Panels/Admin/ManageBlogs.aspx");
            routes.MapPageRoute("R14", "Admin/ManageFirstPage", "~/Panels/Admin/ManageFirstPage.aspx");
            //routes.MapPageRoute("R14", "Admin/ManageBlogGroups", "~/Panels/Admin/ManageGroups.aspx");
            //routes.MapPageRoute("R14", "Admin/ManageProjectGroups", "~/Panels/Admin/ManageProjectGroups.aspx");
            //routes.MapPageRoute("R14", "Admin/ManageProjects", "~/Panels/Admin/ManageProjects.aspx");
            //routes.MapPageRoute("R14", "Admin/ManageUsersAndEmployees", "~/Panels/Admin/ManageUsersAndEmployees.aspx");





            //routes.MapPageRoute("R1", "EmployeePanel", "~/Panels/EmployeePanel/profile.aspx");
            //routes.MapPageRoute("R2", "UserPanel", "~/Panels/UserPanel/profile.aspx");

            //routes.MapPageRoute("R4", "GroupMessage", "~/Panels/Admin/NewMessageGroup.aspx");
            //routes.MapPageRoute("R5", "AdminNewMessage", "~/Panels/Admin/newMesaageAdmin.aspx");

            //routes.MapPageRoute("R7", "AdminAllMessages", "~/Panels/Admin/MessagesAdmin.aspx");
            //routes.MapPageRoute("R8", "EmployeeInbox", "~/Panels/EmployeePanel/MessagesEmployee.aspx");
            //routes.MapPageRoute("R9", "UserInbox", "~/Panels/UserPanel/Messages.aspx");




            //routes.MapPageRoute("R14", "UserInfo", "~/Panels/Admin/UserInfo.aspx");



            //routes.MapPageRoute("R18", "", "ListForGroupMessage");
            //routes.MapPageRoute("R19", "", "ListForMessage");
            //routes.MapPageRoute("R20", "", "");
            //routes.MapPageRoute("R21", "", "");
            //routes.MapPageRoute("R22", "", "");
            //routes.MapPageRoute("R23", "", "");
            //routes.MapPageRoute("R24", "", "");
            //routes.MapPageRoute("R5", "Software/{categoryName}/{softID}", "~/SoftwareInfo.aspx");

        }
    }
}
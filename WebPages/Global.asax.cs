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
            HttpContext.Current.Response.AddHeader("x-frame-options", "DENY");
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

        private void RegisterRoutes(System.Web.Routing.RouteCollection routes)
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
            routes.MapPageRoute("R99", "Register", "~/Register.aspx");
            routes.MapPageRoute("R990", "ForgotPass", "~/FoegotPass.aspx");
            routes.MapPageRoute("R9", "AdminLogin", "~/AdminLogin.aspx");

            //admin
            routes.MapPageRoute("R10", "Admin/AddBlog", "~/Panels/Admin/AddBlog.aspx");
            routes.MapPageRoute("R11", "Admin/AddProject", "~/Panels/Admin/AddProject.aspx");
            routes.MapPageRoute("R12", "Admin/EditBlog", "~/Panels/Admin/EditPost.aspx");
            routes.MapPageRoute("R13", "Admin/EditProject", "~/Panels/Admin/EditProject.aspx");
            routes.MapPageRoute("R14", "Admin/EditSlider/{id}", "~/Panels/Admin/EditSlider.aspx");
            routes.MapPageRoute("R15", "Admin/ManageUsers/EmployeeInfo", "~/Panels/Admin/EmployeeInfo.aspx");
            routes.MapPageRoute("R16", "Admin/AddProject/AddEmployeeToProject", "~/Panels/Admin/EmployeesFilterByJob.aspx");
            routes.MapPageRoute("R17", "Admin/GroupMessage", "~/Panels/Admin/ListForGroupMessage.aspx");
            routes.MapPageRoute("R18", "Admin/Message", "~/Panels/Admin/ListForMessage.aspx");
            routes.MapPageRoute("R19", "Admin/ManageBlogs", "~/Panels/Admin/ManageBlogs.aspx");
            routes.MapPageRoute("R20", "Admin/ManageFirstPage", "~/Panels/Admin/ManageFirstPage.aspx");
            routes.MapPageRoute("R21", "Admin/ManageGroups", "~/Panels/Admin/ManageGroups.aspx");
            routes.MapPageRoute("R22", "Admin/ManageProjects", "~/Panels/Admin/ManageProjects.aspx");
            routes.MapPageRoute("R23", "Admin/ManageUsers", "~/Panels/Admin/ManageUsersAndEmployees.aspx");
            routes.MapPageRoute("R24", "Admin/Inbox", "~/Panels/Admin/MessageInboxAdmin.aspx");
            routes.MapPageRoute("R25", "Admin/Inbox/SelectedMessage", "~/Panels/Admin/MessagesAdmin.aspx");
            routes.MapPageRoute("R26", "Admin/Message/NewMessage", "~/Panels/Admin/newMesaageAdmin.aspx");
            routes.MapPageRoute("R27", "Admin/GroupMessage/NewGroupMessage", "~/Panels/Admin/NewMessageGroup.aspx");
            routes.MapPageRoute("R28", "Admin/Orders", "~/Panels/Admin/ordersList.aspx");
            routes.MapPageRoute("R29", "Admin/Orders/OrderDetail", "~/Panels/Admin/ProjectDetail.aspx");
            routes.MapPageRoute("R32", "Admin/Scores", "~/Panels/Admin/Scores.aspx");
            routes.MapPageRoute("R30", "Admin/ManageUsers/UserInfo", "~/Panels/Admin/UserInfo.aspx");
            routes.MapPageRoute("R50", "Admin/ManageJobGroups", "~/Panels/Admin/ManageJobGroups.aspx");
            //Employee
            routes.MapPageRoute("R31", "Employee/Profile", "~/Panels/EmployeePanel/profile.aspx");
            //routes.MapPageRoute("R32", "Employee/ChangeInfo", "~/Panels/EmployeePanel/ChangeInfo.aspx");
            routes.MapPageRoute("R33", "Employee/SelectJob", "~/Panels/EmployeePanel/SelectJob.aspx");
            routes.MapPageRoute("R34", "Employee/Inbox", "~/Panels/EmployeePanel/MessageInboxEmployee.aspx");
            routes.MapPageRoute("R35", "Employee/Inbox/SelectedMessage", "~/Panels/EmployeePanel/MessagesEmployee.aspx");
            routes.MapPageRoute("R36", "Employee/NewMessage", "~/Panels/EmployeePanel/newMessageEmployee.aspx");

            //User
            routes.MapPageRoute("R37", "User/Profile", "~/Panels/UserPanel/profile.aspx");
            //routes.MapPageRoute("R38", "User/ChangeInfo", "~/Panels/UserPanel/ChangeInfo.aspx");
            routes.MapPageRoute("R39", "User/OrderNewProject", "~/Panels/UserPanel/ProjectApplication.aspx");
            routes.MapPageRoute("R40", "User/Inbox", "~/Panels/UserPanel/MessageInbox.aspx");
            routes.MapPageRoute("R41", "User/Inbox/SelectedMessage", "~/Panels/UserPanel/Messages.aspx");
            routes.MapPageRoute("R42", "User/NewMessage", "~/Panels/UserPanel/newMessage.aspx");
        }
    }
}
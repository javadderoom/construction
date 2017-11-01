using Common;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages.Panels.Admin
{
    public partial class ManageUsersAndEmployees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillGV();
                setRegSeenTrue();
            }
        }

        private void setRegSeenTrue()
        {
            UsersRepository ur = new UsersRepository();
            EmployeesRepository er = new EmployeesRepository();
            ur.setRegSeenToTrue();
            er.setRegSeenToTrue();
        }

        private void fillGV()
        {
            UsersRepository ur = new UsersRepository();
            gvUsers.DataSource = ur.getAllUsersAndEmployeesForMessage();
            gvUsers.DataBind();
        }

        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "view")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvUsers.Rows[index];
                int userid = row.Cells[0].Text.ToInt();
                Session.Add("useridForAdminDetails", userid);
                if (userid % 2 == 0)
                {
                    //karmand
                    Response.Redirect("Admin/ManageUsers/EmployeeInfo");
                }
                else
                {
                    Response.Redirect("/Admin/ManageUsers/UserInfo");
                }
            }
        }

        protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            this.gvUsers.Columns[2].Visible = false;
        }

        protected void btnViewAll_ServerClick(object sender, EventArgs e)
        {
            fillGV();
            tbxSearch.Value = "";
        }

        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            string txt = tbxSearch.Value;
            UsersRepository ur = new UsersRepository();
            gvUsers.DataSource = ur.searchUserUnionEmployee(txt);
            gvUsers.DataBind();
        }

        protected void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsers.PageIndex = e.NewPageIndex;
            fillGV();
        }
    }
}
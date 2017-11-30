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
            if (Session["adminid"] != null)
            {
                if (!IsPostBack)
                {
                    fillGV();
                }
            }
            else
            {
                Response.Redirect("/AdminLogin");
            }
        }

        private void setEmpRegSeenTrue(int empid)
        {
            EmployeesRepository er = new EmployeesRepository();
            er.setRegSeenToTrue(empid);
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
                    setEmpRegSeenTrue(userid);
                    Response.Redirect("/Admin/ManageUsers/EmployeeInfo");
                }
                else
                {
                    setUserRegSeenTrue(userid);
                    Response.Redirect("/Admin/ManageUsers/UserInfo");
                }
            }
            if (e.CommandName == "delete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvUsers.Rows[index];
                int userid = row.Cells[0].Text.ToInt();
                Session.Add("useridForAdminDetails", userid);

                if (userid % 2 == 0)
                {
                    //karmand
                    EmployeesRepository ep = new EmployeesRepository();
                    if (ep.DeleteEmployee(userid))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('حذف انجام شد'),window.location ='/Admin/ManageUsers'", true);//لینک بشه
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('مشکلی پیش آمد ، لطفا دوباره امتحان کنید اگر حل نشد با پشتیبانی تماس بگیرید ');", true);
                    }
                    //Response.Redirect("/Admin/ManageUsers/EmployeeInfo");
                }
                else
                {
                    UsersRepository ur = new UsersRepository();

                    if (ur.DeleteUser(userid))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('حذف انجام شد'),window.location ='/Admin/ManageUsers'", true);//لینک بشه
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('مشکلی پیش آمد ، لطفا دوباره امتحان کنید اگر حل نشد با پشتیبانی تماس بگیرید ');", true);
                    }
                    // Response.Redirect("/Admin/ManageUsers/UserInfo");
                }
            }
        }

        private void setUserRegSeenTrue(int userid)
        {
            UsersRepository ur = new UsersRepository();
            ur.setRegSeenToTrue(userid);
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
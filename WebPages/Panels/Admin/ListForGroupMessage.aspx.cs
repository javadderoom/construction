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
    public partial class ListForGroupMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminid"] != null)
            {
                if (!IsPostBack)
                {
                    fillGrid();
                }
            }
            else
            {
                Response.Redirect("/AdminLogin");
            }
        }

        private void fillGrid()
        {
            UsersRepository ur = new UsersRepository();
            gvChats.DataSource = ur.getAllUsersAndEmployeesForMessage();
            gvChats.DataBind();
        }

        protected void btnViewAll_ServerClick(object sender, EventArgs e)
        {
            fillGrid();
        }

        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            UsersRepository ur = new UsersRepository();
            gvChats.DataSource = ur.SearchFor_getAllUsersAndEmployeesForMessage(tbxSearch.Value);
            gvChats.DataBind();
        }

        protected void gvChats_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void gvChats_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

        protected void btnSend_ServerClick(object sender, EventArgs e)
        {
            List<int> list = new List<int>();
            foreach (GridViewRow r in gvChats.Rows)
            {
                int i = r.Cells[1].Text.ToInt();
                CheckBox chkRow = (r.Cells[0].FindControl("chk") as CheckBox);
                if (chkRow.Checked)
                    list.Add(i);
            }
            if (list.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('هیچ کاربری انتخاب نشده است.حداقل یک کاربر را انتخاب کنید.');", true);
                return;
            }
            NewMessageGroup.list = list;
            Response.Redirect("/Admin/GroupMessage/NewGroupMessage");
        }

        protected void checkAll_CheckedChanged(object sender, EventArgs e)
        {
        }

        protected void gvChats_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvChats.PageIndex = e.NewPageIndex;
            fillGrid();
        }
    }
}
using Common;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages.Panels.EmployeePanel
{
    public partial class MessageInboxEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["employeeid"] != null)
            {
                if (!IsPostBack)
                {
                    fillGV();
                }
            }
            else
            {
                Response.Redirect("~/Login");
            }
        }

        private void fillGV()
        {
            int id = Session["employeeid"].ToString().ToInt();
            ChatsRepository cr = new ChatsRepository();
            gvChats.DataSource = cr.Inbox(id);
            gvChats.DataBind();
        }

        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            int id = Session["employeeid"].ToString().ToInt();
            ChatsRepository cr = new ChatsRepository();
            gvChats.DataSource = cr.Search(id, tbxSearch.Value);
            gvChats.DataBind();
        }

        protected void btnViewAll_ServerClick(object sender, EventArgs e)
        {
            fillGV();
        }

        protected void gvChats_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            this.gvChats.Columns[3].Visible = false;
        }

        protected void gvChats_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvChats.Rows[index];
            int chatid = row.Cells[0].Text.ToInt();
            Session.Add("chatidForMessages", chatid);
            if (e.CommandName == "view")
            {
                MessageRepository mr = new MessageRepository();
                mr.setMessagesSeenToTrue(Session["chatidForMessages"].ToString().ToInt(), "adm");

                Response.Redirect("/Employee/SelectedMessage");
            }
        }

        protected void gvChats_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvChats.PageIndex = e.NewPageIndex;
            fillGV();
        }
    }
}
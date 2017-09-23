using Common;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages.Panels.UserPanel
{
    public partial class MessageInbox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("userid", 1);
            if (!IsPostBack)
            {
                fillGV();
            }
        }

        private void fillGV()
        {
            int id = Session["userid"].ToString().ToInt();
            ChatsRepository cr = new ChatsRepository();
            gvChats.DataSource = cr.Inbox(id);
            gvChats.DataBind();
        }

        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            int id = Session["userid"].ToString().ToInt();
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
            if (e.CommandName == "view")
            {
                MessageRepository mr = new MessageRepository();
                mr.setMessagesSeenToTrue(row.Cells[0].Text.ToInt(), "adm");
                //Response.Redirect("");
            }
        }
    }
}
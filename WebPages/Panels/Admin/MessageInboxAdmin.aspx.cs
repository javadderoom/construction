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
    public partial class MessageInboxAdmin : System.Web.UI.Page
    {

        int adminid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            adminid = Session["adminid"].ToString().ToInt();
            if (!IsPostBack)
            {

                fillGrid();
            }

        }

        private void fillGrid()
        {
            ChatsRepository cr = new ChatsRepository();
            gvChats.DataSource = cr.InboxAdmin(adminid);
            gvChats.DataBind();
        }

        protected void gvChats_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            this.gvChats.Columns[1].Visible = false;
            this.gvChats.Columns[7].Visible = false;
        }

        protected void gvChats_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "view")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvChats.Rows[index];
                int chatid = row.Cells[0].Text.ToInt();
                Session.Add("chatidforMessages", chatid);
                int userid = row.Cells[1].Text.ToInt();
                Session.Add("useridforMessages", userid);
                MessageRepository mr = new MessageRepository();
                mr.setMessagesSeenToTrueForAdmin(chatid);

                Response.Redirect("~/همه__پیام__ها");
            }
        }

        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            MessageRepository mr = new MessageRepository();
            gvChats.DataSource = mr.Search_adminInbox(tbxSearch.Value, adminid);
            gvChats.DataBind();
        }

        protected void btnViewAll_ServerClick(object sender, EventArgs e)
        {
            fillGrid();
        }
    }
}
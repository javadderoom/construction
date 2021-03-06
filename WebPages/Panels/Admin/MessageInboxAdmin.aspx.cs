﻿using Common;
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
        private int adminid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminid"] != null)
            {
                adminid = Session["adminid"].ToString().ToInt();
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
                string userid = row.Cells[2].Text;
                Session.Add("useridforMessages", userid);
                MessageRepository mr = new MessageRepository();
                mr.setMessagesSeenToTrueForAdmin(chatid);

                Response.Redirect("/Admin/Inbox/SelectedMessage");
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

        protected void gvChats_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvChats.PageIndex = e.NewPageIndex;
            fillGrid();
        }
    }
}
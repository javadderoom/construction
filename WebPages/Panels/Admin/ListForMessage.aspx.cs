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
    public partial class ListForMessage : System.Web.UI.Page
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
            if (e.CommandName == "sendpm")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvChats.Rows[index];
                int userid = row.Cells[0].Text.ToInt();
                Session.Add("useridForNewMessage", userid);

                Response.Redirect("/Admin/Message/NewMessage");
            }
        }

        protected void gvChats_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvChats.PageIndex = e.NewPageIndex;
            fillGrid();
        }
    }
}
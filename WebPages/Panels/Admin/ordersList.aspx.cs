using Common;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages.Panels.Admin
{
    public partial class ordersList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillGrid();
            }
        }

        private void fillGrid()
        {
            OrderRepository or = new OrderRepository();
            DataTable dt = or.getAllOrders();
            gvChats.DataSource = dt;
            gvChats.DataBind();
        }

        protected void gvChats_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "view")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvChats.Rows[index];
                int orderid = row.Cells[0].Text.ToInt();
                Session.Add("orderidForDetails", orderid);
                Response.Redirect("http://localhost:6421/Panels/Admin/ProjectDetail.aspx");
            }
        }

        protected void gvChats_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}
using Common;
using DataAccess;
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
    public partial class ProjectDetail : System.Web.UI.Page
    {
        int orderid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminid"] != null)
            {
                orderid = Session["orderidForDetails"].ToString().ToInt();
                if (!IsPostBack)
                {
                    setLabels();
                }
            }
            else
            {
                Response.Redirect("/AdminLogin");
            }
        }

        private void setLabels()
        {
            OrderRepository or = new OrderRepository();
            DataTable dt = or.getOrderByID(orderid);
            FullName.Value = dt.Rows[0][13].ToString();
            mobile.Value = dt.Rows[0][14].ToString();
            email.Value = dt.Rows[0][15].ToString();
            onvan.Value = dt.Rows[0][1].ToString();
            startDate.Value = dt.Rows[0][6].ToString();
            finishDate.Value = dt.Rows[0][7].ToString();
            budget.Value = dt.Rows[0][5].ToString();
            desc.Value = dt.Rows[0][3].ToString();
            ostan.Value = dt.Rows[0][12].ToString();
            city.Value = dt.Rows[0][11].ToString();
            address.Value = dt.Rows[0][10].ToString();
        }
    }
}
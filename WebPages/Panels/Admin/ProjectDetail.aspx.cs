using Common;
using DataAccess;
using System;
using System.Collections.Generic;
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
            orderid = Session["orderidForDetails"].ToString().ToInt();
            if (!IsPostBack)
            {
                setLabels();
            }
        }

        private void setLabels()
        {
            Order o =
        }
    }
}
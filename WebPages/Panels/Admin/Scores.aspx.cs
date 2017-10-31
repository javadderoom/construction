using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using DataAccess.Repository;

namespace WebPages.Panels.Admin
{
    public partial class Scores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void fillGv()
        {
            //EmployeesRepository er = new EmployeesRepository();
            //gvEmployees.DataSource = er.getEmployeeForScore();
            //gvEmployees.DataBind();
        }
    }
}
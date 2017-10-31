using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using DataAccess.Repository;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Common;
using System.Web.UI.HtmlControls;

namespace WebPages.Panels.Admin
{
    public partial class Scores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillGv();
            }
        }

        private void fillGv()
        {
            EmployeesRepository er = new EmployeesRepository();
            DataTable source = er.getEmployeeForScore();
            gvEmployees.DataSource = source;
            gvEmployees.DataBind();
            int count = er.getEmployeeForScore().Rows.Count;
            for (int i = 0; i < count; i++)
            {
                GridViewRow row = gvEmployees.Rows[i];
                var input = new HtmlInputGenericControl("number");
                input = (HtmlInputGenericControl)row.FindControl("Score");
                input.Value = er.getEmployeeForScore().Rows[i][6].ToString();
            }
        }

        protected void btnSabt_ServerClick(object sender, EventArgs e)
        {
            save();
            fillGv();
        }

        private EmployeesRepository er = new EmployeesRepository();

        private void save()
        {
            int count = er.getEmployeeForScore().Rows.Count;
            for (int i = 0; i < count; i++)
            {
                GridViewRow row = gvEmployees.Rows[i];
                string rr = row.Cells[0].Text;
                int id = rr.ToInt();
                Employee emp = er.getEmployeeByID(id);
                int score = ((HtmlInputGenericControl)row.FindControl("Score")).Value.ToInt();
                if (emp.Score != score)
                {
                    emp.Score = score;
                }
                er.SaveEmployees(emp);
            }
        }

        protected void gvEmployees_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //this.gvEmployees.Columns[4].Visible = false;
        }
    }
}
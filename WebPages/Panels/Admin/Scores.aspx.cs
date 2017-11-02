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
            if (Session["adminid"] != null)
            {

                if (!IsPostBack)
                {
                    fillGv();
                    fillDDLs();
                }
            }
            else
            {
                Response.Redirect("/AdminLogin");




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

        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            gvEmployees.DataSource = er.searchEmployeeForScores(tbxSearch.Value);
            gvEmployees.DataBind();
            for (int i = 0; i < gvEmployees.Rows.Count; i++)
            {
                GridViewRow row = gvEmployees.Rows[i];
                var input = new HtmlInputGenericControl("number");
                input = (HtmlInputGenericControl)row.FindControl("Score");
                input.Value = er.searchEmployeeForScores(tbxSearch.Value).Rows[i][6].ToString();
            }
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            fillGv();
        }

        private void fillDDLs()
        {
            JobGroupsRepository r = new JobGroupsRepository();
            DDLJobGroup.DataSource = r.getJobGroups();
            DDLJobGroup.DataTextField = "JobGroupTitle";
            DDLJobGroup.DataValueField = "JobGroupID";
            DDLJobGroup.DataBind();
            DDLJobGroup.Items.Insert(0, new ListItem("-", "-1"));

            JobRepository jr = new JobRepository();
            DDLJob.DataSource = jr.getJobsByGroupID(DDLJobGroup.SelectedValue.ToString().ToInt());
            DDLJob.DataTextField = "JobTitle";
            DDLJob.DataValueField = "JobID";
            DDLJob.DataBind();
            DDLJob.Items.Insert(0, new ListItem("-", "-1"));
        }

        protected void DDLJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxSearch.Value = "";
            int job = DDLJob.SelectedValue.ToString().ToInt();
            filterGv(job);
        }

        private void filterGv(int job)
        {
            List<int> emID = new List<int>();
            List<EmployeeScore> s = new List<EmployeeScore>();
            EmployeeJobRepository ej = new EmployeeJobRepository();
            DataTable dt = ej.findEmployeeByJob(job);
            EmployeeScore ss = new EmployeeScore();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                emID.Add(dt.Rows[i][1].ToString().ToInt());
                ss = er.getEmployeeScore(emID[i]);
                s.Add(ss);
            }
            DataTable data = new DataTable();
            data = OnlineTools.ToDataTable(s);
            gvEmployees.DataSource = data;
            gvEmployees.DataBind();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                GridViewRow row = gvEmployees.Rows[i];
                var input = new HtmlInputGenericControl("number");
                input = (HtmlInputGenericControl)row.FindControl("Score");
                input.Value = er.getEmployeeScore(emID[i]).Score.ToString();
            }
        }

        protected void DDLJobGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            JobRepository jr = new JobRepository();
            DDLJob.DataSource = jr.getJobsByGroupID(DDLJobGroup.SelectedValue.ToString().ToInt());
            DDLJob.DataTextField = "JobTitle";
            DDLJob.DataValueField = "JobID";
            DDLJob.DataBind();
            DDLJob.Items.Insert(0, new ListItem("-", "-1"));

            tbxSearch.Value = "";
        }
    }
}
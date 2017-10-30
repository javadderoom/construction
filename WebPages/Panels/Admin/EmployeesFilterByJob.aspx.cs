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
    public partial class EmployeesFilterByJob : System.Web.UI.Page
    {
        const string cChalMemNameConst = "ChalMem_cnst";

        public List<int> loi
        {
            get
            {
                if (!(ViewState[cChalMemNameConst] is List<int>))
                {
                    // need to fix the memory and added to viewstate
                    ViewState[cChalMemNameConst] = new List<int>();
                }

                return (List<int>)ViewState[cChalMemNameConst];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillDDLs();
                fillGrids();
            }
        }

        private void fillDDLs()
        {
            JobGroupsRepository r = new JobGroupsRepository();
            DDLJobGroup.DataSource = r.getJobGroups();
            DDLJobGroup.DataTextField = "JobGroupTitle";
            DDLJobGroup.DataValueField = "JobGroupID";
            DDLJobGroup.DataBind();

            JobRepository jr = new JobRepository();
            DDLJob.DataSource = jr.getJobsByGroupID(DDLJobGroup.SelectedValue.ToString().ToInt());
            DDLJob.DataTextField = "JobTitle";
            DDLJob.DataValueField = "JobID";
            DDLJob.DataBind();
        }

        public void fillGrids()
        {
            //List<int> ids = new List<int>();
            //foreach (GridViewRow row in gvSelected.Rows)
            //{
            //    ids.Add(row.Cells[0].Text.ToString().ToInt());
            //}

            int jobid = DDLJob.SelectedValue.ToString().ToInt();
            EmployeesRepository er = new EmployeesRepository();
            if (loi.Count > 0)
            {
                gvSelected.DataSource = er.getEmployeesInfoInList(loi);
                gvSelected.DataBind();
            }


            gvUsers.DataSource = er.getEmployeesExceptList(loi, jobid);
            gvUsers.DataBind();
        }

        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {

        }

        protected void btnViewAll_ServerClick(object sender, EventArgs e)
        {

        }

        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "view")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvUsers.Rows[index];
                int empid = row.Cells[0].Text.ToInt();
                loi.Add(empid);
                fillGrids();
            }
        }

        protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void DDLJobGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            JobRepository jr = new JobRepository();
            DDLJob.DataSource = jr.getJobsByGroupID(DDLJobGroup.SelectedValue.ToString().ToInt());
            DDLJob.DataTextField = "JobTitle";
            DDLJob.DataValueField = "JobID";
            DDLJob.DataBind();

            fillGrids();
        }

        protected void DDLJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillGrids();
        }

        protected void gvSelected_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "view")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvSelected.Rows[index];
                int empid = row.Cells[0].Text.ToInt();
                loi.Remove(empid);
                if (loi.Count == 0)
                {
                    gvSelected.DataSource = null;
                    gvSelected.DataBind();
                }
                fillGrids();
            }
        }

        protected void gvSelected_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}
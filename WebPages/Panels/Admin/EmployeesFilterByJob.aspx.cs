using Common;
using DataAccess;
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
        private const string cChalMemNameConst = "ChalMem_cnst";

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

        public string viewAll
        {
            get
            {
                return (string)ViewState["fn"];
            }
            set
            {
                ViewState["fn"] = value;
            }
        }

        public string txt
        {
            get
            {
                return (string)ViewState["fn2"];
            }
            set
            {
                ViewState["fn2"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminid"] != null)
            {
                if (!IsPostBack)
                {
                    viewAll = "true";
                    fillDDLs();
                    fillGrids();

                    //EmployeesRepository er = new EmployeesRepository();
                    //gvUsers.DataSource = er.getEmployeesExceptList_All(loi);
                    //gvUsers.DataBind();
                }
            }
            else
            {
                Response.Redirect("/AdminLogin");
            }
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

        public void fillGrids()
        {
            EmployeesRepository er = new EmployeesRepository();
            //List<int> ids = new List<int>();
            //foreach (GridViewRow row in gvSelected.Rows)
            //{
            //    ids.Add(row.Cells[0].Text.ToString().ToInt());
            //}
            if (viewAll == "true")
            {
                if (loi.Count > 0)
                {
                    gvSelected.DataSource = er.getEmployeesInfoInList(loi);
                    gvSelected.DataBind();
                }
                gvUsers.DataSource = er.getEmployeesExceptList_All(loi);
                gvUsers.DataBind();
            }
            else if (viewAll == "search")
            {
                if (loi.Count > 0)
                {
                    gvSelected.DataSource = er.getEmployeesInfoInList(loi);
                    gvSelected.DataBind();
                }
                gvUsers.DataSource = er.getEmployeesExceptList_Search(loi, txt);
                gvUsers.DataBind();
            }
            else if (viewAll == "group")
            {
                if (loi.Count > 0)
                {
                    gvSelected.DataSource = er.getEmployeesInfoInList(loi);
                    gvSelected.DataBind();
                }
                gvUsers.DataSource = er.getEmployeesExceptList_JobGroup(loi, DDLJobGroup.SelectedValue.ToInt());
                gvUsers.DataBind();
            }
            else
            {
                int jobid = DDLJob.SelectedValue.ToString().ToInt();

                if (loi.Count > 0)
                {
                    gvSelected.DataSource = er.getEmployeesInfoInList(loi);
                    gvSelected.DataBind();
                }
                gvUsers.DataSource = er.getEmployeesExceptList(loi, jobid);
                gvUsers.DataBind();
            }

        }

        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            txt = tbxSearch.Value;

            EmployeesRepository er = new EmployeesRepository();
            gvUsers.DataSource = er.getEmployeesExceptList_Search(loi, txt);
            gvUsers.DataBind();
            viewAll = "search";
            DDLJobGroup.SelectedIndex = 0;
            DDLJob.Items.Clear();
        }

        protected void btnViewAll_ServerClick(object sender, EventArgs e)
        {
            EmployeesRepository er = new EmployeesRepository();
            gvUsers.DataSource = er.getEmployeesExceptList_All(loi);
            gvUsers.DataBind();
            viewAll = "true";
            DDLJobGroup.SelectedIndex = 0;
            DDLJob.Items.Clear();

            tbxSearch.Value = "";
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
            DDLJob.Items.Insert(0, new ListItem("-", "-1"));

            viewAll = "group";
            fillGrids();

            tbxSearch.Value = "";
        }

        protected void DDLJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewAll = "false";
            tbxSearch.Value = "";
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

        protected void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsers.PageIndex = e.NewPageIndex;
            fillGrids();
        }

        protected void gvSelected_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSelected.PageIndex = e.NewPageIndex;
            fillGrids();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            EmployeeProjectRepository ep = new EmployeeProjectRepository();
            if (loi.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('هیچ کارمندی انتخاب نشده است!حداقل یک کارمند را انتخاب کنید')", true);
                return;
            }
            int projid = Session["ProjectLastIDForEmployeeFilter"].ToString().ToInt();
            Session.Remove("ProjectLastIDForEmployeeFilter");
            EmployeeProject em;

            foreach (int i in loi)
            {
                em = new EmployeeProject();
                em.EmployeeID = i;
                em.ProjectID = projid;
                ep.SaveEmployeeProject(em);
            }
            Response.Redirect("/Admin/ManageProjects");
        }
    }
}
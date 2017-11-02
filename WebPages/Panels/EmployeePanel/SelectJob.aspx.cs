using Common;
using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages.Panels.EmployeePanel
{
    public partial class SelectJob : System.Web.UI.Page
    {
        private int empid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["employeeid"] != null)
            {
                empid = Session["employeeid"].ToString().ToInt();
                if (!IsPostBack)
                {
                    fillDDL();
                    fillListBox();
                }
            }
            else
            {
                Response.Redirect("~/Login");
            }
        }

        private void fillListBox()
        {
            EmployeeJobRepository ej = new EmployeeJobRepository();
            SelectedSubGroups.DataSource = ej.getEmployeeJobs(empid);
            SelectedSubGroups.DataTextField = "JobTitle";
            SelectedSubGroups.DataValueField = "JobID";
            SelectedSubGroups.DataBind();
        }

        private void fillDDL()
        {
            JobGroupsRepository jgr = new JobGroupsRepository();
            DDLGroups.DataSource = jgr.getJobGroups();
            DDLGroups.DataTextField = "JobGroupTitle";
            DDLGroups.DataValueField = "JobGroupID";
            DDLGroups.DataBind();
            DDLGroups.Items.Insert(0, new ListItem("یک گروه انتخاب کنید", "-2"));
        }

        protected void DDLGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            JobRepository jr = new JobRepository();
            SubGroups.DataSource = jr.getJobsByGroupID(DDLGroups.SelectedValue.ToInt());
            SubGroups.DataTextField = "JobTitle";
            SubGroups.DataValueField = "JobID";
            SubGroups.DataBind();
        }

        protected void AddToSub_Click(object sender, EventArgs e)
        {
            if (SubGroups.SelectedIndex != -1)
            {
                bool isadd = false;
                string text = SubGroups.SelectedItem.Text;
                string value = SubGroups.SelectedItem.Value;
                for (int i = 0; i < SelectedSubGroups.Items.Count; i++)
                {
                    if (SelectedSubGroups.Items[i].Text == text)
                    {
                        isadd = true;
                    }
                }
                if (!isadd)
                {
                    SelectedSubGroups.Items.Add(new ListItem(text, value));
                    JobEmployee je = new JobEmployee();
                    je.EmployeeID = empid;
                    je.JobID = value.ToInt();
                    EmployeeJobRepository ejr = new EmployeeJobRepository();
                    ejr.SaveJobEmployee(je);
                    NoItemDiv.InnerText = "";
                }
                else
                {
                    NoItemDiv.InnerText = "این مورد قبلا اضافه شده است!";
                    NoItemDiv.Attributes["class"] = "error";
                }
            }
            else
            {
                NoItemDiv.InnerText = "شما هیچ موردی را انتخاب نکرده اید!";
                NoItemDiv.Attributes["class"] = "error";
            }
        }

        protected void RemoveFromSub_Click(object sender, EventArgs e)
        {
            if (SelectedSubGroups.SelectedIndex != -1)
            {
                EmployeeJobRepository ej = new EmployeeJobRepository();
                ej.DeleteByEmpid_Jobid(empid, SelectedSubGroups.SelectedItem.Value.ToInt());
                SelectedSubGroups.Items.RemoveAt(SelectedSubGroups.SelectedIndex);
            }
        }
    }
}
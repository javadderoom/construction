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
                GroupsRepository repo = new GroupsRepository();
                DDLGroups.DataSource = repo.LoadAllGroups();
                DDLGroups.DataTextField = "Title";
                DDLGroups.DataValueField = "GroupID";
                DDLGroups.DataBind();
                DDLGroups.Items.Insert(0, new ListItem("یک گروه انتخاب کنید", "-2"));
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

        protected void DDLGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupsRepository repo = new GroupsRepository();
            if (DDLGroups.SelectedValue != "-2")
            {
                DataTable DT = new DataTable();
                DT = repo.LoadSubGroup(DDLGroups.SelectedValue.ToInt());

                if ((DT.Rows.Count > 0))
                {
                    SubGroups.DataSource = DT;
                    SubGroups.DataTextField = "Title";
                    SubGroups.DataValueField = "GroupID";
                    SubGroups.DataBind();
                    NoItemDiv.InnerText = "";
                }
                else
                {
                    SubGroups.Items.Clear();
                    SubGroups.Items.Insert(0, new ListItem(DDLGroups.SelectedItem.ToString(), DDLGroups.SelectedValue.ToString()));
                    NoItemDiv.InnerText = "این گروه هیچ زیر گروهی ندارد،میتوانید نام گروه را اضافه کنید";
                    NoItemDiv.Attributes["class"] = "textok";
                }
            }
            else
            {
                SubGroups.Items.Clear();
                NoItemDiv.InnerText = "";
            }
        }

        protected void AddToSub_Click(object sender, EventArgs e)
        {
            if (SubGroups.SelectedIndex != -1)
            {
                bool isadd = false;
                string text = SubGroups.SelectedItem.Text;
                for (int i = 0; i < SelectedSubGroups.Items.Count; i++)
                {
                    if (SelectedSubGroups.Items[i].Text == text)
                    {
                        isadd = true;
                    }
                }
                if (!isadd)
                {
                    SelectedSubGroups.Items.Add(text);
                    SelectedSubGroups.Items[SelectedSubGroups.Items.Count - 1].Value = SubGroups.SelectedItem.Value;

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
                SelectedSubGroups.Items.RemoveAt(SelectedSubGroups.SelectedIndex);
                NoItemDiv.InnerText = "";
                if (SelectedSubGroups.Items.Count == 0)
                {
                }
            }
            else
            {
                NoItemDiv.InnerText = "شما هیچ موردی را انتخاب نکرده اید!";
                NoItemDiv.Attributes["class"] = "error";
            }
        }
    }
}
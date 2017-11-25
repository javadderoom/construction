using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using DataAccess;
using DataAccess.Repository;
using System.Data;
using System.Web.Services;

namespace WebPages.Panels.Admin
{
    public partial class ManageJobGroups : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminid"] != null)
            {
                if (!IsPostBack)
                {
                    JobGroupsRepository repGP = new JobGroupsRepository();
                    JobRepository jobs = new JobRepository();
                    DataTable allGroups = new DataTable();
                    allGroups = repGP.getJobGroups();
                    gvGroups.DataSource = allGroups;
                    gvGroups.DataBind();
                    ddlGroups.DataSource = allGroups;
                    ddlGroups.DataTextField = "JobGroupTitle";
                    ddlGroups.DataValueField = "JobGroupID";
                    ddlGroups.DataBind();
                    ddlGroups.Items.Insert(0, new ListItem("همه زیر گروه ها", "0"));

                    gvSubGroups.DataSource = jobs.getAllJobsByGroupID();
                    gvSubGroups.DataBind();
                    ddlgroupsForModal.DataSource = jobs.getAllJobsByGroupID();
                    ddlgroupsForModal.DataTextField = "JobTitle";
                    ddlgroupsForModal.DataValueField = "JobID";
                    ddlgroupsForModal.DataBind();
                    ddlgroupsForModal.Items.Insert(0, new ListItem("یکی از گروه ها را انتخاب کنید", "0"));
                }
            }
            else
            {
                Response.Redirect("/AdminLogin");
            }
        }

        [WebMethod]
        public static List<JobGroup> getJobGroups()
        {
            DataTable dt = new DataTable();
            List<JobGroup> objDept = new List<JobGroup>();
            JobGroupsRepository jg = new JobGroupsRepository();
            dt = jg.getJobGroups();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objDept.Add(new JobGroup
                    {
                        JobGroupID = Convert.ToInt32(dt.Rows[i][0]),
                        JobGroupTitle = dt.Rows[i][1].ToString(),
                    });
                }
            }
            return objDept;
        }

        protected void gvGroups_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                //Retrieve the row index stored in the
                //CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvGroups.Rows[index];

                IDholder.Text = row.Cells[0].Text;
                tbxOldName.InnerText = row.Cells[1].Text;

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#modalShowGroupDetails').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "ModalScript", sb.ToString(), false);
            }

            if (e.CommandName == "Delet")
            {
                JobGroupsRepository repJgp = new JobGroupsRepository();
                JobRepository repgp = new JobRepository();

                // Retrieve the row index stored in the
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvGroups.Rows[index];
                int id = row.Cells[0].Text.ToInt();

                if (repgp.DelJobs(id))
                {
                    if (repJgp.DelJobGruop(id))
                    {
                        gvGroups.DataSource = null;
                        gvGroups.DataBind();
                        ddlGroups.DataSource = null;
                        ddlGroups.DataBind();
                        gvSubGroups.DataSource = null;
                        gvSubGroups.DataBind();
                        DataTable allGroups = new DataTable();
                        allGroups = repJgp.getJobGroups();
                        ddlgroupsForModal.DataSource = allGroups;
                        ddlgroupsForModal.DataTextField = "JobGroupTitle";
                        ddlgroupsForModal.DataValueField = "JobGroupID";
                        ddlgroupsForModal.DataBind();
                        ddlgroupsForModal.Items.Insert(0, new ListItem("یکی از گروه ها را انتخاب کنید", "0"));
                        gvGroups.DataSource = allGroups;
                        gvGroups.DataBind();
                        ddlGroups.DataSource = allGroups;
                        ddlGroups.DataTextField = "JobGroupTitle";
                        ddlGroups.DataValueField = "JobGroupID";
                        ddlGroups.DataBind();
                        ddlGroups.Items.Insert(0, new ListItem("همه زیر گروه ها", "0"));
                        gvSubGroups.DataSource = repgp.getAllJobsByGroupID();
                        gvSubGroups.DataBind();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('حذف با موفقیت انجام شد');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('حذف با خطا مواجه شد ، بعدا سعی کنید یا با پشتیبانی تماس بگیرید!');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('حذف با خطا مواجه شد ، بعدا سعی کنید یا با پشتیبانی تماس بگیرید!');", true);
                }
            }
        }

        protected void btnSaveGroupChange_Click(object sender, EventArgs e)
        {
            JobGroupsRepository repgp = new JobGroupsRepository();
            if (!String.IsNullOrEmpty(tbxNewName.Text))
            {
                JobGroup ngr = new JobGroup();
                ngr.JobGroupID = IDholder.Text.ToInt();

                ngr.JobGroupTitle = tbxNewName.Text;

                if (repgp.Savegp(ngr))
                {
                    gvGroups.DataSource = null;
                    gvGroups.DataBind();
                    gvGroups.DataSource = repgp.getJobGroups();
                    gvGroups.DataBind();
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#modalShowGroupDetails').modal('hide');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "ModalScript", sb.ToString(), false);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ثبت با موفقیت انجام شد');", true);
                    tbxNewName.Text = "";
                }
                else
                {
                    tbxNewName.Text = "";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#modalShowGroupDetails').modal('hide');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "ModalScript", sb.ToString(), false);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ثبت با خطا مواجه شد !');", true);
                }
            }
        }

        protected void gvSubGroups_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                //Retrieve the row index stored in the
                //CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvSubGroups.Rows[index];

                SubIDHolder.Text = row.Cells[0].Text;
                SubOldName.InnerText = row.Cells[1].Text;

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#modalShowSubGroupDetails').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "ModalScript", sb.ToString(), false);
            }

            if (e.CommandName == "Delet")
            { //Retrieve the row index stored in the
                //CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvSubGroups.Rows[index];
                JobRepository repgp = new JobRepository();

                if (repgp.DelJob(row.Cells[0].Text.ToInt()))
                {
                    gvSubGroups.DataSource = null;
                    gvSubGroups.DataBind();
                    if (ddlGroups.SelectedValue != "0")
                    {
                        gvSubGroups.DataSource = repgp.getJobsByGroupID(ddlGroups.SelectedValue.ToInt());
                    }
                    else
                    {
                        gvSubGroups.DataSource = repgp.getAllJobsByGroupID();
                    }
                    gvSubGroups.DataBind();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('حذف با موفقیت انجام شد');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('حذف با خطا مواجه شد ، بعدا سعی کنید یا با پشتیبانی تماس بگیرید!');", true);
                }
            }
        }

        protected void btnSaveSubGroupChane_Click(object sender, EventArgs e)
        {
            JobRepository repgp = new JobRepository();
            if (!String.IsNullOrEmpty(SubNewName.Text))
            {
                Job ngr = repgp.findJob(SubIDHolder.Text.ToInt());
                ngr.JobTitle = SubNewName.Text;

                if (repgp.Savegp(ngr))
                {
                    gvSubGroups.DataSource = null;
                    gvSubGroups.DataBind();
                    if (ddlGroups.SelectedValue != "0")
                    {
                        gvSubGroups.DataSource = repgp.getJobsByGroupID(ddlGroups.SelectedValue.ToInt());
                    }
                    else
                    {
                        gvSubGroups.DataSource = repgp.getAllJobsByGroupID();
                    }

                    gvSubGroups.DataBind();
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#modalShowGroupDetails').modal('hide');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "ModalScript", sb.ToString(), false);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ثبت با موفقیت انجام شد');", true);
                    SubNewName.Text = "";
                }
                else
                {
                    SubNewName.Text = "";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#modalShowGroupDetails').modal('hide');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "ModalScript", sb.ToString(), false);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ثبت با خطا مواجه شد !');", true);
                }
            }
        }

        protected void ddlGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            JobRepository Groupsrepo = new JobRepository();

            if (ddlGroups.SelectedValue != "0")
            {
                DataTable DT = new DataTable();
                DT = Groupsrepo.getJobsByGroupID(ddlGroups.SelectedValue.ToInt());

                if ((DT.Rows.Count > 0))
                {
                    gvSubGroups.DataSource = DT;

                    gvSubGroups.DataBind();
                }
                else
                {
                    gvSubGroups.DataSource = null;

                    gvSubGroups.DataBind();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('این گروه هیچ زیرگروهی ندارد!');", true);
                }
            }
            else
            {
                gvSubGroups.DataSource = null;
                gvSubGroups.DataBind();
                gvSubGroups.DataSource = Groupsrepo.getAllJobsByGroupID();
                gvSubGroups.DataBind();
            }
        }

        protected void btnSaveNewGroup_Click(object sender, EventArgs e)
        {
            JobGroupsRepository repgp = new JobGroupsRepository();
            JobGroup ngp = new JobGroup();

            ngp.JobGroupTitle = tbxNewGroup.Text;
            repgp.Savegp(ngp);
            DataTable allGroups = new DataTable();
            allGroups = repgp.getJobGroups();
            gvGroups.DataSource = null;
            gvGroups.DataBind();
            gvGroups.DataSource = allGroups;
            gvGroups.DataBind();
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MyFunction()", false);
            ddlGroups.DataSource = allGroups;
            ddlGroups.DataTextField = "JobGroupTitle";
            ddlGroups.DataValueField = "JobGroupID";
            ddlGroups.DataBind();
            ddlGroups.Items.Insert(0, new ListItem("همه زیر گروه ها", "0"));
            JobRepository jobs = new JobRepository();
            gvSubGroups.DataSource = jobs.getAllJobsByGroupID();
            gvSubGroups.DataBind();
            ddlgroupsForModal.DataSource = allGroups;
            ddlgroupsForModal.DataTextField = "JobGroupsTitle";
            ddlgroupsForModal.DataValueField = "JobGroupsID";
            ddlgroupsForModal.DataBind();
            ddlgroupsForModal.Items.Insert(0, new ListItem("یکی از گروه ها را انتخاب کنید", "0"));
            tbxNewGroup.Text = "";
        }

        protected void btnAddNewSub_Click(object sender, EventArgs e)
        {
            JobGroupsRepository repgp = new JobGroupsRepository();
            DataTable allGroups = new DataTable();
            allGroups = repgp.getJobGroups();
            if (tbxNewSubGroupName.Text != "")
            {
                string s = ddlgroupsForModal.SelectedValue;
                if (ddlgroupsForModal.SelectedValue != "0")
                {
                    if (ddlgroupsForModal.SelectedValue != "")
                    {
                        lbxSubs.Items.Add(tbxNewSubGroupName.Text);
                        lbxSubs.Items[lbxSubs.Items.Count - 1].Value = ddlgroupsForModal.SelectedValue;
                        tbxNewSubGroupName.Text = "";
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('لطفا یکی از گروه ها را انتخاب کنید');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('لطفا یکی از گروه ها را انتخاب کنید');", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('هیچ متنی وارد نشده است');", true);
            }
            ddlgroupsForModal.DataSource = null;
            ddlgroupsForModal.DataSource = allGroups;
            ddlgroupsForModal.DataTextField = "JobGroupTitle";
            ddlgroupsForModal.DataValueField = "JobGroupID";
            ddlgroupsForModal.DataBind();
            ddlgroupsForModal.Items.Insert(0, new ListItem("یکی از گروه ها را انتخاب کنید", "0"));
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#modalNewSubGroup').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(),
            "ModalScript", sb.ToString(), false);
        }

        protected void btnSaveNewSub_Click(object sender, EventArgs e)
        {
            JobRepository repGP = new JobRepository();

            for (int i = 0; i < lbxSubs.Items.Count; i++)
            {
                Job gp = new Job();

                gp.JobTitle = lbxSubs.Items[i].Text;
                gp.JobGroupID = lbxSubs.Items[i].Value.ToInt();
                repGP.Savegp(gp);
            }

            lbxSubs.DataSource = null;
            lbxSubs.DataBind();
            gvSubGroups.DataSource = null;
            gvSubGroups.DataBind();
            gvSubGroups.DataSource = null;
            gvSubGroups.DataBind();
            if (ddlGroups.SelectedValue != "")
            {
                if (ddlGroups.SelectedValue != "0")
                {
                    gvSubGroups.DataSource = repGP.getJobsByGroupID(ddlGroups.SelectedValue.ToInt());
                }
                else
                {
                    gvSubGroups.DataSource = repGP.getAllJobsByGroupID();
                }
            }
            else
            {
                gvSubGroups.DataSource = repGP.getAllJobsByGroupID();
            }
            gvSubGroups.DataBind();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#modalNewSubGroup').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(),
            "ModalScript", sb.ToString(), false);
        }

        protected void gvGroups_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGroups.PageIndex = e.NewPageIndex;
            JobGroupsRepository repGP = new JobGroupsRepository();

            DataTable allGroups = new DataTable();
            allGroups = repGP.getJobGroups();
            gvGroups.DataSource = allGroups;
            gvGroups.DataBind();
        }

        protected void gvSubGroups_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSubGroups.PageIndex = e.NewPageIndex;
            JobRepository jobs = new JobRepository();
            gvSubGroups.DataSource = jobs.getAllJobsByGroupID();
            gvSubGroups.DataBind();
        }

        [WebMethod]
        public static List<JobGroup> getJobGroupsforGrid()
        {
            List<JobGroup> result = new List<JobGroup>();

            return result;
        }
    }
}
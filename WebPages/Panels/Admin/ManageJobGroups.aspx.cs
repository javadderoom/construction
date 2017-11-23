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
                    //ddlGroups.DataSource = allGroups;
                    //ddlGroups.DataTextField = "JobGroupTitle";
                    //ddlGroups.DataValueField = "JobGroupID";
                    //ddlGroups.DataBind();
                    //ddlGroups.Items.Insert(0, new ListItem("همه زیر گروه ها", "-2"));

                    gvSubGroups.DataSource = jobs.getAllJobsByGroupID();
                    gvSubGroups.DataBind();
                    //ddlgroupsForModal.DataSource = jobs.getAllJobsByGroupID();
                    //ddlgroupsForModal.DataTextField = "JobTitle";
                    //ddlgroupsForModal.DataValueField = "JobID";
                    //ddlgroupsForModal.DataBind();
                    //ddlgroupsForModal.Items.Insert(0, new ListItem("یکی از گروه ها را انتخاب کنید", "-2"));
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
                GroupsConRepository repgpCon = new GroupsConRepository();
                GroupsRepository repgp = new GroupsRepository();

                // Retrieve the row index stored in the
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvGroups.Rows[index];
                int id = row.Cells[0].Text.ToInt();
                List<int> subIDs = repgp.getSubGroupsIDByFatherID(id).ToList();
                if (repgpCon.DeleteConsBySubGroupIdList(subIDs))
                {
                    if (repgp.DelSubGruop(subIDs))
                    {
                        if (repgp.DelGruop(id))
                        {
                            gvGroups.DataSource = null;
                            gvGroups.DataBind();
                            ddlGroups.DataSource = null;
                            ddlGroups.DataBind();
                            gvSubGroups.DataSource = null;
                            gvSubGroups.DataBind();
                            DataTable allGroups = new DataTable();
                            allGroups = repgp.LoadAllGroups();
                            ddlgroupsForModal.DataSource = allGroups;
                            ddlgroupsForModal.DataTextField = "Title";
                            ddlgroupsForModal.DataValueField = "GroupID";
                            ddlgroupsForModal.DataBind();
                            ddlgroupsForModal.Items.Insert(0, new ListItem("یکی از گروه ها را انتخاب کنید", "-2"));
                            gvGroups.DataSource = allGroups;
                            gvGroups.DataBind();
                            ddlGroups.DataSource = allGroups;
                            ddlGroups.DataTextField = "Title";
                            ddlGroups.DataValueField = "GroupID";
                            ddlGroups.DataBind();
                            ddlGroups.Items.Insert(0, new ListItem("همه زیر گروه ها", "-2"));
                            gvSubGroups.DataSource = repgp.LoadAllSubGroups();
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
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('حذف با خطا مواجه شد ، بعدا سعی کنید یا با پشتیبانی تماس بگیرید!');", true);
                }
            }
        }

        protected void btnSaveGroupChange_Click(object sender, EventArgs e)
        {
            GroupsRepository repgp = new GroupsRepository();
            if (!String.IsNullOrEmpty(tbxNewName.Text))
            {
                Groups ngr = new Groups();
                ngr.GroupID = IDholder.Text.ToInt();
                ngr.FatherID = -1;
                ngr.Title = tbxNewName.Text;

                if (repgp.Savegp(ngr))
                {
                    gvGroups.DataSource = null;
                    gvGroups.DataBind();
                    gvGroups.DataSource = repgp.LoadAllGroups();
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
                GroupsRepository repgp = new GroupsRepository();

                if (repgp.DelSubGruop(row.Cells[0].Text.ToInt()))
                {
                    gvSubGroups.DataSource = null;
                    gvSubGroups.DataBind();
                    if (ddlGroups.SelectedValue != "-2")
                    {
                        gvSubGroups.DataSource = repgp.LoadSubGroup(ddlGroups.SelectedValue.ToInt());
                    }
                    else
                    {
                        gvSubGroups.DataSource = repgp.LoadAllSubGroups();
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
            GroupsRepository repgp = new GroupsRepository();
            if (!String.IsNullOrEmpty(SubNewName.Text))
            {
                Groups ngr = new Groups();
                ngr = repgp.FindGroup(SubIDHolder.Text.ToInt());
                ngr.Title = SubNewName.Text;

                if (repgp.Savegp(ngr))
                {
                    gvSubGroups.DataSource = null;
                    gvSubGroups.DataBind();
                    if (ddlGroups.SelectedValue != "-2")
                    {
                        gvSubGroups.DataSource = repgp.LoadSubGroup(ddlGroups.SelectedValue.ToInt());
                    }
                    else
                    {
                        gvSubGroups.DataSource = repgp.LoadAllSubGroups();
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
            GroupsRepository Groupsrepo = new GroupsRepository();

            if (ddlGroups.SelectedValue != "-2")
            {
                DataTable DT = new DataTable();
                DT = Groupsrepo.LoadSubGroup(ddlGroups.SelectedValue.ToInt());

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
                gvSubGroups.DataSource = Groupsrepo.LoadAllSubGroups();
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
            ddlGroups.Items.Insert(0, new ListItem("همه زیر گروه ها", "-2"));
            JobRepository jobs = new JobRepository();
            gvSubGroups.DataSource = jobs.getAllJobsByGroupID();
            gvSubGroups.DataBind();
            ddlgroupsForModal.DataSource = allGroups;
            ddlgroupsForModal.DataTextField = "JobGroupsTitle";
            ddlgroupsForModal.DataValueField = "JobGroupsID";
            ddlgroupsForModal.DataBind();
            ddlgroupsForModal.Items.Insert(0, new ListItem("یکی از گروه ها را انتخاب کنید", "-2"));
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('هیچ متنی وارد نشده است');", true);
            }
            ddlgroupsForModal.DataSource = null;
            ddlgroupsForModal.DataSource = allGroups;
            ddlgroupsForModal.DataTextField = "JobGroupsTitle";
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
            GroupsRepository repGP = new GroupsRepository();

            for (int i = 0; i < lbxSubs.Items.Count; i++)
            {
                Groups gp = new Groups();

                gp.Title = lbxSubs.Items[i].Text;
                gp.FatherID = lbxSubs.Items[i].Value.ToInt();
                repGP.Savegp(gp);
            }

            lbxSubs.DataSource = null;
            lbxSubs.DataBind();
            gvSubGroups.DataSource = null;
            gvSubGroups.DataBind();
            gvSubGroups.DataSource = null;
            gvSubGroups.DataBind();
            if (ddlGroups.SelectedValue != "-2")
            {
                gvSubGroups.DataSource = repGP.LoadSubGroup(ddlGroups.SelectedValue.ToInt());
            }
            else
            {
                gvSubGroups.DataSource = repGP.LoadAllSubGroups();
            }
            gvSubGroups.DataBind();
            gvSubGroups.DataBind();
            ddlGroups.SelectedIndex = 0;
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
            GroupsRepository repGP = new GroupsRepository();

            DataTable allGroups = new DataTable();
            allGroups = repGP.LoadAllGroups();
            gvGroups.DataSource = allGroups;
            gvGroups.DataBind();
        }

        protected void gvSubGroups_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSubGroups.PageIndex = e.NewPageIndex;
            GroupsRepository repGP = new GroupsRepository();
            gvSubGroups.DataSource = repGP.LoadAllSubGroups();
            gvSubGroups.DataBind();
        }
    }
}
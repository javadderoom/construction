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

namespace WebPages.Panels.Admin
{
    public partial class ManageGroups : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminid"] != null)
            {
                if (!IsPostBack)
                {
                    GroupsRepository repGP = new GroupsRepository();
                    DataTable allGroups = new DataTable();
                    allGroups = repGP.LoadAllGroups();
                    gvGroups.DataSource = allGroups;
                    gvGroups.DataBind();
                    ddlGroups.DataSource = allGroups;
                    ddlGroups.DataTextField = "Title";
                    ddlGroups.DataValueField = "GroupID";
                    ddlGroups.DataBind();
                    ddlGroups.Items.Insert(0, new ListItem("همه زیر گروه ها", "-2"));
                    gvSubGroups.DataSource = repGP.LoadAllSubGroups();
                    gvSubGroups.DataBind();
                    ddlgroupsForModal.DataSource = allGroups;
                    ddlgroupsForModal.DataTextField = "Title";
                    ddlgroupsForModal.DataValueField = "GroupID";
                    ddlgroupsForModal.DataBind();
                    ddlgroupsForModal.Items.Insert(0, new ListItem("یکی از گروه ها را انتخاب کنید", "-2"));
                }
            }
            else
            {
                Response.Redirect("/AdminLogin");
            }
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
                Group ngr = new Group();
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
                Group ngr = new Group();
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
            GroupsRepository repgp = new GroupsRepository();
            Group ngp = new Group();

            ngp.FatherID = -1;
            ngp.Title = tbxNewGroup.Text;
            repgp.Savegp(ngp);
            gvGroups.DataSource = null;
            gvGroups.DataBind();
            gvGroups.DataSource = repgp.LoadAllGroups();
            gvGroups.DataBind();
            ddlGroups.DataSource = null;
            ddlGroups.DataBind();
            ddlGroups.DataSource = repgp.LoadAllGroups();
            ddlGroups.DataTextField = "Title";
            ddlGroups.DataValueField = "GroupID";
            ddlGroups.DataBind();
            ddlGroups.Items.Insert(0, new ListItem("همه زیر گروه ها", "-2"));
            ddlgroupsForModal.DataSource = repgp.LoadAllGroups();
            ddlgroupsForModal.DataTextField = "Title";
            ddlgroupsForModal.DataValueField = "GroupID";
            ddlgroupsForModal.DataBind();
            ddlgroupsForModal.Items.Insert(0, new ListItem("یکی از گروه ها را انتخاب کنید", "-2"));
            gvSubGroups.DataSource = repgp.LoadAllSubGroups();
            gvSubGroups.DataBind();
            tbxNewGroup.Text = "";
        }

        protected void btnAddNewSub_Click(object sender, EventArgs e)
        {
            if (tbxNewSubGroupName.Text != "")
            {
                if (ddlgroupsForModal.SelectedValue != "-2")
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
                Group gp = new Group();

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
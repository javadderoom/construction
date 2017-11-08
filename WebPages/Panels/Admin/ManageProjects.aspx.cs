using Common;
using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages.Panels.Admin
{
    public partial class ManageProjects : System.Web.UI.Page
    {
        protected void group()
        {
            diverror.InnerHtml = "";
            if (ddlGroups.SelectedValue != "-2")
            {
                GroupsRepository Groupsrepo = new GroupsRepository();
                DataTable DT = new DataTable();
                DT = Groupsrepo.LoadSubGroup(ddlGroups.SelectedValue.ToInt());

                if ((DT.Rows.Count > 0))
                {
                    ddlSubGroups.Enabled = true;

                    ddlSubGroups.DataSource = DT;
                    ddlSubGroups.DataTextField = "Title";
                    ddlSubGroups.DataValueField = "GroupID";
                    ddlSubGroups.DataBind();
                    ddlSubGroups.Items.Insert(0, new ListItem("همه زیر گروه ها", "-2"));
                }
                else
                {
                    ddlSubGroups.Enabled = false;
                    ddlSubGroups.Items.Clear();
                    ddlSubGroups.Items.Insert(0, new ListItem("گروه : " + ddlGroups.SelectedItem.ToString(), ddlGroups.SelectedValue.ToString()));
                }
                //load posts
                List<int> subgroupsid = Groupsrepo.getSubGroupsIDByFatherID(ddlGroups.SelectedValue.ToInt());
                ProjectsRepository artrep = new ProjectsRepository();
                List<Project> articles = artrep.ReturnProjectsByCategory(subgroupsid);
                if (articles.Count != 0)
                {
                    gvPosts.DataSource = null;
                    gvPosts.DataSource = OnlineTools.ToDataTable(articles);
                    gvPosts.DataBind();
                }
                else
                {
                    gvPosts.DataSource = null;
                    gvPosts.DataBind();
                    diverror.InnerHtml = " در این بخش مقاله ای وجود ندارد! ";
                    ddlSubGroups.SelectedIndex = 0;
                    ddlSubGroups.Enabled = false;
                }
            }
            else
            {
                ProjectsRepository artRep = new ProjectsRepository();
                DataTable DT = new DataTable();
                DT = OnlineTools.ToDataTable(artRep.AllProjects());
                if (DT.Rows.Count != 0)
                {
                    gvPosts.DataSource = DT;
                    gvPosts.DataBind();
                    ddlSubGroups.SelectedIndex = 0;
                    ddlSubGroups.Enabled = false;
                }
                else
                {
                    diverror.InnerHtml = " در این بخش مقاله ای وجود ندارد! ";
                    gvPosts.DataSource = null;
                    gvPosts.DataBind();
                }
            }
        }

        protected void subgroup()
        {
            diverror.InnerHtml = "";
            if (ddlSubGroups.SelectedValue != "-2")
            {
                ProjectsRepository artrep = new ProjectsRepository();
                List<Project> articles = artrep.ReturnProjectsByCategory(ddlSubGroups.SelectedValue.ToInt());
                if (articles.Count != 0)
                {
                    gvPosts.DataSource = null;
                    gvPosts.DataBind();
                    gvPosts.DataSource = OnlineTools.ToDataTable(articles);
                    gvPosts.DataBind();
                }
                else
                {
                    gvPosts.DataSource = null;
                    gvPosts.DataBind();
                    diverror.InnerHtml = " در این بخش مقاله ای وجود ندارد! ";
                }
            }
            else
            {
                if (ddlGroups.SelectedValue != "-2")
                {
                    GroupsRepository Groupsrepo = new GroupsRepository();
                    List<int> subgroupsid = Groupsrepo.getSubGroupsIDByFatherID(ddlGroups.SelectedValue.ToInt());
                    ProjectsRepository artrep = new ProjectsRepository();
                    List<Project> articles = artrep.ReturnProjectsByCategory(subgroupsid);
                    if (articles.Count != 0)
                    {
                        gvPosts.DataSource = null;
                        gvPosts.DataSource = OnlineTools.ToDataTable(articles);
                        gvPosts.DataBind();
                    }
                    else
                    {
                        gvPosts.DataSource = null;
                        gvPosts.DataBind();
                        diverror.InnerHtml = " در این بخش مقاله ای وجود ندارد! ";
                    }
                }
                else
                {
                    group();
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminid"] != null)
            {
                if (!IsPostBack)
                { //load grid
                    ProjectsRepository artRep = new ProjectsRepository();
                    gvPosts.DataSource = artRep.AllProjects();
                    gvPosts.DataBind();
                    //load ddls
                    ddlSubGroups.Enabled = false;

                    GroupsRepository repo = new GroupsRepository();
                    ddlGroups.DataSource = repo.LoadAllGroups();
                    ddlGroups.DataTextField = "Title";
                    ddlGroups.DataValueField = "GroupID";
                    ddlGroups.DataBind();
                    ddlGroups.Items.Insert(0, new ListItem("همه گروه ها", "-2"));
                    ddlSubGroups.Items.Insert(0, new ListItem("همه زیر گروه ها", "-2"));
                }
            }
            else
            {
                Response.Redirect("/AdminLogin");
            }
        }

        protected void gvPosts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            diverror.InnerHtml = "";

            if (e.CommandName == "Edit")
            {
                // Retrieve the row index stored in the
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvPosts.Rows[index];
                Session.Add("ProjectIDForEdit", row.Cells[0].Text);

                Response.Redirect("/Admin/EditProject");//edit
            }
            if (e.CommandName == "Show")
            {
                // Retrieve the row index stored in the
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvPosts.Rows[index];

                string id = row.Cells[0].Text;

                Response.Redirect("/Projects/" + id + "/" + row.Cells[1].Text.Replace(' ', '-'));//show
            }
            if (e.CommandName == "Delet")
            {
                // Retrieve the row index stored in the
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvPosts.Rows[index];
                int id = row.Cells[0].Text.ToInt();
                ProjectsRepository repart = new ProjectsRepository();
                ProjectConRepository repgpCon = new ProjectConRepository();
                if (repgpCon.DeletProjectConnections(id) && repart.DeletProjectByID(id))
                {
                    subgroup();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('حذف با موفقیت انجام شد ');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('حذف با خطا مواجه شد ، بعدا سعی کنید یا با پشتیبانی تماس بگیرید!');", true);
                }
            }
        }

        protected void ddlSubGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            subgroup();
        }

        protected void ddlGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            group();
        }

        protected void gvPosts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPosts.PageIndex = e.NewPageIndex;
            ProjectsRepository artRep = new ProjectsRepository();
            gvPosts.DataSource = artRep.AllProjects();
            gvPosts.DataBind();
        }
    }
}
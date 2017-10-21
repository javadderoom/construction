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
            }
        }

        protected void gvGroups_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                // Retrieve the row index stored in the
                // CommandArgument property.
                //int index = Convert.ToInt32(e.CommandArgument);

                //// Retrieve the row that contains the button
                //// from the Rows collection.
                //GridViewRow row = gvGroups.Rows[index];

                //IDholder.Text = row.Cells[0].Text;
                //tbxOldName.InnerText = row.Cells[1].Text;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#modalShowGroupDetails').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                "ModalScript", sb.ToString(), false);
            }
            //if (e.CommandName == "Show")
            //{
            //    // Retrieve the row index stored in the
            //    // CommandArgument property.
            //    int index = Convert.ToInt32(e.CommandArgument);

            //    // Retrieve the row that contains the button
            //    // from the Rows collection.
            //    GridViewRow row = gvPosts.Rows[index];

            //    string id = row.Cells[0].Text;

            //    Response.Redirect("~/وبلاگ-ها/" + id);
            //}
            //if (e.CommandName == "Delet")
            //{
            //    // Retrieve the row index stored in the
            //    // CommandArgument property.
            //    int index = Convert.ToInt32(e.CommandArgument);

            //    // Retrieve the row that contains the button
            //    // from the Rows collection.
            //    GridViewRow row = gvPosts.Rows[index];
            //    int id = row.Cells[0].Text.ToInt();
            //    ArticleRepository repart = new ArticleRepository();
            //    GroupsConRepository repgpCon = new GroupsConRepository();
            //    if (repgpCon.DeletArticleConnections(id) && repart.DeletArticleByID(id))
            //    {
            //        subgroup();
            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('حذف با موفقیت انجام شد ');", true);





            //    }
            //    else
            //    {
            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('حذف با خطا مواجه شد ، بعدا سعی کنید یا با پشتیبانی تماس بگیرید!');", true);

            //    }
            //   
            //}
        }
    }
}
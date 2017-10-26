using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using DataAccess.Repository;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages.Panels.Admin
{
    public partial class ManageFirstPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SliderRepository repSlider = new SliderRepository();
                gvSlider.DataSource = repSlider.LoadSliders();
                gvSlider.DataBind();
            }
        }

        protected void gvSlider_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                //Retrieve the row index stored in the
                //CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvSlider.Rows[index];

                Response.Redirect("~/Panels/Admin/EditSlider.aspx?id=" + row.Cells[0].Text);



            }
        }
    }
}
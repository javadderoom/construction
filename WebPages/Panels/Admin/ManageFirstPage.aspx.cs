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
            if (Session["adminid"] != null)
            {
                if (!IsPostBack)
                {
                    SliderRepository repSlider = new SliderRepository();
                    gvSlider.DataSource = repSlider.LoadSliders();
                    gvSlider.DataBind();
                    ContactUsRepository repContact = new ContactUsRepository();
                    ContactWay cnw = repContact.Findcwy(1);
                    tbxAbout.Text = cnw.AboutUs;
                    tbxAdress.Text = cnw.Adrees;
                    tbxMail.Text = cnw.Email;
                    tbxPhone.Text = cnw.PhoneNumber;
                }
            }
            else
            {
                Response.Redirect("/AdminLogin");
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

                Response.Redirect("Admin/EditSlider/" + row.Cells[0].Text);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ContactUsRepository repContact = new ContactUsRepository();
            ContactWay cnw = repContact.Findcwy(1);
            cnw.AboutUs = tbxAbout.Text;
            cnw.Adrees = tbxAdress.Text;
            cnw.Email = tbxMail.Text;
            cnw.PhoneNumber = tbxPhone.Text;
            if (repContact.Savecwy(cnw))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' ثبت با موفقیت انجام شد  ');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' ثبت با خطا مواجه شد ! ');", true);
            }
        }

        protected void gvSlider_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSlider.PageIndex = e.NewPageIndex;
            SliderRepository repSlider = new SliderRepository();
            gvSlider.DataSource = repSlider.LoadSliders();
            gvSlider.DataBind();
        }
    }
}
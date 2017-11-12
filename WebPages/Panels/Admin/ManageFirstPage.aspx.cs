using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using DataAccess.Repository;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

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
                    tbxAboutPage.Text = cnw.AboutPage;
                    tbxInsta.Text = cnw.Instagram;
                    tbxtele.Text = cnw.Telegram;
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

                Response.Redirect("/Admin/EditSlider/" + row.Cells[0].Text);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ContactUsRepository repContact = new ContactUsRepository();
            ContactWay cnw = repContact.Findcwy(1);
            if (tbxAbout.Text != "")
                cnw.AboutUs = tbxAbout.Text;
            if (tbxAdress.Text != "")
                cnw.Adrees = tbxAdress.Text;
            if (tbxMail.Text != "")
                cnw.Email = tbxMail.Text;
            if (tbxPhone.Text != "")
                cnw.PhoneNumber = tbxPhone.Text;
            if (tbxAboutPage.Text != "")
                cnw.AboutPage = tbxAboutPage.Text;
            if (tbxtele.Text != "")
                cnw.Telegram = tbxtele.Text;
            if (tbxInsta.Text != "")
                cnw.Instagram = tbxInsta.Text;
            if (FileUpload1.HasFile)
            {
                string filename = Path.GetFileName(FileUpload1.FileName);
                string rand = DBManager.CurrentTimeWithoutColons() + DBManager.CurrentPersianDateWithoutSlash();

                filename = rand + filename;
                string ps = Server.MapPath(@"~\img\") + filename;
                FileUpload1.SaveAs(ps);

                FileStream fStream = File.OpenRead(ps);
                byte[] contents = new byte[fStream.Length];
                fStream.Read(contents, 0, (int)fStream.Length);
                fStream.Close();
                FileInfo fi = new FileInfo(ps);
                fi.Delete();
                cnw.logo = contents;
            }

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
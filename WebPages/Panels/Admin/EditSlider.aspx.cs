using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using DataAccess;
using DataAccess.Repository;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;

namespace WebPages.Panels.Admin
{
    public partial class AddSlider : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminid"] != null)
            {
                if (!IsPostBack)
                {
                    string id = this.Page.RouteData.Values["id"].ToString();
                    if (!String.IsNullOrEmpty(id))
                    {
                        SliderRepository repSr = new SliderRepository();

                        Slider oldSlider = repSr.FindSlider(id.ToInt());
                        oldBimg.Src = setBKGSrc(id.ToInt());
                        if (oldSlider.thumbnail != null)
                        {
                            Rimg.InnerHtml = "<img src='" + setRightimgSrc(id.ToInt()) + "' class='img-responsive'/>";
                        }
                        else
                        {
                            Rimg.InnerHtml = "عکسی وجود نداشته !";
                        }
                        text.Text = oldSlider.Text;
                        tbxLink.Text = oldSlider.Link;
                    }
                    else
                    {
                        Response.Redirect("/Admin/ManageFirstPage");
                    }
                }
                else
                {
                    Response.Redirect("/AdminLogin");
                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            string id = this.Page.RouteData.Values["id"].ToString();


            if (!String.IsNullOrEmpty(id))
            {
                SliderRepository repSlider = new SliderRepository();
                Slider slider = repSlider.FindSlider(id.ToInt());

                //slider.SlideID = id.ToInt();
                if (FileUpload1.HasFile)
                {
                    if (FileUpload1.FileBytes.Length > 1024 * 1024)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' حجم عکس بیشتر از 1 مگابایت است ! ');", true);

                        return;
                    }
                    string ext = Path.GetExtension(FileUpload1.FileName).ToLower();
                    if ((ext != ".jpg") && (ext != ".png"))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' فرمت png یا jpg kdsj ! ');", true);

                        return;
                    }
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
                    slider.BackgroundImg = contents;

                }


                if (FileUpload2.HasFile)
                {
                    if (FileUpload2.FileBytes.Length > 1024 * 1024)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' حجم عکس بیشتر از 1 مگابایت است ! ');", true);

                        return;
                    }
                    string ext = Path.GetExtension(FileUpload2.FileName).ToLower();
                    if ((ext != ".jpg") && (ext != ".png"))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' فرمت png یا jpg kdsj ! ');", true);

                        return;
                    }
                    string filename = Path.GetFileName(FileUpload2.FileName);
                    string rand = DBManager.CurrentTimeWithoutColons() + DBManager.CurrentPersianDateWithoutSlash();
                    filename = rand + filename;
                    string ps = Server.MapPath(@"~\img\") + filename;
                    FileUpload2.SaveAs(ps);
                    FileStream fStream = File.OpenRead(ps);
                    byte[] contents = new byte[fStream.Length];
                    fStream.Read(contents, 0, (int)fStream.Length);
                    fStream.Close();
                    FileInfo fi = new FileInfo(ps);
                    fi.Delete();
                    slider.thumbnail = contents;

                }
                if (CheckBox1.Checked == true)
                {
                    slider.thumbnail = null;
                }

                if (tbxLink.Text != "")
                {
                    slider.Link = tbxLink.Text;
                }
                else
                {
                    slider.Link = null;

                }
                if (text.Text != "")
                {
                    slider.Text = text.Text;
                }
                else
                {
                    slider.Text = "";
                }


                if (repSlider.SaveSlider(slider))
                { Response.Redirect("/Admin/ManageFirstPage"); }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert' ثبت تغییرات با خطا مواجه شد !  ');", true);

                }

            }
        }
        private string setBKGSrc(int SlideID)
        {
            string ans = "";
            using (SqlConnection cn = new SqlConnection(OnlineTools.conString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(string.Format("select BackgroundImg from Slider where SlideID = {0}", SlideID), cn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                    {
                        if (dr.Read())
                        {

                            byte[] fileData = (byte[])dr.GetValue(0);
                            ans = "data:image/png;base64," + Convert.ToBase64String(fileData);
                        }

                        dr.Close();
                    }
                    cn.Close();



                }
            }
            return ans;
        }
        private string setRightimgSrc(int SlideID)
        {
            string ans = "";
            using (SqlConnection cn = new SqlConnection(OnlineTools.conString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(string.Format("select thumbnail from Slider where SlideID = {0}", SlideID), cn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                    {
                        if (dr.Read())
                        {

                            byte[] fileData = (byte[])dr.GetValue(0);
                            ans = "data:image/png;base64," + Convert.ToBase64String(fileData);
                        }

                        dr.Close();
                    }
                    cn.Close();



                }
            }
            return ans;
        }
    }
}
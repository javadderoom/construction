using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Repository;


namespace WebPages
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillImageText();
            }
        }
        void FillImageText()
        {
            try
            {
                Random rdm = new Random();
                string combination = "0123456789abcdefghijklmnopqrstuvwxyz";
                StringBuilder ImgValue = new StringBuilder();
                for (int i = 0; i < 5; i++)
                {
                    ImgValue.Append(combination[rdm.Next(combination.Length)]);
                    Session.Add("ImgValue", ImgValue.ToString());
                    btnImg.ImageUrl = "catchimage.aspx?";
                }
            }
            catch
            {
                throw;
            }
        }



        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Value) || string.IsNullOrEmpty(txtPassword.Value))
            {
                //lblWarning.Text = "نام کاربری یا رمز عبور را وارد نکردید";
                return;
            }
            if (Session["ImgValue"].ToString() == txtImage.Value)
            {
                //lblWarning.Text = "کد وارد شده صحیح می باشد";
                //FillImageText();
            }
            else
            {
                lblWarning.Text = "کد وارد شده صحیح نمی باشد";
                txtImage.Value = "";
                FillImageText();
                return;
            }
            ///////////////////////////////////////////////////////////////////////////////////

            AdminsRepository ar = new AdminsRepository();
            int eid = ar.getAdminIDByUsername_Password(txtName.Value, txtPassword.Value);
            if (eid == 0)
            {
                lblWarning.Text = "نام کاربری یا رمز ورود اشتباه است";
                txtImage.Value = "";
                FillImageText();
                return;
            }
            else
            {
                Session.Add("adminid", 1);
                Response.Redirect("http://localhost:6421/Panels/Admin/MessageInboxAdmin.aspx");
            }







        }
    }
}
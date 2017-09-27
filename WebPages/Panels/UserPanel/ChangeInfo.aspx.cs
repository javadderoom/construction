using Common;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages.Panels.UserPanel
{
    public partial class ChangeInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSabt_ServerClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxnewpass.Text) || string.IsNullOrEmpty(tbxnewpassagain.Text) || string.IsNullOrEmpty(tbxnowPass.Text))
                return;
            if (tbxnewpass.Text != tbxnewpassagain.Text)
            {
                lblWarning.Text = "رمز عبور جدید و تکرار آن مطابقت ندارند";
                lblWarning.ForeColor = System.Drawing.Color.Red;
                return;
            }
            UsersRepository ur = new UsersRepository();
            if (ur.getUserPass(Session["userid"].ToString().ToInt()) != tbxnowPass.Text)
            {
                lblWarning.Text = "رمز عبور جاری اشتباه است";
                lblWarning.ForeColor = System.Drawing.Color.Red;
                return;
            }




            ur.setNewPassForUser(Session["userid"].ToString().ToInt(), tbxnewpass.Text);
            lblWarning.Text = "رمز شما با موفقیت ویرایش شد";
            lblWarning.ForeColor = System.Drawing.Color.Green;
        }

        protected void btnMobile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxMobile.Text))
                return;

            if (tbxMobile.Text.Length < 11)
            {
                lblMobileWarning.Text = "شماره موبایل 11 رقمی خود را وارد کنید";
                lblMobileWarning.ForeColor = System.Drawing.Color.Red;
                return;
            }

            UsersRepository ur = new UsersRepository();
            ur.setNewMobileForUser(Session["userid"].ToString().ToInt(), tbxMobile.Text);
            lblMobileWarning.Text = "شماره موبایل با موفقیت ویرایش شد";
            lblMobileWarning.ForeColor = System.Drawing.Color.Green;
        }
    }
}
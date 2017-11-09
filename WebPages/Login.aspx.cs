using System;
using System.Collections.Generic;

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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillImageText();
            }
        }

        private void FillImageText()
        {
            try
            {
                Random rdm = new Random();
                string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('نام کاربری یا رمز عبور را وارد نکردید ! ');", true);
                return;
            }
            if (Session["ImgValue"].ToString() == txtImage.Value.ToUpper())
            {
                //lblWarning.Text = "کد وارد شده صحیح می باشد";
                //FillImageText();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('کد وارد شده صحیح نمی باشد ! ');", true);
                txtImage.Value = "";
                FillImageText();
                return;
            }
            ///////////////////////////////////////////////////////////////////////////////////
            if (rdiEmployees.Checked == true)
            {
                EmployeesRepository r = new EmployeesRepository();
                int eid = r.getEmployeeIDByUsername_Password(txtName.Value, txtPassword.Value);
                if (eid == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('نام کاربری یا رمز ورود اشتباه است ! ');", true);
                    txtImage.Value = "";
                    FillImageText();
                    return;
                }
                else
                {
                    Session.Add("employeeid", eid);
                    Session.Remove("adminid");
                    Session.Remove("userid");
                    Response.Redirect("/Employee/Profile");
                }
            }
            else
            {
                UsersRepository r = new UsersRepository();
                int uid = r.getUserIDByUsername_Password(txtName.Value, txtPassword.Value);
                if (uid == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('نام کاربری یا رمز ورود اشتباه است ! ');", true);
                    txtImage.Value = "";
                    FillImageText();
                    return;
                }
                else
                {
                    Session.Add("userid", uid);

                    Session.Remove("adminid");
                    Session.Remove("employeeid");
                    Response.Redirect("/User/Profile");
                }
            }
        }
    }
}
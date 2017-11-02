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
using DataAccess;
using Common;
using System.Transactions;

namespace WebPages
{
    public partial class UserReg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillImageText();
                fillDDL();
            }
        }

        public void fillDDL()
        {
            StatesRepository r = new StatesRepository();
            ddlState.DataSource = r.getStatesInfo();
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "StateID";
            ddlState.DataBind();
            ddlState.SelectedIndex = 26;

            CityRepository cr = new CityRepository();
            ddlCity.DataSource = cr.getCitiesInfoByStateID(ddlState.SelectedIndex + 1);
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityID";
            ddlCity.DataBind();
        }

        private void FillImageText()
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
            if (string.IsNullOrEmpty(txtName.Value) || string.IsNullOrEmpty(txtPassword.Value)
                || string.IsNullOrEmpty(txtusername.Value) || string.IsNullOrEmpty(txtpassword2.Value)
                || string.IsNullOrEmpty(txtmobile.Value) || string.IsNullOrEmpty(txtzip.Value)
                || string.IsNullOrEmpty(txtadress.Value) || string.IsNullOrEmpty(txtFamily.Value))
            {
                lblWarning.Text = "اطلاعات را کامل وارد کنید";
                return;
            }
            if (txtPassword.Value != txtpassword2.Value)
            {
                lblWarning.Text = "رمز های عبور مطابقت ندارند";
                return;
            }
            if (txtmobile.Value.Length < 11)
            {
                lblWarning.Text = "شماره موبایل 11 رقمی خود را وارد کنید";
                return;
            }
            if (txtzip.Value.Length < 10)
            {
                lblWarning.Text = "کد پستی 10 رقمی خود را وارد کنبد";
                return;
            }
            EmployeesRepository em = new EmployeesRepository();
            UsersRepository urr = new UsersRepository();
            if (rdiEmployees.Checked && em.isThereUsername(txtusername.Value))
            {
                lblWarning.Text = "این نام کاربری از قبل وجود دارد";
                lblWarning.ForeColor = Color.Red;
                return;
            }
            if (rdiUsers.Checked && urr.isThereUsername(txtusername.Value))
            {
                lblWarning.Text = "این نام کاربری از قبل وجود دارد";
                lblWarning.ForeColor = Color.Red;
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
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    if (rdiUsers.Checked)
                    {
                        DataAccess.User u = new DataAccess.User();
                        u.Address = txtadress.Value;
                        u.FirstName = txtName.Value;
                        u.LastName = txtFamily.Value;
                        u.Mobile = txtmobile.Value;
                        u.PostalCode = txtzip.Value;
                        u.Password = txtPassword.Value;
                        u.UserName = txtusername.Value;
                        u.City = ddlCity.SelectedValue.ToInt();
                        u.State = ddlState.SelectedValue.ToInt();
                        u.Email = txtEmail.Value;
                        u.RegSeen = false;

                        UsersRepository ur = new UsersRepository();
                        ur.SaveUsers(u);

                        int id = ur.getLastUserID();
                        Session.Add("userid", id);
                        Response.Redirect("/Employee/Profile");
                    }
                    else
                    {
                        DataAccess.Employee u = new DataAccess.Employee();
                        u.Address = txtadress.Value;
                        u.FirstName = txtName.Value;
                        u.LastName = txtFamily.Value;
                        u.Mobile = txtmobile.Value;
                        u.PostalCode = txtzip.Value;
                        u.Password = txtPassword.Value;
                        u.Score = 0;
                        u.UserName = txtusername.Value;
                        u.City = ddlCity.SelectedValue.ToInt();
                        u.State = ddlState.SelectedValue.ToInt();
                        u.Email = txtEmail.Value;
                        u.RegSeen = false;

                        EmployeesRepository ur = new EmployeesRepository();
                        ur.SaveEmployees(u);

                        int id = ur.getLastEmployeeID();
                        Session.Add("employeeid", id);
                        Response.Redirect("/Employee/Profile");
                    }
                    ts.Complete();
                }
                catch
                {
                }
            }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            CityRepository cr = new CityRepository();
            ddlCity.DataSource = cr.getCitiesInfoByStateID(ddlState.SelectedIndex + 1);
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityID";
            ddlCity.DataBind();
        }
    }
}
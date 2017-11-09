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
using System.IO;

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
            if (string.IsNullOrEmpty(txtName.Value) || string.IsNullOrEmpty(txtPassword.Value)
                || string.IsNullOrEmpty(txtusername.Value) || string.IsNullOrEmpty(txtpassword2.Value)
                || string.IsNullOrEmpty(txtmobile.Value) || string.IsNullOrEmpty(txtzip.Value)
                || string.IsNullOrEmpty(txtadress.Value) || string.IsNullOrEmpty(txtFamily.Value))
            {
                lblWarning.Text = "اطلاعات را کامل وارد کنید";
                txtImage.Value = "";
                FillImageText();
                return;
            }
            if (
                (txtusername.Value.Length > 50) || (txtName.Value.Length > 50) || (txtFamily.Value.Length > 50) ||
                (txtEmail.Value.Length > 150) || (txtPassword.Value.Length > 50) || (txtzip.Value.Length > 10) ||
                (txtmobile.Value.Length > 11) || (txtadress.Value.Length > 150) || (txtpassword2.Value.Length > 50) ||
                (txtImage.Value.Length > 5)
              )
            {
                lblWarning.Text = "اطلاعات ورودی بیش از حد مجاز";
                txtImage.Value = "";
                FillImageText();
                return;
            }
            if (txtPassword.Value != txtpassword2.Value)
            {
                lblWarning.Text = "رمز های عبور مطابقت ندارند";
                txtImage.Value = "";
                FillImageText();
                return;
            }
            if (txtmobile.Value.Length < 11)
            {
                lblWarning.Text = "شماره موبایل 11 رقمی خود را وارد کنید";
                txtImage.Value = "";
                FillImageText();
                return;
            }
            if (txtzip.Value.Length < 10)
            {
                lblWarning.Text = "کد پستی 10 رقمی خود را وارد کنبد";
                txtImage.Value = "";
                FillImageText();
                return;
            }
            EmployeesRepository em = new EmployeesRepository();
            UsersRepository urr = new UsersRepository();
            if (rdiEmployees.Checked && em.isThereUsername(txtusername.Value))
            {
                lblWarning.Text = "این نام کاربری از قبل وجود دارد";
                lblWarning.ForeColor = Color.Red;
                txtImage.Value = "";
                FillImageText();
                txtusername.Value = "";
                return;
            }
            if (em.isThereEmail(txtEmail.Value))
            {
                lblWarning.Text = "این ایمیل از قبل وجود دارد";
                lblWarning.ForeColor = Color.Red;
                txtImage.Value = "";
                FillImageText();
                txtEmail.Value = "";
                return;
            }
            if (rdiUsers.Checked && urr.isThereUsername(txtusername.Value))
            {
                lblWarning.Text = "این نام کاربری از قبل وجود دارد";
                lblWarning.ForeColor = Color.Red;
                txtImage.Value = "";
                FillImageText();
                txtusername.Value = "";
                return;
            }

            if (Session["ImgValue"].ToString() == txtImage.Value.ToUpper())
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
            bool Employee = false;
            bool User = false;
            bool isComplete = true;
            try
            {
                using (TransactionScope ts = new TransactionScope())
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
                        User = true;
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

                        FileStream fStream = File.OpenRead(Server.MapPath("~/_construction/images/user128px.png"));
                        byte[] contents = new byte[fStream.Length];
                        fStream.Read(contents, 0, (int)fStream.Length);
                        fStream.Close();

                        u.empImage = contents;
                        u.UserName = txtusername.Value;
                        u.City = ddlCity.SelectedValue.ToInt();
                        u.State = ddlState.SelectedValue.ToInt();
                        u.Email = txtEmail.Value;
                        u.RegSeen = false;

                        EmployeesRepository ur = new EmployeesRepository();
                        ur.SaveEmployees(u);

                        int id = ur.getLastEmployeeID();
                        Session.Add("employeeid", id);

                        Employee = true;
                    }

                    ts.Complete();
                }
            }
            catch (Exception m)
            {
                string txt = m.Message;
                isComplete = false;
            }
            if (isComplete)
            {
                if (Employee)
                {
                    Response.Redirect("/Employee/Profile");
                }
                else
                {
                    Response.Redirect("/User/Profile");
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
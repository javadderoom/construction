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


namespace WebPages
{
    public partial class EmployeeReg : System.Web.UI.Page
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
            DataAccess.User u = new DataAccess.User();
            u.Address = txtadress.Value;
            u.FirstName = txtName.Value;
            u.LastName = txtFamily.Value;
            u.Mobile = txtmobile.Value;
            u.PostalCode = txtzip.Value;
            u.Password = txtPassword.Value;
            u.UserName = txtusername.Value;
            u.City = ddlCity.SelectedValue;
            u.State = ddlState.SelectedValue;

            UsersRepository ur = new UsersRepository();
            ur.SaveUsers(u);



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
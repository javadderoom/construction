using Common;
using DataAccess.Repository;
using System;
using DataAccess;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages.Panels.UserPanel
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] != null)
            {
                if (!IsPostBack)
                {
                    setLabels();
                    fillDDL();
                }
            }
            else
            {
                Response.Redirect("/Login");
            }
        }

        private int id;

        private void setLabels()
        {
            int id = Session["userid"].ToString().ToInt();
            UsersRepository ru = new UsersRepository();
            DataTable dt = ru.getUserProfileInfo(id);

            lblid.Value = dt.Rows[0][0].ToString();
            hFullName.InnerText = dt.Rows[0][3].ToString() + " " + dt.Rows[0][4].ToString();

            lblfirstName.Value = dt.Rows[0][3].ToString();
            lblLastName.Value = dt.Rows[0][4].ToString();
            lblusername.Value = dt.Rows[0][1].ToString();
            password.Value = dt.Rows[0][2].ToString();
            lblzip.Value = dt.Rows[0][7].ToString();
            ddlState.SelectedIndex = (dt.Rows[0][8].ToString().ToInt() - 1);
            string asd = dt.Rows[0][9].ToString();
            ddlCity.SelectedValue = asd;
            lblmobile.Value = dt.Rows[0][5].ToString();
            lblemail.Value = dt.Rows[0][10].ToString();
            lbladdress.Value = dt.Rows[0][6].ToString();
        }

        public void fillDDL()
        {
            StatesRepository r = new StatesRepository();
            ddlState.DataSource = r.getStatesInfo();
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "StateID";
            ddlState.DataBind();

            CityRepository cr = new CityRepository();
            ddlCity.DataSource = cr.getCitiesInfoByStateID(ddlState.SelectedIndex + 1);
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityID";
            ddlCity.DataBind();
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            CityRepository cr = new CityRepository();
            ddlCity.DataSource = cr.getCitiesInfoByStateID(ddlState.SelectedIndex + 1);
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityID";
            ddlCity.DataBind();
        }

        private void save()
        {

            UsersRepository er = new UsersRepository();


            User em = er.getUserById(Session["userid"].ToString().ToInt());

            if (lbladdress.Value != "")
                em.Address = lbladdress.Value;
            em.City = ddlCity.SelectedValue.ToInt();
            em.State = ddlState.SelectedValue.ToInt();
            if (lblemail.Value != "")
                em.Email = lblemail.Value;
            if (lblfirstName.Value != "")
                em.FirstName = lblfirstName.Value;
            if (lblLastName.Value != "")
                em.LastName = lblLastName.Value;
            if (lblmobile.Value != "")
                em.Mobile = lblmobile.Value;
            if (password.Value != "")
                em.Password = password.Value;
            if (lblusername.Value != "")
                em.UserName = lblusername.Value;
            em.PostalCode = lblzip.Value;
            er.SaveUsers(em);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            save();
            Response.Redirect("/User/Profile");
        }
    }
}
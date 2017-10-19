using Common;
using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages.Panels.UserPanel
{
    public partial class ProjectApplication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            CityRepository cr = new CityRepository();
            ddlCity.DataSource = cr.getCitiesInfoByStateID(ddlState.SelectedIndex + 1);
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityID";
            ddlCity.DataBind();
        }
        protected void BtnSabt_Click(object sender, EventArgs e)
        {
            Order o = new Order();
            o.Address = address.Value;
            o.Budget = budget.Value;
            o.DeadLine = deadline.Value;
            o.MaxStartTime = maxTime.Value;
            o.IsSeen = false;
            o.Title = title.Value;
            o.Description = description.Value;
            o.UserID = Session["userid"].ToString().ToInt();
            o.City = ddlCity.SelectedValue.ToInt();
            o.State = ddlState.SelectedValue.ToInt();
            OrderRepository or = new OrderRepository();
            or.SaveOrder(o);
        }
    }
}
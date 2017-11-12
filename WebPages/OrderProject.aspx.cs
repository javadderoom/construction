using Common;
using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages
{
    public partial class OrderProject : System.Web.UI.Page
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
            if (
                (string.IsNullOrEmpty(name.Value) == false) && (string.IsNullOrEmpty(mobile.Value) == false) &&
                (string.IsNullOrEmpty(address.Value) == false) && (string.IsNullOrEmpty(budget.Value) == false) &&
                (string.IsNullOrEmpty(deadline.Value) == false) && (string.IsNullOrEmpty(maxTime.Value) == false) &&
                (string.IsNullOrEmpty(title.Value) == false) && (string.IsNullOrEmpty(description.Value) == false)
              )
            {
                try
                {
                    using (TransactionScope ts = new TransactionScope())
                    {
                        User user = new User();
                        UsersRepository ur = new UsersRepository();
                        user.UserName = DBManager.CurrentTimeWithoutColons() + DBManager.CurrentPersianDateWithoutSlash();

                        user.FirstName = "guest";
                        user.LastName = name.Value;
                        user.Mobile = mobile.Value;
                        ur.SaveUsers(user);
                        int id = ur.getLastUserID();
                        Order o = new Order();
                        o.Address = address.Value;
                        o.Budget = budget.Value;
                        o.DeadLine = deadline.Value;
                        o.MaxStartTime = maxTime.Value;
                        o.IsSeen = false;
                        o.Title = title.Value;
                        o.Description = description.Value;
                        o.UserID = id;
                        o.City = ddlCity.SelectedValue.ToInt();
                        o.State = ddlState.SelectedValue.ToInt();
                        OrderRepository or = new OrderRepository();
                        or.SaveOrder(o);

                        address.Value = string.Empty;
                        budget.Value = string.Empty;
                        deadline.Value = string.Empty;
                        maxTime.Value = string.Empty;
                        title.Value = string.Empty;
                        description.Value = string.Empty;
                        ts.Complete();
                    }
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('سفارش شما با موفقیت ارسال گردید.'),window.location ='/'", true);//لینک بشه
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('در هنگام ثبت سفارش مشکلی بوجود آمد.لطفا مجددا سعی کنید.')", true);//لینک بشه
                }
            }
        }
    }
}
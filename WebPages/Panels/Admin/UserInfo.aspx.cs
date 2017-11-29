using Common;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages.Panels.Admin
{
    public partial class UserInfo : System.Web.UI.Page
    {
        private int userid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminid"] != null)
            {
                userid = Session["useridForAdminDetails"].ToString().ToInt();
                if (!IsPostBack)
                {
                    setLabels();
                }
            }
            else
            {
                Response.Redirect("/AdminLogin");
            }
        }

        private void setLabels()
        {
            UsersRepository ur = new UsersRepository();
            DataTable dt = ur.getUserProfileInfo(userid);

            lbladdress.Value = dt.Rows[0][6].ToString();
            lblcitystate.Value = dt.Rows[0][18].ToString();
            lblemail.Value = dt.Rows[0][10].ToString();
            lblfullname.Value = dt.Rows[0][17].ToString();
            hFullName.InnerText = dt.Rows[0][17].ToString();
            lblid.Value = dt.Rows[0][0].ToString();
            lblmobile.Value = dt.Rows[0][5].ToString();
            lblusername.Value = dt.Rows[0][1].ToString();
            lblzip.Value = dt.Rows[0][7].ToString();
        }
    }
}
using Common;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Data;
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
            Session.Add("userid", 5);
            if (!IsPostBack)
            {
                setLabels();
            }
        }

        private void setLabels()
        {
            int id = Session["userid"].ToString().ToInt();
            UsersRepository ru = new UsersRepository();
            DataTable dt = ru.getUserProfileInfo(id);
            lblid.Value = dt.Rows[0][0].ToString();
            hFullName.InnerText = dt.Rows[0][16].ToString();
            lblfullname.Value = dt.Rows[0][16].ToString();

            lblusername.Value = dt.Rows[0][1].ToString();
            lblpassword.Value = dt.Rows[0][2].ToString();
            lblzip.Value = dt.Rows[0][7].ToString();
            lblmobile.Value = dt.Rows[0][5].ToString();
            lblemail.Value = dt.Rows[0][10].ToString();
            lbladdress.Value = dt.Rows[0][6].ToString();
            lblcitystate.Value = dt.Rows[0][17].ToString();
        }
    }
}
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
            lblid.InnerText = dt.Rows[0][0].ToString();
            lblfullname.InnerText = dt.Rows[0][16].ToString();
            lblusername.InnerText = dt.Rows[0][1].ToString();
            lblpassword.InnerText = dt.Rows[0][2].ToString();
            lblzip.InnerText = dt.Rows[0][7].ToString();
            lblmobile.InnerText = dt.Rows[0][5].ToString();
            lblemail.InnerText = dt.Rows[0][10].ToString();
            lbladdress.InnerText = dt.Rows[0][6].ToString();
            lblcitystate.InnerText = dt.Rows[0][17].ToString();


        }
    }
}
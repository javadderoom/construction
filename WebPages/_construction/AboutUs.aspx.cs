using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using DataAccess.Repository;

namespace WebPages._construction
{
    public partial class AboutUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAboat();
            }
        }

        private void LoadAboat()
        {
            ContactUsRepository repo = new ContactUsRepository();
            ContactWay cnw = repo.Findcwy(1);
            aboutUs.InnerHtml = cnw.AboutPage;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DataAccess;
using DataAccess.Repository;
using System.Web.UI.WebControls;

namespace WebPages.Panels.Admin
{
    public partial class NewAdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Timeout = 30;

            if (!IsPostBack)
            {
                MessageRepository repms = new MessageRepository();
                messageCount.InnerText = repms.AdminNewMessageCount();
                ContactUsRepository repo = new ContactUsRepository();
                ContactWay cnw = repo.Findcwy(1);
                phone.InnerHtml = "<span><i class='fa fa-phone' style='margin-right: 7px'></i>" + cnw.PhoneNumber + "</span>";
                mail.InnerHtml = "<span><i class='fa fa-envelope-o' style='margin-right: 7px'></i>" + cnw.Email + "</span>";
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Remove("adminid");
            Response.Redirect("/");
        }
    }
}
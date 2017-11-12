using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DataAccess;
using DataAccess.Repository;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Common;

namespace WebPages.Panels.Admin
{
    public partial class NewAdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Timeout = 120;

            if (!IsPostBack)
            {
                MessageRepository repms = new MessageRepository();
                messageCount.InnerText = repms.AdminNewMessageCount();

                OrderRepository or = new OrderRepository();
                OrderCount.InnerText = or.AdminNewOrders().ToString();
                ContactUsRepository repo = new ContactUsRepository();
                ContactWay cnw = repo.Findcwy(1);
                phone.InnerHtml = "<span><i class='fa fa-phone' style='margin-right: 7px'></i>" + cnw.PhoneNumber + "</span>";
                mail.InnerHtml = "<span><i class='fa fa-envelope-o' style='margin-right: 7px'></i>" + cnw.Email + "</span>";
                logo.Attributes["style"] = "background-image:url(" + setLogoImage() + ")";
            }
        }

        private string setLogoImage()
        {
            string ans = "";
            using (SqlConnection cn = new SqlConnection(OnlineTools.conString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(string.Format("select logo from ContactWay"), cn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                    {
                        if (dr.Read())
                        {
                            byte[] fileData = (byte[])dr.GetValue(0);
                            ans = "data:image/png;base64," + Convert.ToBase64String(fileData);
                        }

                        dr.Close();
                    }
                    cn.Close();
                }
            }
            return ans;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Remove("adminid");
            Response.Redirect("/");
        }
    }
}
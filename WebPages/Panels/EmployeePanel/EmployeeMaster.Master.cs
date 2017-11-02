using DataAccess;
using DataAccess.Repository;
using System;
using Common;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages.Panels.EmployeePanel
{
    public partial class EmployeeMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Timeout = 30;

            if (!IsPostBack)
            {
                EmployeesRepository repemplo = new EmployeesRepository();
                Employee emp = repemplo.getEmployeeByID(Session["employeeid"].ToString().ToInt());
                Name.InnerText = emp.FirstName + " " + emp.LastName;
                MessageRepository repmsg = new MessageRepository();
                messageCount.InnerText = repmsg.CountUserNewMessages(Session["employeeid"].ToString().ToInt());
                ContactUsRepository repo = new ContactUsRepository();
                ContactWay cnw = repo.Findcwy(1);
                phone.InnerHtml = "<span><i class='fa fa-phone' style='margin-right: 7px'></i>" + cnw.PhoneNumber + "</span>";
                mail.InnerHtml = "<span><i class='fa fa-envelope-o' style='margin-right: 7px'></i>" + cnw.Email + "</span>";
                AboutUs.InnerHtml = cnw.AboutUs;
                contactEmail.InnerHtml = "<i class='fa fa-envelope'></i>" + cnw.Email;
                contactPhone.InnerHtml = "<i class='fa fa-phone'></i>" + cnw.PhoneNumber;
                contactHome.InnerHtml = "<i class='fa fa-home'></i>" + cnw.Adrees;
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Remove("employeeid");
            Response.Redirect("/");
        }
    }
}
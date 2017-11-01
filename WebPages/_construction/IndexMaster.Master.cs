﻿using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages._construction
{
    public partial class Index : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool Admin = false;
            bool User = false;
            bool Employee = false;
            if (string.IsNullOrEmpty(Session["adminid"].ToString()) == false)//for Admin
            {
                Admin = true;
            }
            else if (string.IsNullOrEmpty(Session["userid"].ToString()) == false)//for User
            {
                User = true;

            }
            else if (string.IsNullOrEmpty(Session["employeeid"].ToString()) == false)//for Emplyoee
            {
                Employee = true;
            }

            if (!IsPostBack)
            {
                if (Admin)
                {

                }
                else if (User)
                {

                }
                else if (Employee)
                {

                }
                else
                {
                    profileContainer.InnerHtml = " <a href=\"#\" data-toggle=\"popover\" data-html=\"true\" data-placement=\"bottom\" data-content=\"<a style='text-align: center' href='Login'>وارد شوید </a><span><br />یا<br /> </span><a href='#'>ثبت نام</a> کنید\"> <div class=\"Profile\"></div> </a>";
                }
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
    }
}
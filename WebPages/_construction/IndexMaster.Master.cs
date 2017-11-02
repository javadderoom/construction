using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebPages._construction
{
    public partial class Index : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Timeout = 30;
            bool Admin = false;
            bool User = false;
            bool Employee = false;
            if (Session["adminid"] != null)//for Admin
            {
                string txt = Session["adminid"].ToString();
                Admin = true;
            }
            else if (Session["userid"] != null)//for User
            {
                User = true;
            }
            else if (Session["employeeid"] != null)//for Emplyoee
            {
                Employee = true;
            }

            if (!IsPostBack)
            {
                if (Admin)
                {
                    adminProfile();
                }
                else if (User)
                {
                    profileContainer.InnerHtml = "User";
                }
                else if (Employee)
                {
                    profileContainer.InnerHtml = "Employee";
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

        private void adminProfile()
        {
            var divv = new HtmlGenericControl("div");
            divv.Attributes["class"] = "popover-container";
            /////////////////////////////////////////////////////
            var btnProfile = new HtmlGenericControl("button");
            btnProfile.ID = "btnProfilePopover";
            btnProfile.Attributes["class"] = "logInProfile";
            btnProfile.Attributes["type"] = "button";
            //////////////////////////////////////////////////
            var div = new HtmlGenericControl("div");
            div.Attributes.Add("style", "display: none");
            div.ID = "myPopoverContent";
            ////////////////////////////////////////
            var div2 = new HtmlGenericControl("div");
            div2.Attributes["class"] = "popoverProfile";
            var img = new HtmlGenericControl("img"); ;
            img.Attributes["class"] = "popupProfileImg";
            string url = ResolveUrl("~/_construction/images/user128px.png");
            img.Attributes["src"] = url;
            var div3 = new HtmlGenericControl("div");
            div3.Attributes["class"] = "personName";
            div3.InnerText = "مدیر سایت";
            div2.Controls.Add(img);
            div2.Controls.Add(div3);
            div.Controls.Add(div2);
            /////////////////////////////////////////////////////////////////
            var div4 = new HtmlGenericControl("div");
            div4.Attributes["class"] = "popoverLinks";
            var ul = new HtmlGenericControl("ul");

            #region messageBox

            var li1 = new HtmlGenericControl("li");
            li1.Attributes["class"] = "message";
            var a1 = new HtmlGenericControl("a");
            a1.Attributes["href"] = "/Admin/Inbox";
            var div5 = new HtmlGenericControl("div");
            div5.Attributes["class"] = "mssageBox";
            var span = new HtmlGenericControl("span");
            span.Attributes["class"] = "messageBox";
            span.InnerText = "صندوق پيام ها";
            var span1 = new HtmlGenericControl("span");
            span1.Attributes["class"] = "messageCount";
            span1.Attributes["runat"] = "server";
            span1.ID = "messageCount";
            div5.Controls.Add(span);
            div5.Controls.Add(span1);
            a1.Controls.Add(div5);
            li1.Controls.Add(a1);

            #endregion messageBox

            #region orders

            var li2 = new HtmlGenericControl("li");
            li2.Attributes["class"] = "projects";
            var a2 = new HtmlGenericControl("a");
            a2.Attributes["href"] = "/Admin/Orders";
            a2.Attributes["class"] = "progectReq";
            var div6 = new HtmlGenericControl("div");
            div6.Attributes["class"] = "projectDiv";
            div6.InnerText = "سفارشات";
            a2.Controls.Add(div6);
            li2.Controls.Add(a2);

            #endregion orders

            #region ManageUsers

            var li3 = new HtmlGenericControl("li");
            li3.Attributes["class"] = "projects";
            var a3 = new HtmlGenericControl("a");
            a3.Attributes["class"] = "progectReq";
            a2.Attributes["href"] = "/Admin/ManageUsers";
            var div7 = new HtmlGenericControl("div");
            div7.Attributes["class"] = "projectDiv";
            div7.InnerText = "مديريت کاربران";
            a3.Controls.Add(div7);
            li3.Controls.Add(a3);

            #endregion ManageUsers

            #region AddProject

            var li4 = new HtmlGenericControl("li");
            li4.Attributes["class"] = "projects";
            var a4 = new HtmlGenericControl("a");
            a4.Attributes["href"] = "/Admin/AddProject";
            a4.Attributes["class"] = "progectReq";
            var div8 = new HtmlGenericControl("div");
            div8.Attributes["class"] = "projectDiv";
            div8.InnerText = "افزودن پروژه";
            a4.Controls.Add(div8);
            li4.Controls.Add(a4);

            #endregion AddProject

            #region MessageTak

            var li5 = new HtmlGenericControl("li");
            li5.Attributes["class"] = "projects";
            var a5 = new HtmlGenericControl("a");
            a5.Attributes["href"] = "/Admin/AddProject";
            a5.Attributes["class"] = "progectReq";
            var div9 = new HtmlGenericControl("div");
            div9.Attributes["class"] = "projectDiv";
            div9.InnerText = "ارسال پيام تکي";
            a5.Controls.Add(div8);
            li5.Controls.Add(a5);

            #endregion MessageTak

            #region Messagemany

            var li6 = new HtmlGenericControl("li");
            li6.Attributes["class"] = "projects";
            var a6 = new HtmlGenericControl("a");
            a6.Attributes["href"] = "/Admin/AddProject";
            a6.Attributes["class"] = "progectReq";
            var div0 = new HtmlGenericControl("div");
            div0.Attributes["class"] = "projectDiv";
            div0.InnerText = "ارسال پيام گروهي";
            a6.Controls.Add(div0);
            li6.Controls.Add(a6);

            #endregion Messagemany

            ul.Controls.Add(li1);
            ul.Controls.Add(li2);
            ul.Controls.Add(li3);
            ul.Controls.Add(li4);
            ul.Controls.Add(li5);
            ul.Controls.Add(li6);
            div4.Controls.Add(ul);
            div.Controls.Add(div4);
            //////////////////////////////////////
            var divLogOut = new HtmlGenericControl("div");
            divLogOut.Attributes["class"] = "logOutDiv";
            var div101 = new HtmlGenericControl("div");
            div101.Attributes["class"] = "logOutContent";
            div101.InnerText = "خروج";
            LinkButton link = new LinkButton();
            link.ID = "LinkButton1";
            //link.CssClass = "ij-effect-3";
            link.Attributes["runat"] = "server";
            link.Click += LinkButton1_Click;
            link.Text = "خروج";
            var span101 = new HtmlGenericControl("span");
            span101.Attributes["class"] = "glyphicon glyphicon-off iconLeft";
            div101.Controls.Add(span101);
            link.Controls.Add(div101);
            divLogOut.Controls.Add(link);
            ////////////////////////////////////////////////
            div.Controls.Add(divLogOut);
            divv.Controls.Add(btnProfile);
            divv.Controls.Add(div);

            profileContainer.Controls.Add(divv);
        }

        private void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Remove("adminid");
            Response.Redirect("/Blogs");
        }
    }
}
using Common;
using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            Session.Timeout = 120;
            bool Admin = false;
            bool User = false;
            bool Employee = false;
            if (Session["adminid"] != null)//for Admin
            {
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
            if (Admin)
            {
                adminProfile();
            }
            else if (User)
            {
                userProfile();
            }
            else if (Employee)
            {
                employeeProfile();
            }
            else
            {
                profileContainer.InnerHtml = " <a href=\"#\" data-toggle=\"popover\" data-html=\"true\" data-placement=\"bottom\" data-content=\"<a style='text-align: center' href='/Login'>وارد شوید </a><span><br />یا<br /> </span><a href='/Register'>ثبت نام</a> کنید\"> <div class=\"Profile\"></div> </a>";
            }
            if (!IsPostBack)
            {
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

        private string setInlineImage(int arid)
        {
            string ans = "";
            using (SqlConnection cn = new SqlConnection(OnlineTools.conString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(string.Format("select empImage from Employees where EmployeeID = {0}", arid), cn))
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

        private void userProfile()
        {
            var divv = new HtmlGenericControl("div");
            divv.Attributes["class"] = "popover-container";
            /////////////////////////////////////////////////////
            var btnProfile = new HtmlGenericControl("button");
            btnProfile.ID = "btnProfilePopover";
            btnProfile.Attributes["class"] = "logInProfile";
            btnProfile.Attributes["type"] = "button";

            //btnProfile.Controls.Add(img);
            ////////////////////////////////////////////////////////////////
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
            var divName = new HtmlGenericControl("div");
            divName.Attributes["class"] = "personName";
            divName.Attributes["runat"] = "server";
            divName.ID = "Name";
            var nav = new HtmlGenericControl("nav");
            nav.Attributes["class"] = "ij-effect-3";
            var aProfile = new HtmlGenericControl("a");
            aProfile.Attributes["href"] = "/Employee/Profile";
            aProfile.InnerText = "پروفایل";
            nav.Controls.Add(aProfile);
            ////
            div2.Controls.Add(img);
            div2.Controls.Add(divName);
            div2.Controls.Add(nav);

            UsersRepository repemplo = new UsersRepository();
            User user = repemplo.getUserById(Session["userid"].ToString().ToInt());

            divName.InnerText = user.FirstName + " " + user.LastName;
            div.Controls.Add(div2);
            ////////////////////////////////////////////////
            var div4 = new HtmlGenericControl("div");
            div4.Attributes["class"] = "popoverLinks";
            var ul = new HtmlGenericControl("ul");

            #region messageBox

            var li1 = new HtmlGenericControl("li");
            li1.Attributes["class"] = "message";
            var a1 = new HtmlGenericControl("a");
            a1.Attributes["href"] = "/User/Inbox";
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

            #region Message

            var li5 = new HtmlGenericControl("li");
            li5.Attributes["class"] = "projects";
            var a5 = new HtmlGenericControl("a");
            a5.Attributes["href"] = "/Employee/NewMessage";
            a5.Attributes["class"] = "progectReq";
            var div9 = new HtmlGenericControl("div");
            div9.Attributes["class"] = "projectDiv";
            div9.InnerText = "ارسال پيام";
            a5.Controls.Add(div9);
            li5.Controls.Add(a5);

            #endregion Message

            #region work

            var li4 = new HtmlGenericControl("li");
            li4.Attributes["class"] = "projects";
            var a4 = new HtmlGenericControl("a");
            a4.Attributes["href"] = "/User/OrderNewProject";
            a4.Attributes["class"] = "progectReq";
            var div8 = new HtmlGenericControl("div");
            div8.Attributes["class"] = "projectDiv";
            div8.InnerText = "سفارش پروژه";
            a4.Controls.Add(div8);
            li4.Controls.Add(a4);

            #endregion work

            MessageRepository repms = new MessageRepository();
            span1.InnerText = repms.CountUserNewMessages(Session["userid"].ToString().ToInt());
            ul.Controls.Add(li1);
            ul.Controls.Add(li5);
            ul.Controls.Add(li4);
            div4.Controls.Add(ul);
            ////////////////////////////////////////////////////
            var divLogOut = new HtmlGenericControl("div");
            divLogOut.Attributes["class"] = "logOutDiv";
            var div101 = new HtmlGenericControl("div");
            div101.Attributes["class"] = "logOutContent";
            div101.InnerText = "خروج";
            //LinkButton link = new LinkButton();

            //link.ID = "LinkButton1";
            ////link.CssClass = "ij-effect-3";

            //link.Click += LinkButton1_Click;
            LinkButton linkLogOut = new LinkButton();
            linkLogOut.ID = "lgOut";
            linkLogOut.Click += (s, e) =>
            {
                Session.Remove("userid");
                profileContainer.InnerHtml = " <a href=\"#\" data-toggle=\"popover\" data-html=\"true\" data-placement=\"bottom\" data-content=\"<a style='text-align: center' href='Login'>وارد شوید </a><span><br />یا<br /> </span><a href='#'>ثبت نام</a> کنید\"> <div class=\"Profile\"></div> </a>";

                Response.Redirect("/");
            };
            var span101 = new HtmlGenericControl("span");
            span101.Attributes["class"] = "glyphicon glyphicon-off iconLeft";
            div101.Controls.Add(span101);
            linkLogOut.Controls.Add(div101);
            divLogOut.Controls.Add(linkLogOut);
            ////////////////////////////////////////////////
            div.Controls.Add(div4);
            div.Controls.Add(divLogOut);

            divv.Controls.Add(btnProfile);
            divv.Controls.Add(div);

            profileContainer.Controls.Add(divv);
        }

        private void employeeProfile()
        {
            var divv = new HtmlGenericControl("div");
            divv.Attributes["class"] = "popover-container";
            /////////////////////////////////////////////////////
            var btnProfile = new HtmlGenericControl("button");
            btnProfile.ID = "btnProfilePopover";
            btnProfile.Attributes["class"] = "logInProfile2";
            btnProfile.Attributes["type"] = "button";
            var pimg2 = new HtmlGenericControl("img");
            pimg2.ID = "pimg2";
            pimg2.Attributes["class"] = "popupProfileImg";
            pimg2.Attributes.Add("style", "width : 55px;height : 55px");
            btnProfile.Controls.Add(pimg2);
            ////////////////////////////////////////////////////////////////
            var div = new HtmlGenericControl("div");
            div.Attributes.Add("style", "display: none");
            div.ID = "myPopoverContent";
            ////////////////////////////////////////
            var div2 = new HtmlGenericControl("div");
            div2.Attributes["class"] = "popoverProfile";
            var pImg = new HtmlGenericControl("img"); ;
            pImg.Attributes["class"] = "popupProfileImg";
            pImg.ID = "pImg";
            pImg.Attributes["runat"] = "server";
            var divName = new HtmlGenericControl("div");
            divName.Attributes["class"] = "personName";
            divName.Attributes["runat"] = "server";
            divName.ID = "Name";
            var nav = new HtmlGenericControl("nav");
            nav.Attributes["class"] = "ij-effect-3";
            var aProfile = new HtmlGenericControl("a");
            aProfile.Attributes["href"] = "/Employee/Profile";
            aProfile.InnerText = "پروفایل";
            nav.Controls.Add(aProfile);
            ////
            div2.Controls.Add(pImg);
            div2.Controls.Add(divName);
            div2.Controls.Add(nav);
            EmployeesRepository repemplo = new EmployeesRepository();
            Employee emp = repemplo.getEmployeeByID(Session["employeeid"].ToString().ToInt());
            pImg.Attributes["src"] = setInlineImage(Session["employeeid"].ToString().ToInt());
            pimg2.Attributes["src"] = setInlineImage(Session["employeeid"].ToString().ToInt());
            divName.InnerText = emp.FirstName + " " + emp.LastName;
            div.Controls.Add(div2);
            ////////////////////////////////////////////////
            var div4 = new HtmlGenericControl("div");
            div4.Attributes["class"] = "popoverLinks";
            var ul = new HtmlGenericControl("ul");

            #region messageBox

            var li1 = new HtmlGenericControl("li");
            li1.Attributes["class"] = "message";
            var a1 = new HtmlGenericControl("a");
            a1.Attributes["href"] = "/Employee/Inbox";
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

            #region Message

            var li5 = new HtmlGenericControl("li");
            li5.Attributes["class"] = "projects";
            var a5 = new HtmlGenericControl("a");
            a5.Attributes["href"] = "/Employee/NewMessage";
            a5.Attributes["class"] = "progectReq";
            var div9 = new HtmlGenericControl("div");
            div9.Attributes["class"] = "projectDiv";
            div9.InnerText = "ارسال پيام";
            a5.Controls.Add(div9);
            li5.Controls.Add(a5);

            #endregion Message

            #region work

            var li4 = new HtmlGenericControl("li");
            li4.Attributes["class"] = "projects";
            var a4 = new HtmlGenericControl("a");
            a4.Attributes["href"] = "/Employee/SelectJob";
            a4.Attributes["class"] = "progectReq";
            var div8 = new HtmlGenericControl("div");
            div8.Attributes["class"] = "projectDiv";
            div8.InnerText = "انتخاب شغل";
            a4.Controls.Add(div8);
            li4.Controls.Add(a4);

            #endregion work

            MessageRepository repms = new MessageRepository();
            span1.InnerText = repms.CountUserNewMessages(Session["employeeid"].ToString().ToInt());
            ul.Controls.Add(li1);
            ul.Controls.Add(li5);
            ul.Controls.Add(li4);
            div4.Controls.Add(ul);
            ////////////////////////////////////////////////////
            var divLogOut = new HtmlGenericControl("div");
            divLogOut.Attributes["class"] = "logOutDiv";
            var div101 = new HtmlGenericControl("div");
            div101.Attributes["class"] = "logOutContent";
            div101.InnerText = "خروج";
            //LinkButton link = new LinkButton();

            //link.ID = "LinkButton1";
            ////link.CssClass = "ij-effect-3";

            //link.Click += LinkButton1_Click;
            LinkButton linkLogOut = new LinkButton();
            linkLogOut.ID = "lgOut";
            linkLogOut.Click += (s, e) =>
            {
                Session.Remove("employeeid");
                profileContainer.InnerHtml = " <a href=\"#\" data-toggle=\"popover\" data-html=\"true\" data-placement=\"bottom\" data-content=\"<a style='text-align: center' href='Login'>وارد شوید </a><span><br />یا<br /> </span><a href='#'>ثبت نام</a> کنید\"> <div class=\"Profile\"></div> </a>";

                Response.Redirect("/");
            };
            var span101 = new HtmlGenericControl("span");
            span101.Attributes["class"] = "glyphicon glyphicon-off iconLeft";
            div101.Controls.Add(span101);
            linkLogOut.Controls.Add(div101);
            divLogOut.Controls.Add(linkLogOut);
            ////////////////////////////////////////////////
            div.Controls.Add(div4);
            div.Controls.Add(divLogOut);

            divv.Controls.Add(btnProfile);
            divv.Controls.Add(div);

            profileContainer.Controls.Add(divv);
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
            var ulManage1 = new HtmlGenericControl("ul");
            ulManage1.Attributes["class"] = "ulManage1";
            var ulManage2 = new HtmlGenericControl("ul");
            ulManage2.Attributes["class"] = "ulManage2";
            var divp2 = new HtmlGenericControl("div");
            divp2.Attributes["class"] = "popoverLinks collapse";
            divp2.ID = "colap";

            #region messageSection

            var liMS = new HtmlGenericControl("li");
            liMS.Attributes["class"] = "projects";
            liMS.Attributes.Add("style", "text-align: center");
            var hM = new HtmlGenericControl("h4");
            hM.Attributes["class"] = "projectDiv";
            hM.InnerText = "پیام ها";
            liMS.Controls.Add(hM);

            #endregion messageSection

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

            MessageRepository repms = new MessageRepository();
            span1.InnerText = repms.AdminNewMessageCount();

            #region ordersList

            var liorders = new HtmlGenericControl("li");
            liorders.Attributes["class"] = "message";
            var aorders = new HtmlGenericControl("a");
            aorders.Attributes["href"] = "/Admin/Orders";
            var divorders = new HtmlGenericControl("div");
            divorders.Attributes["class"] = "mssageBox";
            var spanorders = new HtmlGenericControl("span");
            spanorders.Attributes["class"] = "messageBox";
            spanorders.InnerText = "سفارشات";
            var span1orders = new HtmlGenericControl("span");
            span1orders.Attributes["class"] = "messageCount";
            span1orders.Attributes["runat"] = "server";
            span1orders.ID = "OrderCount";
            divorders.Controls.Add(spanorders);
            divorders.Controls.Add(span1orders);
            aorders.Controls.Add(divorders);
            liorders.Controls.Add(aorders);

            #endregion ordersList

            OrderRepository or = new OrderRepository();
            span1orders.InnerText = or.AdminNewOrders().ToString();

            #region MessageTak

            var li5 = new HtmlGenericControl("li");
            li5.Attributes["class"] = "projects";
            var a5 = new HtmlGenericControl("a");
            a5.Attributes["href"] = "/Admin/Message";
            a5.Attributes["class"] = "progectReq";
            var div9 = new HtmlGenericControl("div");
            div9.Attributes["class"] = "projectDiv";
            div9.InnerText = "ارسال پيام تکي";
            a5.Controls.Add(div9);
            li5.Controls.Add(a5);

            #endregion MessageTak

            #region Messagemany

            var li6 = new HtmlGenericControl("li");
            li6.Attributes["class"] = "projects";
            var a6 = new HtmlGenericControl("a");
            a6.Attributes["href"] = "/Admin/GroupMessage";
            a6.Attributes["class"] = "progectReq";
            var div0 = new HtmlGenericControl("div");
            div0.Attributes["class"] = "projectDiv";
            div0.InnerText = "ارسال پيام گروهي";
            a6.Controls.Add(div0);
            li6.Controls.Add(a6);

            #endregion Messagemany

            ul.Controls.Add(liMS);
            ul.Controls.Add(li1);
            ul.Controls.Add(liorders);
            ul.Controls.Add(li5);
            ul.Controls.Add(li6);
            div4.Controls.Add(ul);

            #region managementSection

            //data - toggle = "collapse" data - target = "#demo"
            var divManageS = new HtmlGenericControl("div");

            divManageS.Attributes.Add("style", "text-align: center");
            var hManage = new HtmlGenericControl("h4");
            divManageS.Attributes["class"] = "manageTitle";
            hManage.InnerText = "بخش مدیریتی";
            divManageS.Controls.Add(hManage);
            divManageS.Attributes["data-toggle"] = "collapse";
            divManageS.Attributes["data-target"] = "#colap";

            #endregion managementSection

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

            #region AddMaghale

            var liMaghale = new HtmlGenericControl("li");
            liMaghale.Attributes["class"] = "projects";
            var aMaghale = new HtmlGenericControl("a");
            aMaghale.Attributes["href"] = "/Admin/AddBlog";
            aMaghale.Attributes["class"] = "progectReq";
            var divMaghale = new HtmlGenericControl("div");
            divMaghale.Attributes["class"] = "projectDiv";
            divMaghale.InnerText = "مقاله جدید";
            aMaghale.Controls.Add(divMaghale);
            liMaghale.Controls.Add(aMaghale);

            #endregion AddMaghale

            #region ManageUsers

            var li3 = new HtmlGenericControl("li");
            li3.Attributes["class"] = "projects";
            var a3 = new HtmlGenericControl("a");
            a3.Attributes["class"] = "progectReq";
            a3.Attributes["href"] = "/Admin/ManageUsers";
            var div7 = new HtmlGenericControl("div");
            div7.Attributes["class"] = "projectDiv";
            div7.InnerText = "مديريت کاربران";
            a3.Controls.Add(div7);
            li3.Controls.Add(a3);

            #endregion ManageUsers

            #region ManageWeblog

            var liWeblog = new HtmlGenericControl("li");
            liWeblog.Attributes["class"] = "projects";
            var aWeblog = new HtmlGenericControl("a");
            aWeblog.Attributes["class"] = "progectReq";
            aWeblog.Attributes["href"] = "/Admin/ManageBlogs";
            var divWeblog = new HtmlGenericControl("div");
            divWeblog.Attributes["class"] = "projectDiv";
            divWeblog.InnerText = "مديريت وبلاگ ها";
            aWeblog.Controls.Add(divWeblog);
            liWeblog.Controls.Add(aWeblog);

            #endregion ManageWeblog

            #region ManageProjects

            var liManageProjects = new HtmlGenericControl("li");
            liManageProjects.Attributes["class"] = "projects";
            var aManageProjects = new HtmlGenericControl("a");
            aManageProjects.Attributes["href"] = "/Admin/ManageProjects";
            aManageProjects.Attributes["class"] = "progectReq";
            var divManageProjects = new HtmlGenericControl("div");
            divManageProjects.Attributes["class"] = "projectDiv";
            divManageProjects.InnerText = "مدیریت پروژه ها";
            aManageProjects.Controls.Add(divManageProjects);
            liManageProjects.Controls.Add(aManageProjects);

            #endregion ManageProjects

            #region FirstPage

            var liFirstPage = new HtmlGenericControl("li");
            liFirstPage.Attributes["class"] = "projects";
            var aFirstPage = new HtmlGenericControl("a");
            aFirstPage.Attributes["href"] = "/Admin/ManageFirstPage";
            aFirstPage.Attributes["class"] = "progectReq";
            var divFirstPage = new HtmlGenericControl("div");
            divFirstPage.Attributes["class"] = "projectDiv";
            divFirstPage.InnerText = "مدیریت صفحه اول";
            aFirstPage.Controls.Add(divFirstPage);
            liFirstPage.Controls.Add(aFirstPage);

            #endregion FirstPage

            #region Services

            var liServices = new HtmlGenericControl("li");
            liServices.Attributes["class"] = "projects";
            var aServices = new HtmlGenericControl("a");
            aServices.Attributes["href"] = "/Admin/ManageGroups";
            aServices.Attributes["class"] = "progectReq";
            var divServices = new HtmlGenericControl("div");
            divServices.Attributes["class"] = "projectDiv";
            divServices.InnerText = "مدیریت خدمات";
            aServices.Controls.Add(divServices);
            liServices.Controls.Add(aServices);

            #endregion Services

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

            #region Scores

            var liScores = new HtmlGenericControl("li");
            liScores.Attributes["class"] = "projects";
            var aScores = new HtmlGenericControl("a");
            aScores.Attributes["href"] = "/Admin/Scores";
            aScores.Attributes["class"] = "progectReq";
            var divScores = new HtmlGenericControl("div");
            divScores.Attributes["class"] = "projectDiv";
            divScores.InnerText = "امتیازات";
            aScores.Controls.Add(divScores);
            liScores.Controls.Add(aScores);

            #endregion Scores

            #region Scores

            var liJobs = new HtmlGenericControl("li");
            liJobs.Attributes["class"] = "projects";
            var aJobs = new HtmlGenericControl("a");
            aJobs.Attributes["href"] = "/Admin/ManageJobGroups";
            aJobs.Attributes["class"] = "progectReq";
            var divJobs = new HtmlGenericControl("div");
            divJobs.Attributes["class"] = "projectDiv";
            divJobs.InnerText = "میدیرت مشاغل";
            aJobs.Controls.Add(divJobs);
            liJobs.Controls.Add(aJobs);

            #endregion Scores

            //ul2.Controls.Add(liManageS);
            ulManage1.Controls.Add(li4);
            ulManage1.Controls.Add(liMaghale);
            ulManage1.Controls.Add(li3);
            ulManage1.Controls.Add(liWeblog);
            ulManage1.Controls.Add(liManageProjects);
            ulManage2.Controls.Add(liFirstPage);
            ulManage2.Controls.Add(liServices);
            ulManage2.Controls.Add(li2);
            ulManage2.Controls.Add(liScores);
            ulManage2.Controls.Add(liJobs);
            divp2.Controls.Add(ulManage1);
            divp2.Controls.Add(ulManage2);
            div.Controls.Add(div4);
            div.Controls.Add(divManageS);
            div.Controls.Add(divp2);
            //////////////////////////////////////
            var divLogOut = new HtmlGenericControl("div");
            divLogOut.Attributes["class"] = "logOutDiv";
            var div101 = new HtmlGenericControl("div");
            div101.Attributes["class"] = "logOutContent";
            div101.InnerText = "خروج";
            //LinkButton link = new LinkButton();

            //link.ID = "LinkButton1";
            ////link.CssClass = "ij-effect-3";

            //link.Click += LinkButton1_Click;

            LinkButton linkLogOut = new LinkButton();
            linkLogOut.ID = "lgOut";
            linkLogOut.Click += (s, e) =>
            {
                Session.Remove("adminid");
                profileContainer.InnerHtml = " <a href=\"#\" data-toggle=\"popover\" data-html=\"true\" data-placement=\"bottom\" data-content=\"<a style='text-align: center' href='Login'>وارد شوید </a><span><br />یا<br /> </span><a href='#'>ثبت نام</a> کنید\"> <div class=\"Profile\"></div> </a>";

                Response.Redirect("/");
            };
            //var link = new HtmlGenericControl("a");
            //link.Attributes["href"] = "javascript:__doPostBack('ctl00$ctl55$LinkButton1','')";
            //link.Attributes["class"] = "ij-effect-3";
            //link.ID = "LinkButton1";
            var span101 = new HtmlGenericControl("span");
            span101.Attributes["class"] = "glyphicon glyphicon-off iconLeft";
            div101.Controls.Add(span101);
            linkLogOut.Controls.Add(div101);
            divLogOut.Controls.Add(linkLogOut);
            ////////////////////////////////////////////////
            div.Controls.Add(divLogOut);

            divv.Controls.Add(btnProfile);
            divv.Controls.Add(div);

            profileContainer.Controls.Add(divv);
        }
    }
}
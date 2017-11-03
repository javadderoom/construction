using DataAccess;
using DataAccess.Repository;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Threading;

namespace WebPages._construction
{
    public partial class Index1 : System.Web.UI.Page
    {
        private void SetProjects()
        {
            string txt = "";
            ProjectsRepository rep = new ProjectsRepository();
            List<Project> plist = rep.Top6tProjects();

            foreach (Project pr in plist)
            {
                txt += "<div class='project mix catHouses'>  <img src='" + setProjectInlineImage(pr.ProjectID) + "' alt='Project1' class='projectImg img-responsive'/>  <div class='projectDetails row m0'> <div class='fleft projectIcons btn-group' role='group'>  <a href= '" + "/Projects/" + pr.ProjectID + "/" + pr.Title.Replace(' ', '-') + "' class='btn btn-default'><i class='fa fa-file-o'></i></a> </div><div class='fright nameType'> <div class='row m0 projectName'>" + pr.Title + "</div></div></div></div>";
            }
            projectss.InnerHtml = txt + txt;
        }

        private string setBKGSrc(int SlideID)
        {
            string ans = "";
            using (SqlConnection cn = new SqlConnection(OnlineTools.conString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(string.Format("select BackgroundImg from Slider where SlideID = {0}", SlideID), cn))
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

        private string setRightimgSrc(int SlideID)
        {
            string ans = "";
            using (SqlConnection cn = new SqlConnection(OnlineTools.conString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(string.Format("select thumbnail from Slider where SlideID = {0}", SlideID), cn))
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

        private void LoadSliders()
        {
            SliderRepository repSlider = new SliderRepository();
            Slider slide1 = repSlider.FindSlider(1);
            Slider slide2 = repSlider.FindSlider(2);
            Slider slide3 = repSlider.FindSlider(3);

            bImg1.Src = setBKGSrc(1);
            bImg2.Src = setBKGSrc(2);
            bImg3.Src = setBKGSrc(3);

            divText1.InnerHtml = slide1.Text;
            divText2.InnerHtml = slide2.Text;
            divText3.InnerHtml = slide3.Text;

            if (slide1.thumbnail != null)
            {
                rightPic.InnerHtml = "<img src='" + setRightimgSrc(1) + "' alt='عکس'/>";
            }
            if (slide2.thumbnail != null)
            {
                rightPic2.InnerHtml = "<img src='" + setRightimgSrc(2) + "' alt='عکس'/>";
            }
            if (slide3.thumbnail != null)
            {
                rightPic3.InnerHtml = "<img src='" + setRightimgSrc(3) + "' alt='عکس'/>";
            }

            if (slide1.Link != null)
            {
                diva1.InnerHtml = "<a type='button' href='" + slide1.Link + "' class='btn btn-default'>بیشتر بدانید</a>";
            }
            if (slide2.Link != null)
            {
                diva2.InnerHtml = "<a type='button' href='" + slide2.Link + "' class='btn btn-default'>بیشتر بدانید</a>";
            }
            if (slide3.Link != null)
            {
                diva3.InnerHtml = "<a type='button' href='" + slide3.Link + "' class='btn btn-default'>بیشتر بدانید</a>";
            }
        }

        private void fillServises()
        {
            GroupsRepository gr = new GroupsRepository();
            List<Group> groups = new List<Group>();
            groups = gr.LoadListAllGroups();
            foreach (Group gp in groups)
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////
                Button btnLeft = new Button();
                btnLeft.CssClass = "btnLeftService";
                btnLeft.Text = "مقالات";
                btnLeft.ID = "l" + gp.GroupID.ToString();
                btnLeft.Click += (s, e) =>
                {
                    Button btn = (Button)s;

                    string id = btn.ID.Replace("l", "");
                    Session.Add("GroupidForOpenBlog", id);
                    Response.Redirect("/Blogs");
                };

                Button btnRight = new Button();
                btnRight.CssClass = "btnRightService";
                btnRight.Text = "زیر گروه ها";
                btnRight.Click += BtnRight_Click;
                btnRight.ID = gp.GroupID.ToString();
                btnRight.OnClientClick = "owl()";

                var li1 = new HtmlGenericControl("li");
                li1.Attributes["class"] = "liLeft";

                var li2 = new HtmlGenericControl("li");
                li2.Attributes["class"] = "liRight";
                var ul = new HtmlGenericControl("ul");

                var div6 = new HtmlGenericControl("div");
                div6.Attributes["class"] = "item-overlay left";
                var div41 = new HtmlGenericControl("div");
                div41.Attributes["class"] = "serviceName";
                div41.InnerText = gp.Title;

                var i = new HtmlGenericControl("i");
                i.Attributes["class"] = "fa fa-laptop";
                var div4 = new HtmlGenericControl("div");
                var div3 = new HtmlGenericControl("div");
                div3.Attributes["class"] = "row m0 innerRow item";
                var div2 = new HtmlGenericControl("div");
                div2.Attributes["class"] = "row m0 service";
                var div1 = new HtmlGenericControl("div");
                div1.Attributes["class"] = "item";
                var div = new HtmlGenericControl("div");
                div.Attributes["class"] = "owl-one owl-carousel";
                div.ID = "ourServises";

                li2.Controls.Add(btnRight);
                li1.Controls.Add(btnLeft);
                ul.Controls.Add(li1);
                ul.Controls.Add(li2);
                div6.Controls.Add(ul);
                div4.Controls.Add(i);
                div4.Controls.Add(div41);
                div4.Controls.Add(div6);
                div3.Controls.Add(div4);
                div2.Controls.Add(div3);
                div1.Controls.Add(div2);
                div.Controls.Add(div1);
                ourServises.Controls.Add(div1);
            }

            //ourServises.InnerHtml = content;
        }

        private void BtnRight_Click(object sender, EventArgs e)
        {
            servisContent.InnerHtml = "";
            Button btn = (Button)sender;

            string id = btn.ID;
            fillSungroups(id);
            triggers();
            fillServises();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "myFunc()", true);
        }

        //<div class="subGroup col-md-2 col-xs-4">گروه 1</div>
        private void fillSungroups(string id)
        {
            updateProgress.Visible = true;
            GroupsRepository gr = new GroupsRepository();
            List<Group> groups = new List<Group>();
            int ID = id.ToInt();
            groups = gr.LoadListSubGroup(ID);
            if (groups.Count > 0)
            {
                servisContent.InnerHtml = "";
                foreach (Group gp in groups)
                {
                    LinkButton link = new LinkButton();
                    link.CssClass = "subGroup";
                    link.Text = gp.Title;
                    link.OnClientClick = "FireEvent();";
                    link.ID = gp.GroupID.ToString();

                    ScriptManager.GetCurrent(this).RegisterPostBackControl(link);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "function", "function FireEvent(){$('#'" + link.ClientID + ").trigger('click');}", true);
                    link.Click += Link_Click;
                    link.Click += (s, e) =>
                    {
                        LinkButton btn2 = (LinkButton)s;

                        string idTosend = btn2.ID;
                        Session.Add("SubGroupidForOpenBlog", idTosend);
                        Response.Redirect("/Blogs");
                    };

                    //Button btn = new Button();
                    //btn.CssClass = "subGroup";
                    //btn.Text = gp.Title;
                    //btn.ID = gp.GroupID.ToString();
                    //btn.Click += (s, e) =>
                    //{
                    //    Button btn2 = (Button)s;

                    //    string idTosend = btn2.ID;
                    //    Session.Add("SubGroupidForOpenBlog", idTosend);
                    //    Response.Redirect("/Blogs");
                    //};
                    //var div = new HtmlGenericControl("div");
                    //div.Attributes["class"] = "subGroup ";
                    //div.InnerText = gp.Title;
                    //div.Attributes["runat"] = "server";

                    servisContent.Controls.Add(link);
                    //ScriptManager1.RegisterAsyncPostBackControl(div);
                }
            }
            else
            {
                servisContent.InnerHtml = "<h3 style='float: right;'>برای این گروه زیر گروهی وجود ندارد</h3>";
            }
        }

        private void Link_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('نام کاربری یا رمز عبور را وارد نکردید ! ');", true);
        }

        private void fillArticles(List<Article> artList)
        {
            string text = "";
            foreach (Article article in artList)
            {
                if (article.Abstract.Count() > 130)
                {
                    if (article.Title.Count() > 30)
                    {
                        if ((130 - (article.Title.Count() - 30)) < 1)
                        {
                            text += "<li><div class='col-sm-4 blog'><div class='row m0 blogInner'><div class='row m0 blogDateTime'><i class='fa fa-calendar'></i>" + article.PostDateTime + "</div><div class='row m0 featureImg'><a href = '" + "/Blogs/" + article.ArticleID + "/" + article.Title.Replace(' ', '-') + "' ><img src='" + setInlineImage(article.ArticleID) + "' alt='عکس' class='img-responsive'/></a></div><div class='row m0 postExcerpts'><div class='row m0 postExcerptInner'><a href = '" + "/Blogs/" + article.ArticleID + "/" + article.Title.Replace(' ', '-') + "' class='postTitle row m0'><h4>" + article.Title + "</h4></a><p></p>...<a href = '" + "/Blogs/" + article.ArticleID + "/" + article.Title.Replace(' ', '-') + "' class='readMore'>ادامه</a></div></div></div></div></li>";
                        }
                        else
                        {
                            text += "<li><div class='col-sm-4 blog'><div class='row m0 blogInner'><div class='row m0 blogDateTime'><i class='fa fa-calendar'></i>" + article.PostDateTime + "</div><div class='row m0 featureImg'><a href = '" + "/Blogs/" + article.ArticleID + "/" + article.Title.Replace(' ', '-') + "' ><img src='" + setInlineImage(article.ArticleID) + "' alt='عکس' class='img-responsive'/></a></div><div class='row m0 postExcerpts'><div class='row m0 postExcerptInner'><a href = '" + "/Blogs/" + article.ArticleID + "/" + article.Title.Replace(' ', '-') + "' class='postTitle row m0'><h4>" + article.Title + "</h4></a><p>" + article.Abstract.Substring(0, 130 - (article.Title.Count() - 30)) + "</p>...<a href = '" + "/Blogs/" + article.ArticleID + "/" + article.Title.Replace(' ', '-') + "' class='readMore'>ادامه</a></div></div></div></div></li>";
                        }
                    }
                    else
                    {
                        text += "<li><div class='col-sm-4 blog'><div class='row m0 blogInner'><div class='row m0 blogDateTime'><i class='fa fa-calendar'></i>" + article.PostDateTime + "</div><div class='row m0 featureImg'><a href = '" + "/Blogs/" + article.ArticleID + "/" + article.Title.Replace(' ', '-') + "' ><img src='" + setInlineImage(article.ArticleID) + "' alt='عکس' class='img-responsive'/></a></div><div class='row m0 postExcerpts'><div class='row m0 postExcerptInner'><a href = '" + "/Blogs/" + article.ArticleID + "/" + article.Title.Replace(' ', '-') + "' class='postTitle row m0'><h4>" + article.Title + "</h4></a><p>" + article.Abstract.Substring(0, 130) + "</p>...<a href = '" + "/Blogs/" + article.ArticleID + "/" + article.Title.Replace(' ', '-') + "' class='readMore'>ادامه</a></div></div></div></div></li>";
                    }
                }
                else
                {
                    text += "<li><div class='col-sm-4 blog'><div class='row m0 blogInner'><div class='row m0 blogDateTime'><i class='fa fa-calendar'></i>" + article.PostDateTime + "</div><div class='row m0 featureImg'><a href = '" + "/Blogs/" + article.ArticleID + "/" + article.Title.Replace(' ', '-') + "' ><img src='" + setInlineImage(article.ArticleID) + "' alt='عکس' class='img-responsive'/></a></div><div class='row m0 postExcerpts'><div class='row m0 postExcerptInner'><a href = '" + "/Blogs/" + article.ArticleID + "/" + article.Title.Replace(' ', '-') + "' class='postTitle row m0'><h4>" + article.Title + "</h4></a><p>" + article.Abstract + "</p>...<a href = '" + "/Blogs/" + article.ArticleID + "/" + article.Title.Replace(' ', '-') + "' class='readMore'>ادامه</a></div></div></div></div></li>";
                }
            }
            blogsContainer.InnerHtml = text;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            fillServises();
            triggers();
            if (!IsPostBack)
            {
                SetProjects();
                List<Article> articles = new List<Article>();
                ArticleRepository artRep = new ArticleRepository();
                articles = artRep.Top3tArticles();

                fillArticles(articles);

                LoadSliders();
                //string s = "1";
                //fillSungroups(s);
            }
        }

        private void triggers()
        {
            GroupsRepository gr = new GroupsRepository();
            List<Group> groups = new List<Group>();
            groups = gr.LoadListAllGroups();
            foreach (Group gp in groups)
            {
                AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
                trigger.ControlID = gp.GroupID.ToString();
                trigger.EventName = "Click";
                updatepanel2.Triggers.Add(trigger);
            }
        }

        private string setInlineImage(int arid)
        {
            string ans = "";
            using (SqlConnection cn = new SqlConnection(OnlineTools.conString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(string.Format("select Image from Articles where ArticleID = {0}", arid), cn))
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

        private string setProjectInlineImage(int arid)
        {
            string ans = "";
            using (SqlConnection cn = new SqlConnection(OnlineTools.conString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(string.Format("select Image from Projects where ProjectID = {0}", arid), cn))
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

        //<div class="subGroup col-md-2 col-xs-4">گروه 1</div>
        protected void subGroups_ServerClick(object sender, EventArgs e)
        {
        }

        protected void articles_ServerClick(object sender, EventArgs e)
        {
        }
    }
}
﻿using DataAccess;
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

namespace WebPages._construction
{
    public partial class Index1 : System.Web.UI.Page
    {
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
                //ScriptManager1.RegisterAsyncPostBackControl(div1);
                //< div class="owl-one owl-carousel " runat="server" id="ourServises">
                //var cons = Form.FindControl("ContentPlaceHolder1_ourServises");
                //cons.Controls.Add(div1);
                ///////////////////////////////////////////////////////////////////////////////////////////////////////
            }

            //ourServises.InnerHtml = content;
        }

        private void BtnRight_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            string id = btn.ID;
            fillSungroups(id);
            GroupsRepository gr1 = new GroupsRepository();
            List<Group> groups1 = new List<Group>();
            groups1 = gr1.LoadListAllGroups();
            foreach (Group gp in groups1)
            {
                AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
                trigger.ControlID = gp.GroupID.ToString();
                trigger.EventName = "Click";
                updatepanel2.Triggers.Add(trigger);
            }
            fillServises();
        }

        //<div class="subGroup col-md-2 col-xs-4">گروه 1</div>
        private void fillSungroups(string id)
        {
            GroupsRepository gr = new GroupsRepository();
            List<Group> groups = new List<Group>();
            int ID = id.ToInt();
            groups = gr.LoadListSubGroup(ID);
            if (groups.Count > 0)
            {
                servisContent.InnerHtml = "";
                foreach (Group gp in groups)
                {
                    var div = new HtmlGenericControl("div");
                    div.Attributes["class"] = "subGroup ";
                    div.InnerText = gp.Title;
                    servisContent.Controls.Add(div);
                    //ScriptManager1.RegisterAsyncPostBackControl(div);
                }
            }
            else
            {
                servisContent.InnerHtml = "<h3 style='float: right;'>برای این گروه زیر گروهی وجود ندارد</h3>";
            }
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
                            text += "<li><div class='col-sm-4 blog'><div class='row m0 blogInner'><div class='row m0 blogDateTime'><i class='fa fa-calendar'></i>" + article.PostDateTime + "</div><div class='row m0 featureImg'><a href = '" + "وبلاگ-ها/" + article.ArticleID + "' ><img src='" + setInlineImage(article.ArticleID) + "' alt='عکس' class='img-responsive'/></a></div><div class='row m0 postExcerpts'><div class='row m0 postExcerptInner'><a href = '" + "وبلاگ-ها/" + article.ArticleID + "' class='postTitle row m0'><h4>" + article.Title + "</h4></a><p></p>...<a href = '" + "وبلاگ-ها/" + article.ArticleID + "' class='readMore'>ادامه</a></div></div></div></div></li>";
                        }
                        else
                        {
                            text += "<li><div class='col-sm-4 blog'><div class='row m0 blogInner'><div class='row m0 blogDateTime'><i class='fa fa-calendar'></i>" + article.PostDateTime + "</div><div class='row m0 featureImg'><a href = '" + "وبلاگ-ها/" + article.ArticleID + "' ><img src='" + setInlineImage(article.ArticleID) + "' alt='عکس' class='img-responsive'/></a></div><div class='row m0 postExcerpts'><div class='row m0 postExcerptInner'><a href = '" + "وبلاگ-ها/" + article.ArticleID + "' class='postTitle row m0'><h4>" + article.Title + "</h4></a><p>" + article.Abstract.Substring(0, 130 - (article.Title.Count() - 30)) + "</p>...<a href = '" + "وبلاگ-ها/" + article.ArticleID + "' class='readMore'>ادامه</a></div></div></div></div></li>";
                        }
                    }
                    else
                    {
                        text += "<li><div class='col-sm-4 blog'><div class='row m0 blogInner'><div class='row m0 blogDateTime'><i class='fa fa-calendar'></i>" + article.PostDateTime + "</div><div class='row m0 featureImg'><a href = '" + "وبلاگ-ها/" + article.ArticleID + "' ><img src='" + setInlineImage(article.ArticleID) + "' alt='عکس' class='img-responsive'/></a></div><div class='row m0 postExcerpts'><div class='row m0 postExcerptInner'><a href = '" + "وبلاگ-ها/" + article.ArticleID + "' class='postTitle row m0'><h4>" + article.Title + "</h4></a><p>" + article.Abstract.Substring(0, 130) + "</p>...<a href = '" + "وبلاگ-ها/" + article.ArticleID + "' class='readMore'>ادامه</a></div></div></div></div></li>";
                    }
                }
                else
                {
                    text += "<li><div class='col-sm-4 blog'><div class='row m0 blogInner'><div class='row m0 blogDateTime'><i class='fa fa-calendar'></i>" + article.PostDateTime + "</div><div class='row m0 featureImg'><a href = '" + "وبلاگ-ها/" + article.ArticleID + "' ><img src='" + setInlineImage(article.ArticleID) + "' alt='عکس' class='img-responsive'/></a></div><div class='row m0 postExcerpts'><div class='row m0 postExcerptInner'><a href = '" + "وبلاگ-ها/" + article.ArticleID + "' class='postTitle row m0'><h4>" + article.Title + "</h4></a><p>" + article.Abstract + "</p>...<a href = '" + "وبلاگ-ها/" + article.ArticleID + "' class='readMore'>ادامه</a></div></div></div></div></li>";
                }
            }
            blogsContainer.InnerHtml = text;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            fillServises();
            if (!IsPostBack)
            {
                List<Article> articles = new List<Article>();
                ArticleRepository artRep = new ArticleRepository();
                articles = artRep.Top3tArticles();

                fillArticles(articles);
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

        //<div class="subGroup col-md-2 col-xs-4">گروه 1</div>
        protected void subGroups_ServerClick(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('نام کاربری یا رمز ورود اشتباه است ! ');window.location ='ورود'", true);
        }

        protected void articles_ServerClick(object sender, EventArgs e)
        {
        }
    }
}
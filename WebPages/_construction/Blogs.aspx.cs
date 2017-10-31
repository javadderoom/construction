﻿using Common;
using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages._construction
{
    public partial class Blogs : System.Web.UI.Page
    {
        private void fillUl(List<Article> artList)
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
            UlArticles.InnerHtml = text;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //load posts

                ArticleRepository ArtRep = new ArticleRepository();
                List<Article> Articles = ArtRep.AllArticles();
                fillUl(Articles);

                //load ddls
                ddlSubGroups.Enabled = false;

                GroupsRepository repo = new GroupsRepository();
                ddlGroups.DataSource = repo.LoadAllGroups();
                ddlGroups.DataTextField = "Title";
                ddlGroups.DataValueField = "GroupID";
                ddlGroups.DataBind();
                ddlGroups.Items.Insert(0, new ListItem("همه گروه ها", "-2"));

            }

        }

        protected void ddlGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGroups.SelectedValue != "-2")
            {
                GroupsRepository Groupsrepo = new GroupsRepository();
                DataTable DT = new DataTable();
                DT = Groupsrepo.LoadSubGroup(ddlGroups.SelectedValue.ToInt());

                if ((DT.Rows.Count > 0))
                {
                    ddlSubGroups.Enabled = true;

                    ddlSubGroups.DataSource = DT;
                    ddlSubGroups.DataTextField = "Title";
                    ddlSubGroups.DataValueField = "GroupID";
                    ddlSubGroups.DataBind();
                    ddlSubGroups.Items.Insert(0, new ListItem("همه زیر گروه ها", "-2"));

                }
                else
                {
                    ddlSubGroups.Enabled = false;
                    ddlSubGroups.Items.Clear();
                    ddlSubGroups.Items.Insert(0, new ListItem("گروه : " + ddlGroups.SelectedItem.ToString(), ddlGroups.SelectedValue.ToString()));

                }
                //load posts
                List<int> subgroupsid = Groupsrepo.getSubGroupsIDByFatherID(ddlGroups.SelectedValue.ToInt());
                ArticleRepository artrep = new ArticleRepository();
                List<Article> articles = artrep.ReturnArticlesByCategory(subgroupsid);
                if (articles.Count != 0)
                {
                    fillUl(articles);
                }
                else
                {
                    UlArticles.InnerHtml = " <li class='danger'>در این بخش مقاله ای وجود ندارد!</li> ";
                    ddlSubGroups.SelectedIndex = 0;
                    ddlSubGroups.Enabled = false;
                }
            }
            else
            {
                ArticleRepository ArtRep = new ArticleRepository();
                List<Article> Articles = ArtRep.AllArticles();
                fillUl(Articles);
                ddlSubGroups.SelectedIndex = 0;
                ddlSubGroups.Enabled = false;

            }



            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "run()", true);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "myFunction()", true);
        }

        protected void ddlSubGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSubGroups.SelectedValue != "-2")
            {
                ArticleRepository artrep = new ArticleRepository();
                List<Article> articles = artrep.ReturnArticlesByCategory(ddlSubGroups.SelectedValue.ToInt());
                if (articles.Count != 0)
                {
                    fillUl(articles);
                }
                else
                {
                    UlArticles.InnerHtml = " <li class='danger'>در این بخش مقاله ای وجود ندارد!</li> ";
                }
            }
            else
            {
                GroupsRepository Groupsrepo = new GroupsRepository();
                List<int> subgroupsid = Groupsrepo.getSubGroupsIDByFatherID(ddlGroups.SelectedValue.ToInt());
                ArticleRepository artrep = new ArticleRepository();
                List<Article> articles = artrep.ReturnArticlesByCategory(subgroupsid);
                if (articles.Count != 0)
                {
                    fillUl(articles);
                }
                else
                {
                    UlArticles.InnerHtml = " <li class='danger'>در این بخش مقاله ای وجود ندارد!</li> ";
                }
            }






            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "run()", true);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "myFunction()", true);
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
    }
}

﻿using DataAccess;
using DataAccess.Repository;
using System;
using Common;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace WebPages._construction
{
    public partial class BlogPost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = this.Page.RouteData.Values["id"].ToString();
                if (!String.IsNullOrEmpty(id))
                {
                    ///address
                    ContactUsRepository repo = new ContactUsRepository();
                    ContactWay cnw = repo.Findcwy(1);
                    BlogAddress.InnerText = cnw.Adrees;
                    BlogMail.InnerText = cnw.Email;
                    BlogPhone.InnerText = cnw.PhoneNumber;
                    /////////////
                    ArticleRepository ART = new ArticleRepository();
                    Article post = ART.FindeArticleByID(id.ToInt());
                    PageTitle.InnerText = post.Title;
                    //META
                    HtmlMeta meta2 = new HtmlMeta();
                    meta2.Name = "KeyWords";
                    meta2.Content = post.KeyWords.Replace('\n', ' ');
                    MetaPlaceHolder.Controls.Add(meta2);
                    HtmlMeta meta = new HtmlMeta();
                    meta.Name = "Description";
                    meta.Content = post.Abstract.Replace('\n', ' ');
                    MetaPlaceHolder.Controls.Add(meta);
                    //Article
                    if (post.Image != null)
                        ImageTag.Src = post.Image;
                    DivPostDate.InnerText = post.PostDateTime;
                    DivHeadTitle.InnerText = post.Title;
                    DivTitle.InnerText = post.Title;
                    DivBody.InnerHtml = post.Content;

                    string[] words = post.Tags.Split(',');
                    string text = "";
                    foreach (string word in words)
                    {
                        text += " <div class='badge badge-pill badge-warning myTag'>" + word + "</div>";
                    }
                    DivTags.InnerHtml = text;
                    //Recent
                    List<Article> ArticleList = ART.LatestArticles();
                    text = "";
                    foreach (Article article in ArticleList)
                    {
                        text += "<div class='media recentblog'><div class='media-left'><a href = '" + "/Blog/" + article.ArticleID + "/" + article.Title.Replace(' ', '-') + "'><img src='" + article.ImgFirstPage + "' runat='server'  alt='عکس' class='img - responsive'/></a></div><div class='media-body'><a href = '" + "/Blog/" + article.ArticleID + "/" + article.Title.Replace(' ', '-') + "'><h5 class='media-heading'>" + article.Title + "</h5></a></div></div>";
                    }

                    DivRecenPosts.InnerHtml = text;
                }
                else
                {
                    Response.Redirect("/Blogs");
                }


            }


        }

    }
}

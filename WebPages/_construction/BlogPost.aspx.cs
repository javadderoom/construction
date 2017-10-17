using DataAccess;
using DataAccess.Repository;
using System;
using Common;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;

namespace WebPages._construction
{
    public partial class BlogPost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["ID"];
                ArticleRepository ART = new ArticleRepository();
                Article post = ART.FindeArticleByID(id.ToInt());
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
                DivPostDate.InnerText = post.PostDateTime;
                DivHeadTitle.InnerText = post.Title;
                DivTitle.InnerText = post.Title;
                DivBody.InnerHtml = post.Content;
                ImageTag.Src = "../Images/1%20(%206)%20.jpg".Replace(" ", "%20");
                string[] words = post.Tags.Split(',');
                string text = "";
                foreach (string word in words)
                {
                    text += " <div class='badge badge-pill badge-warning myTag'>" + word + "</div>";
                }
                DivTags.InnerHtml = text + text + text + text + text;
                //Recent
                List<Article> ArticleList = ART.LatestArticles();
                text = "";
                foreach (Article article in ArticleList)
                {
                    text += "<div class='media recentblog'><div class='media-left'><a href = '#'><img class='media-object' src='" + "../Images/1%20(%206)%20.jpg" + "' alt=''/></a></div><div class='media-body'><a href = '#'><h5 class='media-heading'>" + article.Title + "</h5></a></div></div>";
                }

                DivRecenPosts.InnerHtml = text;

            }

        }
    }
}

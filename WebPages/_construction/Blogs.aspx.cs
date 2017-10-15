using System;

using DataAccess.Repository;
using DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages._construction
{
    public partial class Blogs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string text = "";
                ArticleRepository ArtRep = new ArticleRepository();
                List<Article> Articles = ArtRep.AllArticles();
                foreach (Article article in Articles)
                {
                    if (article.Abstract.Count() > 133)
                    {
                        text += "<li><div class='col-sm-4 blog'><div class='row m0 blogInner'><div class='row m0 blogDateTime'><i class='fa fa-calendar'></i>" + article.PostDateTime + "</div><div class='row m0 featureImg'><a href = '" + "http://localhost:6421/_construction/BlogPost.aspx?ID=" + article.ArticleID + "' ><img src='../Images/1%20(%206)%20.jpg' alt='Faceted Search Has Landed' class='img-responsive'/></a></div><div class='row m0 postExcerpts'><div class='row m0 postExcerptInner'><a href = '" + "http://localhost:6421/_construction/BlogPost.aspx?ID=" + article.ArticleID + "' class='postTitle row m0'><h4>" + article.Title + "</h4></a><p>" + article.Abstract.Substring(0, 130) + "</p>...<a href = '" + "http://localhost:6421/_construction/BlogPost.aspx?ID=" + article.ArticleID + "' class='readMore'>ادامه</a></div></div></div></div></li>";

                    }
                    else
                    {
                        text += "<li><div class='col-sm-4 blog'><div class='row m0 blogInner'><div class='row m0 blogDateTime'><i class='fa fa-calendar'></i>" + article.PostDateTime + "</div><div class='row m0 featureImg'><a href = '" + "http://localhost:6421/_construction/BlogPost.aspx?ID=" + article.ArticleID + "' ><img src='../Images/1%20(%206)%20.jpg' alt='Faceted Search Has Landed' class='img-responsive'/></a></div><div class='row m0 postExcerpts'><div class='row m0 postExcerptInner'><a href = '" + "http://localhost:6421/_construction/BlogPost.aspx?ID=" + article.ArticleID + "' class='postTitle row m0'><h4>" + article.Title + "</h4></a><p>" + article.Abstract + "</p>...<a href = '" + "http://localhost:6421/_construction/BlogPost.aspx?ID=" + article.ArticleID + "' class='readMore'>ادامه</a></div></div></div></div></li>";

                    }
                }
                UlArticles.InnerHtml = text + text + text + text + text + text + text + text + text + text + text + text + text + text + text + text;

            }

        }
    }
}
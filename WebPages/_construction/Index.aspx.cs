using DataAccess;
using DataAccess.Repository;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages._construction
{
    public partial class Index1 : System.Web.UI.Page
    {
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
                            text += "<li><div class='col-sm-4 blog'><div class='row m0 blogInner'><div class='row m0 blogDateTime'><i class='fa fa-calendar'></i>" + article.PostDateTime + "</div><div class='row m0 featureImg'><a href = '" + "http://localhost:6421/_construction/BlogPost.aspx?ID=" + article.ArticleID + "' ><img src='../Images/1%20(%206)%20.jpg' alt='Faceted Search Has Landed' class='img-responsive'/></a></div><div class='row m0 postExcerpts'><div class='row m0 postExcerptInner'><a href = '" + "http://localhost:6421/_construction/BlogPost.aspx?ID=" + article.ArticleID + "' class='postTitle row m0'><h4>" + article.Title + "</h4></a><p></p>...<a href = '" + "http://localhost:6421/_construction/BlogPost.aspx?ID=" + article.ArticleID + "' class='readMore'>ادامه</a></div></div></div></div></li>";
                        }
                        else
                        {
                            text += "<li><div class='col-sm-4 blog'><div class='row m0 blogInner'><div class='row m0 blogDateTime'><i class='fa fa-calendar'></i>" + article.PostDateTime + "</div><div class='row m0 featureImg'><a href = '" + "http://localhost:6421/_construction/BlogPost.aspx?ID=" + article.ArticleID + "' ><img src='../Images/1%20(%206)%20.jpg' alt='Faceted Search Has Landed' class='img-responsive'/></a></div><div class='row m0 postExcerpts'><div class='row m0 postExcerptInner'><a href = '" + "http://localhost:6421/_construction/BlogPost.aspx?ID=" + article.ArticleID + "' class='postTitle row m0'><h4>" + article.Title + "</h4></a><p>" + article.Abstract.Substring(0, 130 - (article.Title.Count() - 30)) + "</p>...<a href = '" + "http://localhost:6421/_construction/BlogPost.aspx?ID=" + article.ArticleID + "' class='readMore'>ادامه</a></div></div></div></div></li>";
                        }


                    }
                    else
                    {
                        text += "<li><div class='col-sm-4 blog'><div class='row m0 blogInner'><div class='row m0 blogDateTime'><i class='fa fa-calendar'></i>" + article.PostDateTime + "</div><div class='row m0 featureImg'><a href = '" + "http://localhost:6421/_construction/BlogPost.aspx?ID=" + article.ArticleID + "' ><img src='../Images/1%20(%206)%20.jpg' alt='Faceted Search Has Landed' class='img-responsive'/></a></div><div class='row m0 postExcerpts'><div class='row m0 postExcerptInner'><a href = '" + "http://localhost:6421/_construction/BlogPost.aspx?ID=" + article.ArticleID + "' class='postTitle row m0'><h4>" + article.Title + "</h4></a><p>" + article.Abstract.Substring(0, 130) + "</p>...<a href = '" + "http://localhost:6421/_construction/BlogPost.aspx?ID=" + article.ArticleID + "' class='readMore'>ادامه</a></div></div></div></div></li>";

                    }

                }
                else
                {
                    text += "<li><div class='col-sm-4 blog'><div class='row m0 blogInner'><div class='row m0 blogDateTime'><i class='fa fa-calendar'></i>" + article.PostDateTime + "</div><div class='row m0 featureImg'><a href = '" + "http://localhost:6421/_construction/BlogPost.aspx?ID=" + article.ArticleID + "' ><img src='../Images/1%20(%206)%20.jpg' alt='Faceted Search Has Landed' class='img-responsive'/></a></div><div class='row m0 postExcerpts'><div class='row m0 postExcerptInner'><a href = '" + "http://localhost:6421/_construction/BlogPost.aspx?ID=" + article.ArticleID + "' class='postTitle row m0'><h4>" + article.Title + "</h4></a><p>" + article.Abstract + "</p>...<a href = '" + "http://localhost:6421/_construction/BlogPost.aspx?ID=" + article.ArticleID + "' class='readMore'>ادامه</a></div></div></div></div></li>";

                }
            }
            blogsContainer.InnerHtml = text;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Article> articles = new List<Article>();
                ArticleRepository artRep = new ArticleRepository();
                articles = artRep.Top3tArticles();

                fillArticles(articles);

            }

        }
    }
}
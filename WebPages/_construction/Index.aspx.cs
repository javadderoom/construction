using DataAccess;
using DataAccess.Repository;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

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
            if (!IsPostBack)
            {
                List<Article> articles = new List<Article>();
                ArticleRepository artRep = new ArticleRepository();
                articles = artRep.Top3tArticles();

                fillArticles(articles);

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
    }
}
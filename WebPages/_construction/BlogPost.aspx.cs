using DataAccess;
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
                        setImage(ImageTag, id.ToInt());
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
                        text += "<div class='media recentblog'><div class='media-left'><a href = '" + "وبلاگ-ها" + article.ArticleID + "'><img src='" + setInlineImage(article.ArticleID) + "' runat='server'  alt='عکس' class='img - responsive'/></a></div><div class='media-body'><a href = '" + "وبلاگ-ها" + article.ArticleID + "'><h5 class='media-heading'>" + article.Title + "</h5></a></div></div>";
                    }

                    DivRecenPosts.InnerHtml = text;
                }


            }
            else
            {
                Response.Redirect("وبلاگ-ها");
            }

        }
        private void setImage(HtmlImage hi, int arid)
        {
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
                            hi.Src = "data:image/png;base64," + Convert.ToBase64String(fileData);
                        }

                        dr.Close();
                    }
                    cn.Close();



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
    }
}

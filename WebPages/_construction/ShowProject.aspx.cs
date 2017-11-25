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
    public partial class ShowProject : System.Web.UI.Page
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
                    //////////////
                    ProjectsRepository ART = new ProjectsRepository();
                    Project post = ART.FindeProjectByID(id.ToInt());
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
                    List<Project> ArticleList = ART.LatestProjects();
                    text = "";
                    foreach (Project article in ArticleList)
                    {
                        text += "<div class='media recentblog'><div class='media-left'><a href= '" + "/Projects/" + article.ProjectID + "/" + article.Title.Replace(' ', '-') + "'><img src='" + article.ImgFisrtPage + "' runat='server'  alt='عکس' class='img - responsive'/></a></div><div class='media-body'><a href= '" + "/Projects/" + article.ProjectID + "/" + article.Title.Replace(' ', '-') + "'><h5 class='media-heading'>" + article.Title + "</h5></a></div></div>";
                    }

                    DivRecenPosts.InnerHtml = text;
                }
                else
                {
                    Response.Redirect("/Projects");
                }
            }

        }




    }
}
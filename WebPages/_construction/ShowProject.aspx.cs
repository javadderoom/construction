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
                    ProjectsRepository ART = new ProjectsRepository();
                    Project post = ART.FindeProjectByID(id.ToInt());
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
                    List<Project> ArticleList = ART.LatestProjects();
                    text = "";
                    foreach (Project article in ArticleList)
                    {
                        text += "<div class='media recentblog'><div class='media-left'><a href = '" + "وبلاگ-ها" + article.ProjectID + "'><img src='" + setInlineImage(article.ProjectID) + "' runat='server'  alt='عکس' class='img - responsive'/></a></div><div class='media-body'><a href = '" + "وبلاگ-ها" + article.ProjectID + "'><h5 class='media-heading'>" + article.Title + "</h5></a></div></div>";
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
                using (SqlCommand cmd = new SqlCommand(string.Format("select Image from Projects where ProjectID = {0}", arid), cn))
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
    }
}
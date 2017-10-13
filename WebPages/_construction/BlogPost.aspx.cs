using DataAccess;
using DataAccess.Repository;
using System;
namespace WebPages._construction
{
    public partial class BlogPost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticleRepository ART = new ArticleRepository();
                Article post = ART.FindeArticleByID(1);
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
            }

        }
    }
}

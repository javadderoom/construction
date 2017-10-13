using System.Data.Entity;
namespace DataAccess.Repository
{
    public class ArticleRepository
    {
        private ConstructionCompanyEntities DB = new ConstructionCompanyEntities();
        public bool SaveArticle(Article article)
        {
            try
            {
                if (article.UserID > 0)
                {
                    //==== UPDATE ====
                    DB.Articles.Attach(article);
                    DB.Entry(article).State = EntityState.Modified;
                }
                else
                {
                    //==== INSERT ====
                    DB.Articles.Add(article);
                }

                DB.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }


        }
    }
}

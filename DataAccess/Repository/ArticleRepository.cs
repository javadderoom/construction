using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
namespace DataAccess.Repository
{
    public class ArticleRepository
    {
        private ConstructionCompanyEntities DB = new ConstructionCompanyEntities();
        public bool SaveArticle(Article article)
        {
            try
            {
                if (article.ArticleID > 0)
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
        public int GetLastArticleID()
        {


            int result = 0;

            result = (from r in DB.Articles
                      orderby r.ArticleID descending
                      select r.ArticleID).FirstOrDefault();

            return result;

        }
        public Article FindeArticleByID(int id)
        {
            return DB.Articles.Where(p => p.ArticleID == id).FirstOrDefault();
        }

        public List<Article> LatestArticles()
        {
            List<Article> list = (from r in DB.Articles
                                  orderby r.ArticleID descending
                                  select r).Take(5).ToList();
            return list;
        }
        public List<Article> AllArticles()
        {
            List<Article> list = (from r in DB.Articles
                                  orderby r.ArticleID descending
                                  select r).ToList();
            return list;
        }

    }
}

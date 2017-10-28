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
        public List<Article> Top3tArticles()
        {
            List<Article> list = (from r in DB.Articles
                                  orderby r.ArticleID descending
                                  select r).Take(3).ToList();
            return list;
        }
        public List<Article> AllArticles()
        {
            List<Article> list = (from r in DB.Articles
                                  orderby r.ArticleID descending
                                  select r).ToList();
            return list;
        }
        public List<Article> ReturnArticlesByCategory(List<int> IDes)
        {
            List<Article> list = new List<Article>();
            List<int> artides = new List<int>();
            foreach (int Id in IDes)
            {
                List<int?> temp = new List<int?>();
                temp.Clear();
                temp = (from r in DB.GroupConnections
                        where r.GroupID == Id
                        select r.ArticleID).ToList();
                foreach (int artid in temp)
                {
                    if (!artides.Contains(artid))
                    {
                        artides.Add(artid);
                    }
                }

            }
            foreach (int id in artides)
            {
                list.Add(FindeArticleByID(id));
            }

            return list;
        }
        public List<Article> ReturnArticlesByCategory(int Subgruopid)
        {
            List<Article> list = new List<Article>();
            List<int> artides = new List<int>();

            List<int?> temp = new List<int?>();

            temp = (from r in DB.GroupConnections
                    where r.GroupID == Subgruopid
                    select r.ArticleID).ToList();
            foreach (int id in temp)
            {
                list.Add(FindeArticleByID(id));
            }


            return list;
        }
        public bool DeletArticleByID(int id)
        {
            bool ans = true;
            try
            {
                Article selectedArt = new Article();
                selectedArt = DB.Articles.Where(p => p.ArticleID == id).Single();

                if (selectedArt != null)
                {
                    DB.Articles.Remove(selectedArt);
                    DB.SaveChanges();
                }
                else { ans = false; }

            }
            catch (System.Exception)
            {

                ans = false;
            }





            return ans;
        }
    }

}

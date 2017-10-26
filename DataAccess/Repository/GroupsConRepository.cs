using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Repository
{
    public class GroupsConRepository
    {
        private ConstructionCompanyEntities DB = new ConstructionCompanyEntities();
        public bool SaveGroupCon(GroupConnection GC)
        {
            try
            {
                if (GC.ConectionID > 0)
                {
                    //==== UPDATE ====
                    DB.GroupConnections.Attach(GC);
                    DB.Entry(GC).State = EntityState.Modified;
                }
                else
                {
                    //==== INSERT ====
                    DB.GroupConnections.Add(GC);
                }

                DB.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }


        }
        public GroupConnection findConByID(int id)
        {
            return DB.GroupConnections.Where(p => p.ConectionID == id).FirstOrDefault();
        }
        public bool DeletArticleConnections(int artid)
        {
            bool ans = true;
            try
            {

                List<int> gpid = new List<int>();
                gpid = (from r in DB.GroupConnections
                        where r.ArticleID == artid
                        select r.ConectionID).ToList();
                if (gpid.Count != 0)
                {
                    foreach (int id in gpid)
                    {

                        DB.GroupConnections.Remove(findConByID(id));


                    }
                    DB.SaveChanges();
                }
                else
                {
                    ans = false;
                }


            }
            catch (System.Exception e)
            {
                string text = e.Message;

                ans = false;
            }
            return ans;
        }
        public bool DeleteConsBySubGroupIdList(List<int> list)
        {
            bool ans = false;
            try
            {

                foreach (int ID in list)
                {

                    GroupConnection gpcon = (from r in DB.GroupConnections
                                             where r.GroupID == ID
                                             select r).FirstOrDefault();
                    if (gpcon != null)
                    {
                        DB.GroupConnections.Remove(gpcon);

                        gpcon = null;
                    }
                }

                DB.SaveChanges();
                ans = true;
            }
            catch (System.Exception)
            {

                ans = false;
            }
            return ans;
        }

    }
}

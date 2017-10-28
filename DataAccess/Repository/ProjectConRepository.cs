using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProjectConRepository
    {
        private ConstructionCompanyEntities DB = new ConstructionCompanyEntities();
        public bool SaveProjectCon(ProjectConnection GC)
        {
            try
            {
                if (GC.ConnectionID > 0)
                {
                    //==== UPDATE ====
                    DB.ProjectConnections.Attach(GC);
                    DB.Entry(GC).State = EntityState.Modified;
                }
                else
                {
                    //==== INSERT ====
                    DB.ProjectConnections.Add(GC);
                }

                DB.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }


        }
        public ProjectConnection findConByID(int id)
        {
            return DB.ProjectConnections.Where(p => p.ConnectionID == id).FirstOrDefault();
        }
        public bool DeletProjectConnections(int artid)
        {
            bool ans = true;
            try
            {

                List<int> gpid = new List<int>();
                gpid = (from r in DB.ProjectConnections
                        where r.ProjectID == artid
                        select r.ConnectionID).ToList();
                if (gpid.Count != 0)
                {
                    foreach (int id in gpid)
                    {

                        DB.ProjectConnections.Remove(findConByID(id));


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

                    ProjectConnection gpcon = (from r in DB.ProjectConnections
                                               where r.GroupID == ID
                                               select r).FirstOrDefault();
                    if (gpcon != null)
                    {
                        DB.ProjectConnections.Remove(gpcon);

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

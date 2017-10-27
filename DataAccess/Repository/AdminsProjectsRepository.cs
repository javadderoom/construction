using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class AdminsProjectsRepository
    {
        private ConstructionCompanyEntities DB = new ConstructionCompanyEntities();
        public bool SaveProject(AdminsProject Project)
        {
            try
            {
                if (Project.ProjectID > 0)
                {
                    //==== UPDATE ====
                    DB.AdminsProjects.Attach(Project);
                    DB.Entry(Project).State = EntityState.Modified;
                }
                else
                {
                    //==== INSERT ====
                    DB.AdminsProjects.Add(Project);
                }

                DB.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }


        }
        public int GetLastProjectID()
        {


            int result = 0;

            result = (from r in DB.AdminsProjects
                      orderby r.ProjectID descending
                      select r.ProjectID).FirstOrDefault();

            return result;

        }
        public AdminsProject FindeProjectByID(int id)
        {
            return DB.AdminsProjects.Where(p => p.ProjectID == id).FirstOrDefault();
        }
        public List<AdminsProject> LatestProjects()
        {
            List<AdminsProject> list = (from r in DB.AdminsProjects
                                        orderby r.ProjectID descending
                                        select r).Take(5).ToList();
            return list;
        }
        public List<AdminsProject> Top3tProjects()
        {
            List<AdminsProject> list = (from r in DB.AdminsProjects
                                        orderby r.ProjectID descending
                                        select r).Take(3).ToList();
            return list;
        }
        public List<AdminsProject> AllProjects()
        {
            List<AdminsProject> list = (from r in DB.AdminsProjects
                                        orderby r.ProjectID descending
                                        select r).ToList();
            return list;
        }
        public List<AdminsProject> ReturnProjectsByCategory(List<int> IDes)
        {
            List<AdminsProject> list = new List<AdminsProject>();
            List<int> artides = new List<int>();
            foreach (int Id in IDes)
            {
                List<int?> temp = new List<int?>();
                temp.Clear();
                temp = (from r in DB.ProjectConnections
                        where r.GroupID == Id
                        select r.ProjectID).ToList();
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
                list.Add(FindeProjectByID(id));
            }

            return list;
        }
        public List<AdminsProject> ReturnProjectsByCategory(int Subgruopid)
        {
            List<AdminsProject> list = new List<AdminsProject>();
            List<int> artides = new List<int>();

            List<int?> temp = new List<int?>();

            temp = (from r in DB.ProjectConnections
                    where r.GroupID == Subgruopid
                    select r.ProjectID).ToList();
            foreach (int id in temp)
            {
                list.Add(FindeProjectByID(id));
            }


            return list;
        }
        public bool DeletProjectByID(int id)
        {
            bool ans = true;
            try
            {
                AdminsProject selectedArt = new AdminsProject();
                selectedArt = DB.AdminsProjects.Where(p => p.ProjectID == id).Single();

                if (selectedArt != null)
                {
                    DB.AdminsProjects.Remove(selectedArt);
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

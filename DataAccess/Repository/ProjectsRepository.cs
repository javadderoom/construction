using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataAccess.Repository
{
    public class ProjectsRepository
    {
        private ConstructionCompanyEntities DB = new ConstructionCompanyEntities();
        public bool SaveProject(Project Project)
        {
            try
            {
                if (Project.ProjectID > 0)
                {
                    //==== UPDATE ====
                    DB.Projects.Attach(Project);
                    DB.Entry(Project).State = EntityState.Modified;
                }
                else
                {
                    //==== INSERT ====
                    DB.Projects.Add(Project);
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

            result = (from r in DB.Projects
                      orderby r.ProjectID descending
                      select r.ProjectID).FirstOrDefault();

            return result;

        }
        public Project FindeProjectByID(int id)
        {
            return DB.Projects.Where(p => p.ProjectID == id).FirstOrDefault();
        }
        public List<Project> LatestProjects()
        {
            List<Project> list = (from r in DB.Projects
                                  orderby r.ProjectID descending
                                  select r).Take(5).ToList();
            return list;
        }
        public List<Project> Top6tProjects()
        {
            List<Project> list = (from r in DB.Projects
                                  orderby r.ProjectID descending
                                  select r).Take(6).ToList();
            return list;
        }
        public List<Project> AllProjects()
        {
            List<Project> list = (from r in DB.Projects
                                  orderby r.ProjectID descending
                                  select r).ToList();
            return list;
        }
        public List<Project> ReturnProjectsByCategory(List<int> IDes)
        {
            List<Project> list = new List<Project>();
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
        public List<Project> ReturnProjectsByCategory(int Subgruopid)
        {
            List<Project> list = new List<Project>();
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

                Project selectedArt = DB.Projects.Where(p => p.ProjectID == id).FirstOrDefault();


                if (selectedArt != null)
                {
                    DB.Projects.Remove(selectedArt);
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

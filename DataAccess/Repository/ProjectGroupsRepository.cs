using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProjectGroupsRepository
    {
        private Connection conn;

        public ProjectGroupsRepository()
        {
            conn = new Connection();
        }

        private ConstructionCompanyEntities DB = new ConstructionCompanyEntities();

        public DataTable LoadAllGroups()
        {
            return OnlineTools.ToDataTable(DB.ProjectGroups.Where(p => p.FatherID == -1).ToList());
        }

        public List<ProjectGroup> LoadListAllGroups()
        {
            return DB.ProjectGroups.Where(p => p.FatherID == -1).ToList();
        }

        public DataTable LoadSubGroup(int fatherID)
        {
            return OnlineTools.ToDataTable(DB.ProjectGroups.Where(p => p.FatherID == fatherID).ToList());
        }

        public List<ProjectGroup> LoadListSubGroup(int fatherID)
        {
            return DB.ProjectGroups.Where(p => p.FatherID == fatherID).ToList();
        }

        public List<int> getSubGroupsIDByFatherID(int FatherId)
        {
            List<int> result = (from r in DB.ProjectGroups
                                where r.FatherID == FatherId
                                select r.GroupID).ToList();
            if (result.Count != 0)
            {
                return result;
            }
            else
            {
                result.Add(FatherId);
                return result;
            }
        }

        public List<string> getListOfTitlesOfGroups()
        {
            List<string> result = new List<string>();
            ConstructionCompanyEntities pb = conn.GetContext();

            IEnumerable<string> pl =
                (from r in pb.ProjectGroups
                 where r.GroupID == -1
                 select r.Title);

            result = pl.ToList();

            return result;
        }



        public DataTable LoadAllSubGroups()
        {
            return OnlineTools.ToDataTable((from r in DB.ProjectGroups
                                            where r.FatherID != -1
                                            select r
                           ).ToList());
        }
        public ProjectGroup FindGroup(int id)
        {
            return DB.ProjectGroups.Where(p => p.GroupID == id).FirstOrDefault();
        }
        public bool Savegp(ProjectGroup group)
        {
            try
            {
                if (group.GroupID > 0)
                {
                    //==== UPDATE ====
                    DB.ProjectGroups.Attach(group);
                    DB.Entry(group).State = EntityState.Modified;
                }
                else
                {
                    //==== INSERT ====
                    DB.ProjectGroups.Add(group);
                }

                DB.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }


        }
        public bool DelGruop(int id)
        {
            bool ans = false;
            try
            {
                DB.ProjectGroups.Remove(DB.ProjectGroups.Where(p => p.GroupID == id).FirstOrDefault());
                DB.SaveChanges();
                ans = true;

            }
            catch (System.Exception e)
            {
                string t = e.Message;
                ans = false;
            }
            return ans;
        }
        public bool DelSubGruop(int id)
        {
            bool ans = false;
            try
            {
                DB.ProjectGroups.Remove(DB.ProjectGroups.Where(p => p.GroupID == id && p.FatherID != -1).FirstOrDefault());
                ans = true;
                DB.SaveChanges();
            }
            catch (System.Exception)
            {

                ans = false;
            }
            return ans;
        }
        public bool DelSubGruop(List<int> ids)
        {
            bool ans = false;
            try
            {
                foreach (int id in ids)
                {
                    ProjectGroup temp = null;
                    temp = DB.ProjectGroups.Where(p => p.GroupID == id && p.FatherID != -1).FirstOrDefault();
                    if (temp != null)
                    {
                        DB.ProjectGroups.Remove(temp);

                        DB.SaveChanges();
                    }
                }

                ans = true;

            }
            catch (System.Exception e)
            {

                string t = e.Message;
                ans = false;
            }
            return ans;
        }
    }
}
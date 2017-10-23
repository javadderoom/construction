using Common;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.UI.WebControls;

namespace DataAccess.Repository
{
    public class GroupsRepository
    {
        private ConstructionCompanyEntities DB = new ConstructionCompanyEntities();
        public DataTable LoadAllGroups()
        {
            return OnlineTools.ToDataTable(DB.Groups.Where(p => p.FatherID == -1).ToList());
        }
        public DataTable LoadSubGroup(int fatherID)
        {
            return OnlineTools.ToDataTable(DB.Groups.Where(p => p.FatherID == fatherID).ToList());
        }
        public List<int> getSubGroupsIDByFatherID(int FatherId)
        {
            List<int> result = (from r in DB.Groups
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
        public DataTable FindTitelesOfaArticle(int artID)
        {
            List<Group> ans = new List<Group>();

            List<int?> conIDes = (from r in DB.GroupConnections
                                  where r.ArticleID == artID
                                  select r.GroupID).ToList();
            foreach (int groupId in conIDes)
            {
                Group temp = null;
                temp = (from r in DB.Groups
                        where r.GroupID == groupId
                        select r).FirstOrDefault();
                if (temp != null)
                {
                    ans.Add(temp);



                }
            }




            return OnlineTools.ToDataTable(ans);
        }
        public DataTable LoadAllSubGroups()
        {
            return OnlineTools.ToDataTable((from r in DB.Groups
                                            where r.FatherID != -1
                                            select r
                           ).ToList());
        }
        public Group FindGroup(int id)
        {
            return DB.Groups.Where(p => p.GroupID == id).FirstOrDefault();
        }
        public bool Savegp(Group group)
        {
            try
            {
                if (group.GroupID > 0)
                {
                    //==== UPDATE ====
                    DB.Groups.Attach(group);
                    DB.Entry(group).State = EntityState.Modified;
                }
                else
                {
                    //==== INSERT ====
                    DB.Groups.Add(group);
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
                DB.Groups.Remove(DB.Groups.Where(p => p.GroupID == id).FirstOrDefault());
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
                DB.Groups.Remove(DB.Groups.Where(p => p.GroupID == id && p.FatherID != -1).FirstOrDefault());
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
                    Group temp = null;
                    temp = DB.Groups.Where(p => p.GroupID == id && p.FatherID != -1).FirstOrDefault();
                    if (temp != null)
                    {
                        DB.Groups.Remove(temp);

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

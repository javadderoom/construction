using Common;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace DataAccess.Repository
{
    public class GroupsRepository
    {
        private Connection conn;

        public GroupsRepository()
        {
            conn = new Connection();
        }

        private ConstructionCompanyEntities DB = new ConstructionCompanyEntities();

        public DataTable LoadAllGroups()
        {
            return OnlineTools.ToDataTable(DB.Groups.Where(p => p.FatherID == -1).ToList());
        }

        public List<Group> LoadListAllGroups()
        {
            return DB.Groups.Where(p => p.FatherID == -1).ToList();
        }

        public DataTable LoadSubGroup(int fatherID)
        {
            return OnlineTools.ToDataTable(DB.Groups.Where(p => p.FatherID == fatherID).ToList());
        }

        public List<Group> LoadListSubGroup(int fatherID)
        {
            return DB.Groups.Where(p => p.FatherID == fatherID).ToList();
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

        public List<string> getListOfTitlesOfGroups()
        {
            List<string> result = new List<string>();
            ConstructionCompanyEntities pb = conn.GetContext();

            IEnumerable<string> pl =
                (from r in pb.Groups
                 where r.GroupID == -1
                 select r.Title);

            result = pl.ToList();

            return result;
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
    }
}
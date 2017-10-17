using Common;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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
    }
}

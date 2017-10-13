using Common;
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

    }
}

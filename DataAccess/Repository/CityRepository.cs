using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CityRepository
    {
        private ConstructionCompanyEntities database;

        public CityRepository()
        {
            database = new ConstructionCompanyEntities();
        }

        public DataTable getCitiesInfoByStateID(int sid)
        {
            var query =
                from r in database.Cities
                where r.StateID == sid
                select new { r.CityID, r.CityName };

            return OnlineTools.ToDataTable(query.ToList());
        }
    }
}

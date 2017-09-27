using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class StatesRepository
    {
        private ConstructionCompanyEntities database;

        public StatesRepository()
        {
            database = new ConstructionCompanyEntities();
        }

        public DataTable getStatesInfo()
        {
            var query =
                from r in database.States
                select new { r.StateID, r.StateName };

            return OnlineTools.ToDataTable(query.ToList());
        }
    }
}

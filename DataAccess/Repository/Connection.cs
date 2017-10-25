using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    internal class Connection
    {
        public ConstructionCompanyEntities GetContext()
        {
            ConstructionCompanyEntities wt = new ConstructionCompanyEntities();
            return wt;
        }
    }
}
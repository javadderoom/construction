using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data;
using System.Web.Configuration;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;

namespace DataAccess.Repository
{
    public class AdminsRepository
    {
        private ConstructionCompanyEntities database;

        public AdminsRepository()
        {
            database = new ConstructionCompanyEntities();
        }

        public int getAdminIDByUsername_Password(string username, string password)
        {
            int query =
                (from r in database.Admins
                 where r.UserName == username && r.Password == password
                 select r.AdminID).FirstOrDefault();

            return query;
        }

    }
}
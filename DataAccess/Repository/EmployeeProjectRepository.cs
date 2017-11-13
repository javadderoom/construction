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
    public class EmployeeProjectRepository
    {
        private ConstructionCompanyEntities database;

        public EmployeeProjectRepository()
        {
            database = new ConstructionCompanyEntities();
        }

        public void SaveEmployeeProject(EmployeeProject ep)
        {
            if (ep.EmployeeProjectID > 0)
            {
                //==== UPDATE ====
                database.EmployeeProjects.Attach(ep);
                database.Entry(ep).State = EntityState.Modified;
            }
            else
            {
                //==== INSERT ====
                database.EmployeeProjects.Add(ep);
            }

            database.SaveChanges();
        }

        public int getEmployeeProjectCount(int id)
        {
            int result = 0;
            result = (

                from r in database.EmployeeProjects
                where r.EmployeeID == id
                select r).Count();

            return result;
        }

        public void deleteByProjectID(int pid)
        {
            SqlConnection conn = new SqlConnection(OnlineTools.conString);
            conn.Open();
            string sql2 = string.Format("delete from EmployeeProjects where projectid = {0}", pid);
            SqlCommand myCommand2 = new SqlCommand(sql2, conn);
            myCommand2.ExecuteNonQuery();
            conn.Close();
        }
    }
}
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

namespace DataAccess.Repository
{
    public class EmployeesRepository
    {
        private ConstructionCompanyEntities database;

        public EmployeesRepository()
        {
            database = new ConstructionCompanyEntities();
        }

        public int getEmployeeIDByUsername_Password(string username, string password)
        {
            int query =
                (from r in database.Employees
                 where r.UserName == username && r.Password == password
                 select r.EmployeeID).FirstOrDefault();

            return query;
        }

        public void SaveEmployees(Employee kramand)
        {

            if (kramand.EmployeeID > 0)
            {
                //==== UPDATE ====
                database.Employees.Attach(kramand);
                database.Entry(kramand).State = EntityState.Modified;
            }
            else
            {
                //==== INSERT ====
                database.Employees.Add(kramand);
            }

            database.SaveChanges();

        }



        public void DeleteEmployee(int EID)
        {

            Employee selectedEmployee = database.Employees.Where(p => p.EmployeeID == EID).Single();

            if (selectedEmployee != null)
            {
                database.Employees.Remove(selectedEmployee);
                database.SaveChanges();
            }
        }



        public void DeleteAll()
        {

            System.Configuration.ConnectionStringSettingsCollection connectionStrings =
                WebConfigurationManager.ConnectionStrings as ConnectionStringSettingsCollection;

            if (connectionStrings.Count > 0)
            {
                System.Data.Linq.DataContext db = new System.Data.Linq.DataContext(connectionStrings["ConnectionString"].ConnectionString);

                db.ExecuteCommand("TRUNCATE TABLE Employees");
            }

        }
    }
}
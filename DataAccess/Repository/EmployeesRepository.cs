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
        public int getLastEmployeeID()
        {
            int query =
               (from r in database.Employees
                orderby r.EmployeeID descending
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
        public void setEmployeeImage(int empid, byte[] cnts)
        {
            Employee e =
                  (
                      from r in database.Employees
                      where r.EmployeeID == empid
                      select r
                  ).FirstOrDefault();

            e.empImage = cnts;
            database.SaveChanges();

        }
        public void setEmployeeResume(int empid, byte[] cnts)
        {
            Employee e =
                  (
                      from r in database.Employees
                      where r.EmployeeID == empid
                      select r
                  ).FirstOrDefault();

            e.CV = cnts;
            database.SaveChanges();

        }

        public bool isThereUsername(string uname)
        {
            int cnt =
                (from r in database.Employees where r.UserName == uname select r).Count();

            if (cnt == 0) return false;
            return true;
        }
        public DataTable getEmployeeProfileInfo(int id)
        {
            string Command = string.Format("select *,FirstName+' '+LastName as fullName,StateName+' - '+CityName as addr from Employees left outer join States on Employees.State = States.StateID left outer join Cities on Employees.City = Cities.CityID where EmployeeID = {0}", id);
            SqlConnection myConnection = new SqlConnection(OnlineTools.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
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
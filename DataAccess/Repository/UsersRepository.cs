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
    public class UsersRepository
    {
        private ConstructionCompanyEntities database;

        public UsersRepository()
        {
            database = new ConstructionCompanyEntities();
        }

        public int getUserIDByUsername_Password(string username, string password)
        {
            int query =
                (from r in database.Users
                 where r.UserName == username && r.Password == password
                 select r.UserID).FirstOrDefault();

            return query;
        }
        public int getLastUserID()
        {
            int query =
               (from r in database.Users
                orderby r.UserID descending
                select r.UserID).FirstOrDefault();
            return query;
        }
        public void SaveUsers(User user)
        {

            if (user.UserID > 0)
            {
                //==== UPDATE ====
                database.Users.Attach(user);
                database.Entry(user).State = EntityState.Modified;
            }
            else
            {
                //==== INSERT ====
                database.Users.Add(user);
            }

            database.SaveChanges();

        }



        public void DeleteUser(int ID)
        {

            User selectedUser = database.Users.Where(p => p.UserID == ID).Single();

            if (selectedUser != null)
            {
                database.Users.Remove(selectedUser);
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

                db.ExecuteCommand("TRUNCATE TABLE Users");
            }

        }

        public DataTable getUserProfileInfo(int id)
        {
            string Command = string.Format("select *,FirstName+' '+LastName as fullName,StateName+' - '+CityName as addr from Users left outer join States on Users.State = States.StateID left outer join Cities on Users.City = Cities.CityID where UserID = {0}", id);
            SqlConnection myConnection = new SqlConnection(OnlineTools.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
        }
    }
}
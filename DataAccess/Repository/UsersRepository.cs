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

        public void setNewPassForUser(int userid, string pass)
        {
            SqlConnection conn = new SqlConnection(OnlineTools.conString);
            conn.Open();
            string sql2 = string.Format("update Users set users.Password=N'{1}' where UserID={0}", userid, pass);
            SqlCommand myCommand2 = new SqlCommand(sql2, conn);
            myCommand2.ExecuteNonQuery();
            conn.Close();
        }

        public bool isThereUsername(string value)
        {
            int cnt =
                (from r in database.Users where r.UserName == value select r).Count();

            if (cnt == 0) return false;
            return true;
        }

        public string getUserPass(int userid)
        {
            string pass =
                (
                    from r in database.Users
                    where r.UserID == userid
                    select r.Password
                ).FirstOrDefault();
            return pass;
        }

        public void setNewMobileForUser(int userid, string mobile)
        {

            SqlConnection conn = new SqlConnection(OnlineTools.conString);
            conn.Open();
            string sql2 = string.Format("update Users set users.Mobile=N'{1}' where UserID={0}", userid, mobile);
            SqlCommand myCommand2 = new SqlCommand(sql2, conn);
            myCommand2.ExecuteNonQuery();
            conn.Close();
        }

        public DataTable getAllUsersAndEmployeesForMessage()
        {
            string Command = string.Format("select users.UserName,Users.UserID,CityName +' - '+StateName as FullAddress,FirstName+' ' +LastName as FullName,N'مشتری' as urole,RegSeen,Mobile from Users left outer join Cities on Users.City = Cities.CityID left outer join States on Users.State = States.StateID union select Employees.UserName,Employees.EmployeeID,CityName +' - '+StateName as FullAddress,FirstName+' ' +LastName as FullName,N'کارمند' as urole,RegSeen,Mobile from Employees left outer join Cities on Employees.City = Cities.CityID left outer join States on Employees.State = States.StateID");
            SqlConnection myConnection = new SqlConnection(OnlineTools.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
        }

        public DataTable SearchFor_getAllUsersAndEmployeesForMessage(string txt)
        {
            string Command = string.Format("select * from(select users.UserName,Users.UserID,CityName +' - '+StateName as FullAddress,FirstName+' ' +LastName as FullName,N'مشتری' as urole from Users left outer join Cities on Users.City = Cities.CityID left outer join States on Users.State = States.StateID union select Employees.UserName,Employees.EmployeeID,CityName +' - '+StateName as FullAddress,FirstName+' ' +LastName as FullName,N'کارمند' as urole from Employees left outer join Cities on Employees.City = Cities.CityID left outer join States on Employees.State = States.StateID)tbl where UserName like N'%{0}%' or UserID like N'%{0}%' or FullAddress like N'%{0}%' or FullName like N'%{0}%' or urole like N'%{0}%'", txt);
            SqlConnection myConnection = new SqlConnection(OnlineTools.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
        }
        public void setRegSeenToTrue()
        {
            SqlConnection conn = new SqlConnection(OnlineTools.conString);
            conn.Open();
            string sql2 = string.Format("update Users set RegSeen = 1");
            SqlCommand myCommand2 = new SqlCommand(sql2, conn);
            myCommand2.ExecuteNonQuery();
            conn.Close();
        }
        public DataTable searchUserUnionEmployee(string txt)
        {
            string Command = string.Format("select * from( select users.UserName,Users.UserID,CityName +' - '+StateName as FullAddress,FirstName+' ' +LastName as FullName,N'مشتری' as urole,RegSeen,Mobile from Users left outer join Cities on Users.City = Cities.CityID left outer join States on Users.State = States.StateID union select Employees.UserName,Employees.EmployeeID,CityName +' - '+StateName as FullAddress,FirstName+' ' +LastName as FullName,N'کارمند' as urole,RegSeen,Mobile from Employees left outer join Cities on Employees.City = Cities.CityID left outer join States on Employees.State = States.StateID)tbl where UserName like N'%{0}%' or UserID like N'%{0}%' or FullAddress like N'%{0}%' or FullName like N'%{0}%' or urole like N'%{0}%' or Mobile like N'%{0}%' order by UserID desc", txt);
            SqlConnection myConnection = new SqlConnection(OnlineTools.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
        }
    }
}
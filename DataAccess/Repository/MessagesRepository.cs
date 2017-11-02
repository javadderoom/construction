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
    public class MessageRepository
    {
        private ConstructionCompanyEntities DB = new ConstructionCompanyEntities();
        private ConstructionCompanyEntities database;
        public string AdminNewMessageCount()
        {
            return DB.Messages.Where(p => (p.SenderTable != "adm" && p.hasSeen == true)).ToList().Count().ToString();


        }
        public string CountUserNewMessages(int id)
        {
            int count = 0;
            List<int> chatIdList = (from r in DB.Chats
                                    where r.User_Employee_ID == id
                                    select r.ChatID).ToList();
            foreach (int chatid in chatIdList)
            {
                bool? hasSeen = (from r in DB.Messages
                                 where r.SenderTable == "adm" && r.ChatID == chatid
                                 select r.hasSeen).FirstOrDefault();
                if (hasSeen == true)
                {
                    count++;

                }
            }

            return count.ToString();
        }
        public MessageRepository()
        {
            database = new ConstructionCompanyEntities();
        }
        public void setMessagesSeenToTrue(int chatid, string tbl)
        {
            SqlConnection conn = new SqlConnection(OnlineTools.conString);
            conn.Open();
            string sql2 = string.Format("update Messages set hasSeen = 0 where ChatID = {0} and SenderTable = '{1}'", chatid, tbl);
            SqlCommand myCommand2 = new SqlCommand(sql2, conn);
            myCommand2.ExecuteNonQuery();
            conn.Close();

        }
        public DataTable Search_adminInbox(string txt, int adminid)
        {

            string Command = string.Format("select*,case when((lastMsgSenderTbl<> 'adm') and(lastMsgSeen = 1)) then 1 else 0 end as seen from(select*,(select top 1 MessageText from Messages where ChatID = Chats.ChatID order by MessageID desc) as lastMsg, (select top 1 MessageDate+' - ' + MessageTime from Messages where ChatID = Chats.ChatID order by MessageID desc) as lastMsgTime, (select top 1 hasSeen from Messages where ChatID = Chats.ChatID order by MessageID desc) as lastMsgSeen, (select top 1 SenderTable from Messages where ChatID = Chats.ChatID order by MessageID desc) as lastMsgSenderTbl from Chats left outer join(select* from(select users.UserName, Users.UserID, CityName +' - '+StateName as FullAddress, FirstName+' ' +LastName as FullName, N'مشری' as urole from Users left outer join Cities on Users.City = Cities.CityID left outer join States on Users.State = States.StateID union select Employees.UserName, Employees.EmployeeID, CityName +' - '+StateName as FullAddress, FirstName+' ' +LastName as FullName, N'کارمند' as urole from Employees left outer join Cities on Employees.City = Cities.CityID left outer join States on Employees.State = States.StateID)tbl)tbl1 on Chats.User_Employee_ID = tbl1.UserID where AdminID = {1})tbl where ChatID like N'%{0}%' or ChatTitle like N'%{0}%' or UserName like N'%{0}%' or FullName like N'%{0}%' or lastMsg like N'%{0}%' or lastMsgTime like N'%{0}%' order by lastMsgTime desc ", txt, adminid);
            SqlConnection myConnection = new SqlConnection(OnlineTools.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;

        }

        public void setMessagesSeenToTrueForAdmin(int chatid)
        {
            SqlConnection conn = new SqlConnection(OnlineTools.conString);
            conn.Open();
            string sql2 = string.Format("update Messages set hasSeen = 0 where ChatID = {0} and (SenderTable ='emp' or SenderTable = 'use') ", chatid);
            SqlCommand myCommand2 = new SqlCommand(sql2, conn);
            myCommand2.ExecuteNonQuery();
            conn.Close();

        }
        public DataTable getMessages(int chatid)
        {
            string Command = string.Format("select *,MessageDate +' - ' +MessageTime as fullTime from Messages where ChatID = {0} order by MessageID desc", chatid);
            SqlConnection myConnection = new SqlConnection(OnlineTools.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
        }
        public int getChatMessgesCount(int chatid)
        {
            int query =
                (
                    from r in database.Messages
                    where r.ChatID == chatid
                    select r
                ).Count();

            return query;
        }

        public DataTable getMessagesInfoOfEmployee(int chatid)
        {
            string Command = string.Format("select Chats.*,UserName	,(select top 1 MessageDate+' - ' + MessageTime from Messages where ChatID = Chats.ChatID order by MessageID asc) as firstMsgDate from Chats left outer join Employees on Chats.User_Employee_ID = Employees.EmployeeID where ChatID = {0}", chatid);
            SqlConnection myConnection = new SqlConnection(OnlineTools.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
        }

        public DataTable getMessagesInfoOfUsers(int chatid)
        {
            string Command = string.Format("select Chats.*,UserName	,(select top 1 MessageDate+' - ' + MessageTime from Messages where ChatID = Chats.ChatID order by MessageID asc) as firstMsgDate from Chats left outer join Users on Chats.User_Employee_ID = Users.UserID where ChatID = {0}", chatid);
            SqlConnection myConnection = new SqlConnection(OnlineTools.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
        }


        public void SaveMessages(Message m)
        {

            if (m.MessageID > 0)
            {
                //==== UPDATE ====
                database.Messages.Attach(m);
                database.Entry(m).State = EntityState.Modified;
            }
            else
            {
                //==== INSERT ====
                database.Messages.Add(m);
            }

            database.SaveChanges();

        }






        public void DeleteAll()
        {

            System.Configuration.ConnectionStringSettingsCollection connectionStrings =
                WebConfigurationManager.ConnectionStrings as ConnectionStringSettingsCollection;

            if (connectionStrings.Count > 0)
            {
                System.Data.Linq.DataContext db = new System.Data.Linq.DataContext(connectionStrings["ConnectionString"].ConnectionString);

                db.ExecuteCommand("TRUNCATE TABLE Chats");
            }

        }
    }
}
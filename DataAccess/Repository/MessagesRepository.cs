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
        private ConstructionCompanyEntities database;

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

        public DataTable getMessagesInfo(int chatid)
        {
            string Command = string.Format("select Chats.*,UserName	,(select top 1 MessageDate+' - ' + MessageTime from Messages where ChatID = Chats.ChatID order by MessageID asc) as firstMsgDate from Chats left outer join Employees on Chats.User_Employee_ID = Employees.EmployeeID where ChatID = {0}", chatid);
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
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
    public class ChatsRepository
    {
        private ConstructionCompanyEntities database;

        public ChatsRepository()
        {
            database = new ConstructionCompanyEntities();
        }


        public int getLastChatID()
        {
            int query =
               (from r in database.Chats
                orderby r.ChatID descending
                select r.ChatID).FirstOrDefault();
            return query;
        }
        public void SaveChats(Chat c)
        {

            if (c.ChatID > 0)
            {
                //==== UPDATE ====
                database.Chats.Attach(c);
                database.Entry(c).State = EntityState.Modified;
            }
            else
            {
                //==== INSERT ====
                database.Chats.Add(c);
            }

            database.SaveChanges();

        }

        public DataTable Inbox(int id)
        {
            string Command = string.Format(" select* ,CASE WHEN(lastMsgTbl = 'use') THEN  0 WHEN(lastMsgTbl = 'adm' and lastMsgSeen = 0) THEN 1 END AS seen from(select*,(select top 1 substring(MessageText,0,30) from Messages where ChatID = Chats.ChatID order by MessageID desc) as lastMsgText,(select top 1 MessageDate+' - ' + MessageTime from Messages where ChatID = Chats.ChatID order by MessageID desc) as lastMsgDate,(select top 1 SenderTable from Messages where ChatID = Chats.ChatID order by MessageID desc) as lastMsgTbl,(select top 1 hasSeen from Messages where ChatID = Chats.ChatID order by MessageID desc) as lastMsgSeen from Chats where User_Employee_ID = {0})tbl order by ChatID desc", id);
            SqlConnection myConnection = new SqlConnection(OnlineTools.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
        }
        public DataTable Search(int id, string txt)
        {
            string Command = string.Format(" select* ,CASE WHEN(lastMsgTbl = 'use') THEN  0 WHEN(lastMsgTbl = 'adm' and lastMsgSeen = 0) THEN 1 END AS seen from(select*,(select top 1 substring(MessageText,0,30) from Messages where ChatID = Chats.ChatID order by MessageID desc) as lastMsgText,(select top 1 MessageDate+' - ' + MessageTime from Messages where ChatID = Chats.ChatID order by MessageID desc) as lastMsgDate,(select top 1 SenderTable from Messages where ChatID = Chats.ChatID order by MessageID desc) as lastMsgTbl,(select top 1 hasSeen from Messages where ChatID = Chats.ChatID order by MessageID desc) as lastMsgSeen from Chats where User_Employee_ID = {0})tbl where ChatID like N'%{1}%' or ChatTitle like N'%{1}%' or lastMsgText like N'%{1}%' or lastMsgDate like N'%{1}%' order by ChatID desc", id, txt);
            SqlConnection myConnection = new SqlConnection(OnlineTools.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
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
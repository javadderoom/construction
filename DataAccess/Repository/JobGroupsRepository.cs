using Common;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System;

namespace DataAccess.Repository
{
    public class JobGroupsRepository
    {
        private ConstructionCompanyEntities DB = new ConstructionCompanyEntities();

        public DataTable getJobGroups()
        {
            string Command = string.Format("select * from jobGroups");
            SqlConnection myConnection = new SqlConnection(OnlineTools.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
        }

        public bool Savegp(JobGroup group)
        {
            try
            {
                if (group.JobGroupID > 0)
                {
                    //==== UPDATE ====
                    DB.JobGroups.Attach(group);
                    DB.Entry(group).State = EntityState.Modified;
                }
                else
                {
                    //==== INSERT ====
                    DB.JobGroups.Add(group);
                }

                DB.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool JobGroup(int id)
        {
            bool ans = false;
            try
            {
                DB.JobGroups.Remove(DB.JobGroups.Where(p => p.JobGroupID == id).FirstOrDefault());
                DB.SaveChanges();
                ans = true;
            }
            catch (System.Exception e)
            {
                string t = e.Message;
                ans = false;
            }
            return ans;
        }

        public bool DelJobGruop(int id)
        {
            bool ans = false;
            try
            {
                DB.JobGroups.Remove(DB.JobGroups.Where(p => p.JobGroupID == id).FirstOrDefault());
                DB.SaveChanges();
                ans = true;
            }
            catch (System.Exception e)
            {
                string t = e.Message;
                ans = false;
            }
            return ans;
        }
    }
}
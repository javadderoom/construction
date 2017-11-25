using Common;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System;

namespace DataAccess.Repository
{
    public class JobRepository
    {
        private ConstructionCompanyEntities DB = new ConstructionCompanyEntities();

        public Job findJob(int id)
        {
            Job job = (
                from r in DB.Jobs
                where r.JobID == id
                select r
                ).FirstOrDefault();
            return job;
        }

        public DataTable getJobsByGroupID(int id)
        {
            string Command = string.Format("select * from jobs where JobGroupID = {0}", id);
            SqlConnection myConnection = new SqlConnection(OnlineTools.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
        }

        public DataTable getAllJobsByGroupID()
        {
            string Command = string.Format("select * from jobs");
            SqlConnection myConnection = new SqlConnection(OnlineTools.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
        }

        public List<int> getListOfJobIDs(int id)
        {
            List<int> result = new List<int>();

            IQueryable<int> re = (
                from r in DB.Jobs
                where r.JobGroupID == id
                select r.JobID

                );
            result = re.ToList();
            return result;
        }

        public bool Savegp(Job group)
        {
            try
            {
                if (group.JobID > 0)
                {
                    //==== UPDATE ====
                    DB.Jobs.Attach(group);
                    DB.Entry(group).State = EntityState.Modified;
                }
                else
                {
                    //==== INSERT ====
                    DB.Jobs.Add(group);
                }

                DB.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool DelJob(int id)
        {
            bool ans = false;
            try
            {
                DB.Jobs.Remove(DB.Jobs.Where(p => p.JobID == id).FirstOrDefault());
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

        public bool DelJobs(int id)
        {
            bool ans = false;
            try
            {
                IQueryable<int> re = (
                    from r in DB.Jobs
                    where r.JobGroupID == id
                    select r.JobID

                    );
                foreach (int j in re)
                {
                    DB.Jobs.Remove(DB.Jobs.Where(p => p.JobID == j).FirstOrDefault());
                }
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
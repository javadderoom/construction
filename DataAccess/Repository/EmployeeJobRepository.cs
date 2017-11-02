using Common;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess.Repository
{
    public class EmployeeJobRepository
    {
        private ConstructionCompanyEntities DB = new ConstructionCompanyEntities();

        public void SaveJobEmployee(JobEmployee je)
        {
            if (je.JobEmployeeID > 0)
            {
                //==== UPDATE ====
                DB.JobEmployees.Attach(je);
                DB.Entry(je).State = EntityState.Modified;
            }
            else
            {
                //==== INSERT ====
                DB.JobEmployees.Add(je);
            }

            DB.SaveChanges();
        }

        public void DeleteByEmpid_Jobid(int empid, int jobid)
        {
            SqlConnection conn = new SqlConnection(OnlineTools.conString);
            conn.Open();
            string sql = string.Format("delete from JobEmployee where EmployeeID = {0} and JobID = {1}", empid, jobid);
            SqlCommand myCommand = new SqlCommand(sql, conn);
            myCommand.ExecuteNonQuery();
            conn.Close();
        }

        public DataTable getEmployeeJobs(int empid)
        {
            string Command = string.Format("select * from JobEmployee left outer join Jobs on JobEmployee.JobID = Jobs.JobID where EmployeeID = {0}", empid);
            SqlConnection myConnection = new SqlConnection(OnlineTools.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
        }

        public DataTable findEmployeeByJob(int id)
        {
            string Command = string.Format("select * from JobEmployee left outer join Jobs on JobEmployee.JobID = Jobs.JobID where Jobs.JobID = {0}", id);
            SqlConnection myConnection = new SqlConnection(OnlineTools.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
        }
    }
}
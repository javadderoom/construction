using Common;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
namespace DataAccess.Repository
{
    public class JobRepository
    {
        private ConstructionCompanyEntities DB = new ConstructionCompanyEntities();

        public DataTable getJobsByGroupID(int id)
        {
            string Command = string.Format("select * from jobs where JobGroupID = {0}", id);
            SqlConnection myConnection = new SqlConnection(OnlineTools.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
        }
    }

}

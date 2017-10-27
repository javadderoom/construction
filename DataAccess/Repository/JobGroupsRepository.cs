using Common;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
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
    }

}

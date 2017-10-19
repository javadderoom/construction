using Common;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
namespace DataAccess.Repository
{
    public class OrderRepository
    {
        private ConstructionCompanyEntities DB = new ConstructionCompanyEntities();
        public bool SaveOrder(Order o)
        {
            try
            {
                if (o.OrderID > 0)
                {
                    //==== UPDATE ====
                    DB.Orders.Attach(o);
                    DB.Entry(o).State = EntityState.Modified;
                }
                else
                {
                    //==== INSERT ====
                    DB.Orders.Add(o);
                }

                DB.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }


        }
        public DataTable getOrderByID(int oid)
        {
            string Command = string.Format("select o.*,CityName,StateName,FirstName+' '+LastName as fullName ,Mobile,Email from Orders o left outer join Users u on o.UserID = u.UserID left outer join States s on o.State = s.StateID left outer join Cities c on o.City = c.CityID where OrderID = {0}", oid);
            SqlConnection myConnection = new SqlConnection(OnlineTools.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
        }

        public DataTable getAllOrders()
        {
            string Command = string.Format("select o.*,CityName,StateName,FirstName+' '+LastName as fullName ,Mobile,Email,CityName+' - ' +StateName as FullAdd from Orders o left outer join Users u on o.UserID = u.UserID left outer join States s on o.State = s.StateID left outer join Cities c on o.City = c.CityID");
            SqlConnection myConnection = new SqlConnection(OnlineTools.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
        }

    }

}

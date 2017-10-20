using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
    }
}
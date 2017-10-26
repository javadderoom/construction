using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ContactUsRepository
    {
        ConstructionCompanyEntities DB = new ConstructionCompanyEntities();
        public ContactWay Findcwy(int id)
        {
            return DB.ContactWays.Where(p => p.ID == id).FirstOrDefault();
        }
        public bool Savecwy(ContactWay CWy)
        {
            try
            {
                if (CWy.ID > 0)
                {
                    //==== UPDATE ====
                    DB.ContactWays.Attach(CWy);
                    DB.Entry(CWy).State = EntityState.Modified;
                }
                else
                {
                    //==== INSERT ====
                    DB.ContactWays.Add(CWy);
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

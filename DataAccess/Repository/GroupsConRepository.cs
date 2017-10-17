using System.Data.Entity;

namespace DataAccess.Repository
{
    public class GroupsConRepository
    {
        private ConstructionCompanyEntities DB = new ConstructionCompanyEntities();
        public bool SaveGroupCon(GroupConnection GC)
        {
            try
            {
                if (GC.ConectionID > 0)
                {
                    //==== UPDATE ====
                    DB.GroupConnections.Attach(GC);
                    DB.Entry(GC).State = EntityState.Modified;
                }
                else
                {
                    //==== INSERT ====
                    DB.GroupConnections.Add(GC);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Common;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class SliderRepository
    {
        private ConstructionCompanyEntities DB = new ConstructionCompanyEntities();
        public bool SaveSlider(Slider slider)
        {
            try
            {
                if (slider.SlideID > 0)
                {
                    //==== UPDATE ====

                    DB.Sliders.Attach(slider);
                    DB.Entry(slider).State = EntityState.Modified;
                }
                else
                {
                    //==== INSERT ====
                    DB.Sliders.Add(slider);
                }

                DB.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }


        }
        public DataTable LoadSliders()
        {
            return OnlineTools.ToDataTable((from r in DB.Sliders
                                            select r).ToList());
        }
        public Slider FindSlider(int id)
        {
            return DB.Sliders.Where(p => p.SlideID == id).FirstOrDefault();
        }

    }
}

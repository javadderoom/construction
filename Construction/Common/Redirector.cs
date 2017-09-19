using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
    public class Redirector
    {
        public enum PageName
        {
            DefaultPage, CityInfoManager, ShowCityData
        };

        public static void Goto(PageName pageName)
        {
            switch (pageName)
            {
                case PageName.DefaultPage:
                    { HttpContext.Current.Response.Redirect("~/Default"); break; }

                case PageName.CityInfoManager:
                    { HttpContext.Current.Response.Redirect("~/CityInfoManager"); break; }

                case PageName.ShowCityData:
                    { HttpContext.Current.Response.Redirect("~/ShowCity"); break; }

            }
        }

        public static void Goto(string path)
        {
            HttpContext.Current.Response.Redirect(path);
        }
    }
}

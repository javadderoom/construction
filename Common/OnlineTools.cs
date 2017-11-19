using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Web.UI.WebControls;

namespace Common
{
    public class OnlineTools
    {
        static public string conString = "data source=185.159.152.16;initial catalog=jabeabza_DB;user id=jabeabza_javad;password=2210226104H.m;";

        public static void ShowMessage(Label lbl, string msg, Color col)
        {
            lbl.Text = msg;
            lbl.ForeColor = col;
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public static string persianFormatedDate()
        {
            int pday, pmonth, pyear;
            DateTime dt = DateTime.Now;
            PersianCalendar PC = new PersianCalendar();

            ///////////////////////////////////////
            pyear = PC.GetYear(dt);
            pmonth = PC.GetMonth(dt);
            pday = PC.GetDayOfMonth(dt);
            string translatedMonth = "";
            switch (pmonth)
            {
                case 1:
                    translatedMonth = "فروردین";
                    break;

                case 2:
                    translatedMonth = "اردیبهشت";
                    break;

                case 3:
                    translatedMonth = "خرداد";
                    break;

                case 4:
                    translatedMonth = "تیر";
                    break;

                case 5:
                    translatedMonth = "مرداد";
                    break;

                case 6:
                    translatedMonth = "شهریور";
                    break;

                case 7:
                    translatedMonth = "مهر";
                    break;

                case 8:
                    translatedMonth = "آبان";
                    break;

                case 9:
                    translatedMonth = "آذر";
                    break;

                case 10:
                    translatedMonth = "دی";
                    break;

                case 11:
                    translatedMonth = "بهمن";
                    break;

                case 12:
                    translatedMonth = "اسفند";
                    break;
            }

            string PTime = dt.Second + " : " + dt.Minute + " : " + dt.Hour + " , " + pday.ToString() + " / " + translatedMonth + " / " + pyear.ToString();

            return PTime;
        }
    }
}
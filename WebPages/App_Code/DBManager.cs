using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using PersianCalander;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;

/// <summary>
/// Database Administration Class
/// </summary>

public class DBManager
{
    static private string _cstr;

    /// <summary>
    /// تبديل اعداد لاتين به اعداد فارسي
    /// </summary>
    /// <param name="numStr"></param>
    /// <returns></returns>
    static public string FarsiNum(string numStr)
    {
        string trim = numStr.Trim();
        char[] temp = new char[trim.Length];

        int i = 0;

        foreach (char c in trim)
        {
            if (char.IsDigit(c))
            {
                temp[i] = ((char)(Convert.ToInt32(c) + 1728));
            }
            else
            {
                temp[i] = c;
            }

            i++;
        }

        string persianNumber = "";
        foreach (char c in temp)
        {
            persianNumber += c.ToString();
        }

        return persianNumber;
    }

    static public string LatinNum(string numStr)
    {
        string trim = numStr.Trim();
        char[] temp = new char[trim.Length];

        int i = 0;

        foreach (char c in trim)
        {
            if (char.IsDigit(c))
            {
                temp[i] = ((char)(Convert.ToInt32(c) - 1728));
            }
            else
            {
                temp[i] = c;
            }

            i++;
        }

        string persianNumber = "";
        foreach (char c in temp)
        {
            persianNumber += c.ToString();
        }

        return persianNumber;
    }

    static public void FarsiNumGrid(GridView gv)
    {
        foreach (GridViewRow gvr in gv.Rows)
        {
            foreach (TableCell tc in gvr.Cells)
            {
                if (tc.Text.Length > 0)
                {
                    tc.Text = DBManager.FarsiNum(tc.Text);
                }
            }
        }
    }

    static public void LatinNumGrid(GridView gv)
    {
        foreach (GridViewRow gvr in gv.Rows)
        {
            foreach (TableCell tc in gvr.Cells)
            {
                if (tc.Text.Length > 0)
                {
                    tc.Text = DBManager.LatinNum(tc.Text);
                }
            }
        }
    }

    static public bool CheckNumStr(string num)
    {
        bool ret = true;
        char[] numCharSet = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        foreach (char ch in num)
        {
            if (!((ch == '0') || (ch == '1') || (ch == '2') || (ch == '3') || (ch == '4') ||
                 (ch == '5') || (ch == '6') || (ch == '7') || (ch == '8') || (ch == '9')))
            {
                ret = false;
                break;
            }
        }

        return ret;
    }

    static public string GeneratePassword(int passwordLength)
    {
        string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
        char[] chars = new char[passwordLength];
        Random rd = new Random();

        for (int i = 0; i < passwordLength; i++)
        {
            chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
        }

        return new string(chars);
    }

    public DBManager()
    {
        _cstr = @"Data Source=.;Initial Catalog=WebDB;Integrated Security=True;";
    }

    public string GetConnectionStr()
    {
        return _cstr;
    }

    static public void ShowMessage(Control ctrl, string msg)
    {
        ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), "ALERT", "alert('" + msg + "');", true);
    }
    //======================================================================

    static public void ShowMessage(string msg, Label lbl, Color color)
    {
        lbl.Text = msg;
        lbl.ForeColor = color;
    }

    static public bool IsNum(string numStr)
    {
        bool retValue = true;
        int n = 0;

        for (int i = 0; i < numStr.Length; i++)
        {
            try
            {
                n = Int32.Parse(numStr[i].ToString());
            }
            catch
            {
                retValue = false;
            }
        }

        return retValue;
    }

    static public string GenerateRahgiriCode()
    {
        string retValue = "";
        string[] randomChars = { "N", "A", "Z", "E", "M", "S", "Y", "D", "R", "B" };

        Random s = new Random();
        retValue = s.Next(0, 10).ToString();

        retValue = string.Format("{0}{1}{2}{3}{4}{5}{6}",
                                randomChars[s.Next(0, 10)],
                                DateTime.Now.Millisecond,
                                randomChars[s.Next(0, 10)],
                                DateTime.Now.Second,
                                randomChars[s.Next(0, 10)],
                                DateTime.Now.Minute,
                                randomChars[s.Next(0, 10)]);
        return retValue;
    }

    //======================================================================

    static public void ExportToExcel(string selectStr, string fileName)
    {
        HttpResponse response = HttpContext.Current.Response;

        response.Clear();
        response.Charset = "";

        response.ContentType = "application/vnd.ms-excel";
        response.AddHeader("Content-Disposition", "attachment;filename=\"" + fileName + "\"");

        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                DataGrid dg = new DataGrid();
                DBManager dbm = new DBManager();
                DataSet dgSet = dbm.GetTableData(selectStr);
                dg.DataSource = dgSet;
                dg.DataBind();
                dg.RenderControl(htw);
                response.Write(sw.ToString());
                response.End();
            }
        }
    }

    static public void ExportToWord(string selectStr, string fileName)
    {
        HttpResponse response = HttpContext.Current.Response;

        response.Clear();
        response.Charset = "";

        response.ContentType = "application/msword";
        response.AddHeader("Content-Disposition", "attachment;filename=\"" + fileName + "\"");

        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                DataGrid dg = new DataGrid();
                DBManager dbm = new DBManager();
                DataSet dgSet = dbm.GetTableData(selectStr);
                dg.DataSource = dgSet;
                dg.DataBind();
                dg.RenderControl(htw);
                response.Write(sw.ToString());
                response.End();
            }
        }
    }

    //======================================================================

    static public string AddFirstZero(int num)
    {
        string retValue = num.ToString();

        if (num < 10)
        {
            retValue = "0" + retValue;
        }

        return retValue;
    }

    static public string CurrentTime()
    {
        return AddFirstZero(DateTime.Now.Hour) + ":" + AddFirstZero(DateTime.Now.Minute);
    }

    static public string CurrentTimeWithoutColons()
    {
        return AddFirstZero(DateTime.Now.Hour) + AddFirstZero(DateTime.Now.Minute);
    }

    static public int CurrentPersianYear()
    {
        FarsiLibrary.Utils.PersianDate pd = FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(DateTime.Now.ToString());
        return pd.Year;
    }

    static public int CurrentPersianMonth()
    {
        FarsiLibrary.Utils.PersianDate pd = FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(DateTime.Now.ToString());
        return pd.Month;
    }

    static public int CurrentPersianDay()
    {
        FarsiLibrary.Utils.PersianDate pd = FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(DateTime.Now.ToString());
        return pd.Day;
    }

    static public string CurrentPersianDate()
    {
        FarsiLibrary.Utils.PersianDate pd = FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(DateTime.Now.ToString());

        string d, m;
        d = pd.Day.ToString();
        m = pd.Month.ToString();

        if (d.Length == 1)
        {
            d = "0" + d;
        }

        if (m.Length == 1)
        {
            m = "0" + m;
        }

        return pd.Year.ToString() + "/" + m + "/" + d;
    }

    static public string CurrentPersianDateWithoutSlash()
    {
        FarsiLibrary.Utils.PersianDate pd = FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(DateTime.Now.ToString());

        string d, m;
        d = pd.Day.ToString();
        m = pd.Month.ToString();

        if (d.Length == 1)
        {
            d = "0" + d;
        }

        if (m.Length == 1)
        {
            m = "0" + m;
        }

        return pd.Year.ToString() + m + d;
    }

    static public string CurrentPersianDateName()
    {
        FarsiLibrary.Utils.PersianDate pd = FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(DateTime.Now.ToString());
        return pd.LocalizedWeekDayName;
    }

    static public string[] PersianDateNames()
    {
        string[] daylist = { "", "", "", "", "", "", "" };
        FarsiLibrary.Utils.PersianDate pd;
        for (int n = 0; n < 7; n++)
        {
            pd = FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(DateTime.Now.AddDays(n).ToString());
            daylist[n] = pd.LocalizedWeekDayName;
        }

        return daylist;
    }

    static public string PersianDate(DateTime dt)
    {
        FarsiLibrary.Utils.PersianDate pd = FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(dt.ToString());

        string d, m;
        d = pd.Day.ToString();
        m = pd.Month.ToString();

        if (d.Length == 1)
        {
            d = "0" + d;
        }

        if (m.Length == 1)
        {
            m = "0" + m;
        }

        return pd.Year.ToString() + "/" + m + "/" + d;
    }

    static public string DateWithSlash(string dt)
    {
        string retValue = dt;
        retValue = dt.Substring(0, 4) + '/' + dt.Substring(4, 2) + '/' + dt.Substring(6, 2);
        return retValue;
    }

    //static public string FullPersianDateName()
    //{
    //    FarsiLibrary.Utils.PersianDate pd = FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(DateTime.Now.ToString());
    //    return Resources.Farsi.Today + " " +
    //           pd.LocalizedWeekDayName + " " +
    //           pd.Day.ToString() + " " +
    //           pd.LocalizedMonthName + " " +
    //           pd.Year.ToString();
    //}

    public struct PDate
    {
        public int year, month, day;

        public PDate(int y, int m, int d)
        {
            year = y;
            month = m;
            day = d;
        }
    }

    static int DayNo(PDate pd)
    {
        int retValue = 0;

        int n = 0;
        if (pd.month < 7)
        {
            n = (pd.month - 1) * 31 + pd.day;
        }
        else
        {
            n = 186 + (((pd.month - 7) * 30) + pd.day);
        }
        retValue = n;

        return retValue;
    }

    static public int PersianDiffDates(string date1, string date2)
    {
        int retValue = 0;
        int intDate1 = Int32.Parse(date1);
        int intDate2 = Int32.Parse(date2);
        int swap;

        PDate pd1;
        PDate pd2;
        pd1.year = Int32.Parse(date1.Substring(0, 4));
        pd1.month = Int32.Parse(date1.Substring(4, 2));
        pd1.day = Int32.Parse(date1.Substring(6, 2));
        pd2.year = Int32.Parse(date2.Substring(0, 4));
        pd2.month = Int32.Parse(date2.Substring(4, 2));
        pd2.day = Int32.Parse(date2.Substring(6, 2));

        if (intDate2 > intDate1)
        {
            swap = intDate1;
            intDate1 = intDate2;
            intDate2 = swap;
        }

        if (date1 == date2)
        {
            retValue = 0;
        }
        else
        {
            if (pd1.year == pd2.year)
            {
                retValue = DayNo(pd2) - DayNo(pd1);
            }
            else
            {
                retValue = (365 - DayNo(pd1)) + DayNo(pd2);
            }
        }

        return retValue;
    }

    static bool CheckFreeDay(string pdate)
    {
        bool retValue = false;

        string year, month, day;
        year = pdate.Substring(0, 4);
        month = pdate.Substring(5, 2);
        day = Int32.Parse(pdate.Substring(8, 2)).ToString();

        string monthName = "";
        switch (month)
        {
            case "01": { monthName = "Farvardin"; break; }
            case "02": { monthName = "Ordibehesht"; break; }
            case "03": { monthName = "Khordad"; break; }
            case "04": { monthName = "Tir"; break; }
            case "05": { monthName = "Mordad"; break; }
            case "06": { monthName = "Shahrivar"; break; }
            case "07": { monthName = "Mehr"; break; }
            case "08": { monthName = "Aban"; break; }
            case "09": { monthName = "Azar"; break; }
            case "10": { monthName = "Dey"; break; }
            case "11": { monthName = "Bahman"; break; }
            case "12": { monthName = "Esfand"; break; }
        }

        DBManager dbc = new DBManager();
        string FreeDaysList = dbc.GetTableValue("FreeDaysCalendar", "CalID", "1", monthName);
        string[] fdl = FreeDaysList.Split(',');
        foreach (string s in fdl)
        {
            if (s == day)
            {
                retValue = true;
            }
        }

        return retValue;
    }

    static public string FirstCommingDate(string dayName)
    {
        string retValue = "";

        //string[] dayList = { "شنبه", "یکشنبه", "دوشنبه", "ﺳﻪشنبه", "چهارشنبه", "پنجشنبه", "جمعه" };
        string[] dl = PersianDateNames();

        string nowDate = CurrentPersianDateName();

        #region datesIndex
        int i = 0;
        for (i = 0; i < 7; i++)
        {
            if (dl[i] == nowDate) { break; }
        }

        int j = 0;
        for (j = 0; j < 7; j++)
        {
            if (dl[j] == dayName) { break; }
        }
        #endregion

        #region datesDiff
        int diffDates = 0;
        if (i < j)
        {
            diffDates = j - i;
        }
        else if (i > j)
        {
            diffDates = (j - i) + 7;
        }
        else
        {
            diffDates = 0;
        }
        #endregion
        DateTime current = DateTime.Now;
        retValue = PersianDate(current.AddDays(diffDates));

        //retValue = CurrentPersianDateName();
        while (CheckFreeDay(retValue))
        {
            diffDates += 7;
            retValue = PersianDate(current.AddDays(diffDates));
        }

        return retValue;
    }
    //======================================================================

    public int Insert(string cmd)
    {
        int res = 0;

        SqlConnection scon = new SqlConnection(_cstr);
        scon.Open();

        SqlCommand scmd = new SqlCommand(cmd, scon);
        res = scmd.ExecuteNonQuery();

        scon.Close();
        return res;
    }

    public int Delete(string cmd)
    {
        int res = 0;

        SqlConnection scon = new SqlConnection(_cstr);
        scon.Open();

        SqlCommand scmd = new SqlCommand(cmd, scon);
        res = scmd.ExecuteNonQuery();

        scon.Close();
        return res;
    }

    public int Update(string cmd)
    {
        int res = 0;

        SqlConnection scon = new SqlConnection(_cstr);
        scon.Open();

        SqlCommand scmd = new SqlCommand(cmd, scon);
        res = scmd.ExecuteNonQuery();

        scon.Close();
        return res;
    }

    public int RunCommand(string cmd)
    {
        int res = 0;

        SqlConnection scon = new SqlConnection(_cstr);
        scon.Open();

        SqlCommand scmd = new SqlCommand(cmd, scon);
        res = scmd.ExecuteNonQuery();

        scon.Close();
        return res;
    }

    public string RunFunction(string cmd, string valueField)
    {
        string res = "";

        SqlConnection scon = new SqlConnection(_cstr);
        scon.Open();
        try
        {
            SqlCommand scmd = new SqlCommand(cmd, scon);
            SqlDataReader sdr = scmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                res = sdr[valueField].ToString();
            }
        }
        catch
        {
            res = "Error";
        }

        scon.Close();
        return res;
    }

    public bool CheckExistance(string tblName, string keyFieldName, string keyFieldValue)
    {
        bool retValue = false;

        SqlConnection scon = new SqlConnection(_cstr);
        scon.Open();

        string searchStr = String.Format("SELECT {0} FROM {1} WHERE {2} = N'{3}'",
                                            keyFieldName,
                                            tblName,
                                            keyFieldName,
                                            keyFieldValue);

        SqlCommand scmd = new SqlCommand(searchStr, scon);
        SqlDataReader sdr = scmd.ExecuteReader();

        if (sdr.HasRows)
        {
            retValue = true;
        }

        scon.Close();

        return retValue;
    }

    public string GetTableValue(string tblName, string keyFieldName, string keyFieldValue, string fieldName)
    {
        string retValue = "";

        SqlConnection scon = new SqlConnection(_cstr);
        scon.Open();

        string searchStr = String.Format("SELECT {0} FROM {1} WHERE {2} = N'{3}'",
                                         fieldName, tblName, keyFieldName, keyFieldValue);

        SqlCommand scmd = new SqlCommand(searchStr, scon);
        SqlDataReader sdr = scmd.ExecuteReader();

        if (sdr.HasRows)
        {
            sdr.Read();
            retValue = sdr[fieldName].ToString();
        }

        scon.Close();

        return retValue;
    }

    //GettabelValue("Users","Username", tbxUsn.Text, "Password");
    //======================================================================

    public DataSet GetTableData(string searchStr)
    {
        DataSet ds = new DataSet();

        SqlConnection scon = new SqlConnection(_cstr);
        scon.Open();

        SqlDataAdapter sda = new SqlDataAdapter(searchStr, scon);
        sda.Fill(ds);

        scon.Close();

        return ds;
    }

    //DBManager dbm = new DBManager();
    //DataSet ds = dbm.GetTableData("SELECT * FROM Users WHERE Age>10");
    //ds.Tables[0].Rows.Count
    //ds.Tables[0].Rows[1]["FName"].ToString()

    public int LoadDataInGrid(string selectStr, GridView gv)
    {
        DataSet gds = GetTableData(selectStr);
        gv.DataSource = gds;
        gv.DataBind();

        return gds.Tables[0].Rows.Count;
    }

    public void LoadDataInDDL(string selectStr, DropDownList ddl, string textField, string valueField)
    {
        ddl.Items.Clear();
        ddl.DataSource = GetTableData(selectStr);
        ddl.DataTextField = textField;
        ddl.DataValueField = valueField;
        ddl.DataBind();
    }

    public void LoadDataInList(string selectStr, ListBox lb, string textField, string valueField)
    {
        lb.Items.Clear();
        lb.DataSource = GetTableData(selectStr);
        lb.DataTextField = textField;
        lb.DataValueField = valueField;
        lb.DataBind();
    }
    //======================================================================

    public bool CheckExtension(string fpath, string[] extensions)
    {
        bool retValue = true;

        if ((fpath.Length == 0) || (extensions.Length == 0))
        {
            retValue = false;
        }
        else
        {
            string fpExt = Path.GetExtension(fpath).ToLower();
            bool check = false;
            foreach (string ext in extensions)
            {
                if (fpExt == ext.ToLower())
                {
                    check = true;
                    break;
                }
            }

            if (!check) { retValue = false; }
        }

        return retValue;
    }

}

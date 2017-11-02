using Common;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages.Panels.Admin
{
    public partial class EmployeeInfo : System.Web.UI.Page
    {
        int empid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminid"] != null)
            {
                if (Session["useridForAdminDetails"] != null)
                {
                    empid = Session["useridForAdminDetails"].ToString().ToInt();
                    if (!IsPostBack)
                    {
                        setLabels();
                    }
                }
                else
                {
                    Response.Redirect("/Admin/ManageUsers");
                }
            }
            else
            {
                Response.Redirect("/AdminLogin");
            }


        }

        private void setLabels()
        {
            EmployeesRepository er = new EmployeesRepository();
            DataTable dt = er.getEmployeeProfileInfo(empid);
            lbladdress.Value = dt.Rows[0][8].ToString();
            lblcitystate.Value = dt.Rows[0][20].ToString();
            lblemail.Value = dt.Rows[0][10].ToString();
            lblfullname.Value = dt.Rows[0][19].ToString();
            lblid.Value = dt.Rows[0][0].ToString();
            lblmobile.Value = dt.Rows[0][9].ToString();
            lblusername.Value = dt.Rows[0][3].ToString();
            lblzip.Value = dt.Rows[0][9].ToString();

            EmployeeJobRepository ejr = new EmployeeJobRepository();
            DataTable dtJob = ejr.getEmployeeJobs(empid);
            lbxJobs.DataSource = dtJob;
            lbxJobs.DataTextField = "JobTitle";
            lbxJobs.DataValueField = "JobID";
            lbxJobs.DataBind();

            setImage();
        }
        public int download(int idname)
        {
            string ToSaveFileTo = KnownFolders.GetPath(KnownFolder.Downloads) + "\\" + DBManager.CurrentPersianDateWithoutSlash() + DBManager.CurrentTimeWithoutColons() + "file.zip";// Server.MapPath("~\\File\\file.zip");

            using (SqlConnection cn = new SqlConnection(OnlineTools.conString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(string.Format("select CV from Employees where EmployeeID = {0}", idname), cn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                    {
                        if (dr.Read())
                        {
                            if (dr.GetValue(0) == DBNull.Value)
                                return 0;
                            byte[] fileData = (byte[])dr.GetValue(0);
                            using (System.IO.FileStream fs = new System.IO.FileStream(ToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                            {
                                using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                                {
                                    bw.Write(fileData);
                                    bw.Close();
                                }
                            }
                        }

                        dr.Close();
                    }
                    cn.Close();
                    //Response.Redirect(ToSaveFileTo);
                    return 1;
                }
            }
        }

        protected void btnDownLoadResume_Click(object sender, EventArgs e)
        {
            int res = download(empid);
            if (res == 0)
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('کاربر رزومه ای ارسال نکرده است!');", true);
        }
        private void setImage()
        {
            using (SqlConnection cn = new SqlConnection(OnlineTools.conString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(string.Format("select empImage from Employees where EmployeeID = {0}", empid), cn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                    {
                        if (dr.Read())
                        {
                            if (dr.GetValue(0) != DBNull.Value)
                            {
                                byte[] fileData = (byte[])dr.GetValue(0);
                                Image1.Src = "data:image/png;base64," + Convert.ToBase64String(fileData);
                            }

                        }

                        dr.Close();
                    }
                    cn.Close();
                }
            }
        }
    }
}
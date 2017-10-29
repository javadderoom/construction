using Common;
using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages.Panels.EmployeePanel
{
    public partial class profile : System.Web.UI.Page
    {
        private int empid = 0;

        //DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("employeeid", 2);
            empid = Session["employeeid"].ToString().ToInt();
            if (!IsPostBack)
            {
                setLabels();
                fillDDL();
                // UpdatePanel1.Update();
            }
        }

        private void setLabels()
        {
            EmployeesRepository er = new EmployeesRepository();
            DataTable dt = er.getEmployeeProfileInfo(empid);

            lblfirstName.Value = dt.Rows[0][1].ToString();
            lblLastName.Value = dt.Rows[0][2].ToString();
            hFullName.InnerText = dt.Rows[0][19].ToString();
            lblid.Value = dt.Rows[0][0].ToString();
            lbladdress.Value = dt.Rows[0][8].ToString();

            lblemail.Value = dt.Rows[0][10].ToString();
            ddlState.SelectedIndex = (dt.Rows[0][6].ToString().ToInt() - 1);

            string asd = dt.Rows[0][7].ToString();
            ddlCity.SelectedValue = asd;
            lblmobile.Value = dt.Rows[0][9].ToString();
            lblusername.Value = dt.Rows[0][3].ToString();
            lblpassword.Value = dt.Rows[0][4].ToString();
            lblzip.Value = dt.Rows[0][11].ToString();

            if (dt.Rows[0][12] != DBNull.Value)
                setImage();
        }

        public void fillDDL()
        {
            StatesRepository r = new StatesRepository();
            ddlState.DataSource = r.getStatesInfo();
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "StateID";
            ddlState.DataBind();

            CityRepository cr = new CityRepository();
            ddlCity.DataSource = cr.getCitiesInfoByStateID(ddlState.SelectedIndex + 1);
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityID";
            ddlCity.DataBind();
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            CityRepository cr = new CityRepository();
            ddlCity.DataSource = cr.getCitiesInfoByStateID(ddlState.SelectedIndex + 1);
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityID";
            ddlCity.DataBind();
        }

        private void save()
        {
            EmployeesRepository er = new EmployeesRepository();
            Employee em = new Employee();
            em.Address = lbladdress.Value;
            em.City = ddlCity.SelectedValue.ToInt();
            em.State = ddlCity.SelectedValue.ToInt();
            em.Email = lblemail.Value;
            em.EmployeeID = lblid.Value.ToInt();
            em.FirstName = lblfirstName.Value;
            em.LastName = lblLastName.Value;
            em.Mobile = lblmobile.Value;
            em.Password = lblpassword.Value;
            em.UserName = lblusername.Value;
            em.PostalCode = lblzip.Value;
            er.SaveEmployees(em);
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
                            byte[] fileData = (byte[])dr.GetValue(0);
                            Image1.Src = "data:image/png;base64," + Convert.ToBase64String(fileData);
                        }

                        dr.Close();
                    }
                    cn.Close();
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            save();
            if (fileImage.HasFile)
            {
                if (fileImage.FileBytes.Length > 1024 * 1024)
                {
                    lblWarning.Text = "سایز عکس آپلود شده بیشتر از 1 مگابایت است";
                    lblWarning.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                string ext = Path.GetExtension(fileImage.FileName).ToLower();
                if (ext != ".jpg" && ext != ".png" && ext != "" && ext != null)
                {
                    lblWarning.Text = "عکس با فرمت " + " jpg. " + "یا " + " png. " + "آپلود کنید.";
                    lblWarning.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                string filename = Path.GetFileName(fileImage.FileName);
                string rand = DBManager.CurrentTimeWithoutColons() + DBManager.CurrentPersianDateWithoutSlash();
                filename = rand + filename;
                string ps = Server.MapPath(@"~\img\") + filename;
                fileImage.SaveAs(ps);

                FileStream fStream = File.OpenRead(ps);
                byte[] contents = new byte[fStream.Length];
                fStream.Read(contents, 0, (int)fStream.Length);
                fStream.Close();
                FileInfo fi = new FileInfo(ps);
                fi.Delete();

                EmployeesRepository er = new EmployeesRepository();
                er.setEmployeeImage(empid, contents);
                lblWarning.Text = "اطلاعات با موفقیت ویرایش شد";
                lblWarning.ForeColor = System.Drawing.Color.Green;

                setLabels();
            }
            if (fileResume.HasFile)
            {
                if (fileResume.FileBytes.Length > 5 * 1024 * 1024)
                {
                    lblWarning.Text = ".سایز فایل آپلود شده بیشتر از 5 مگابایت است";
                    lblWarning.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                string ext = Path.GetExtension(fileResume.FileName).ToLower();
                if (ext != ".zip" && ext != "" && ext != null)
                {
                    lblWarning.Text = "رزومه ی خود را بصورت فایل و با فرمت zip. ارسال کنید.";
                    lblWarning.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                string filename = Path.GetFileName(fileResume.FileName);
                string rand = DBManager.CurrentTimeWithoutColons() + DBManager.CurrentPersianDateWithoutSlash();
                filename = rand + filename;
                string ps = Server.MapPath(@"~\img\") + filename;
                fileResume.SaveAs(ps);

                FileStream fStream = File.OpenRead(ps);
                byte[] contents = new byte[fStream.Length];
                fStream.Read(contents, 0, (int)fStream.Length);
                fStream.Close();
                FileInfo fi = new FileInfo(ps);
                fi.Delete();

                EmployeesRepository er = new EmployeesRepository();
                er.setEmployeeResume(empid, contents);
                lblWarning.Text = "اطلاعات با موفقیت ویرایش شد.";
                lblWarning.ForeColor = System.Drawing.Color.Green;
            }
        }
    }
}
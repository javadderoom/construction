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

namespace WebPages.Panels.Admin
{
    public partial class EdidProject : System.Web.UI.Page
    {
        private string setInlineImage(int arid)
        {
            string ans = "";
            using (SqlConnection cn = new SqlConnection(OnlineTools.conString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(string.Format("select Image from Projects where ProjectID = {0}", arid), cn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                    {
                        if (dr.Read())
                        {

                            byte[] fileData = (byte[])dr.GetValue(0);
                            ans = "data:image/png;base64," + Convert.ToBase64String(fileData);
                        }

                        dr.Close();
                    }
                    cn.Close();



                }
            }
            return ans;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminid"] != null)
            {
                if (Session["ProjectIDForEdit"] != null)
                {
                    if (!IsPostBack)
                    {

                        int id = Session["ProjectIDForEdit"].ToString().ToInt();
                        //Session.Add("newProjectIDForEdit", id);
                        //Session.Remove("ProjectIDForEdit");
                        ProjectsRepository repArt = new ProjectsRepository();
                        GroupsRepository repo = new GroupsRepository();
                        Project art = repArt.FindeProjectByID(id);
                        title.Text = art.Title;
                        Abstract.Text = art.Abstract;
                        editor1.Text = art.Content;
                        KeyWords.Text = art.KeyWords;
                        Tags.Text = art.Tags;
                        SelectedSubGroups.DataSource = repo.FindSubGroupsOfAProject(id);
                        SelectedSubGroups.DataTextField = "Title";
                        SelectedSubGroups.DataValueField = "GroupID";
                        SelectedSubGroups.DataBind();
                        for (int i = 0; i < SelectedSubGroups.Items.Count; i++)
                        {
                            if (SelectedSubGroups.Items[i].Value == "-1")
                            {
                                SelectedSubGroups.Items[i].Text = "گروه : " + SelectedSubGroups.Items[i].Text;
                            }
                        }

                        DDLGroups2.DataSource = repo.LoadAllGroups();
                        DDLGroups2.DataTextField = "Title";
                        DDLGroups2.DataValueField = "GroupID";
                        DDLGroups2.DataBind();
                        DDLGroups2.Items.Insert(0, new ListItem("یک گروه انتخاب کنید", "-2"));
                        oldPhoto.ImageUrl = setInlineImage(id);
                    }

                }
                else
                {
                    Response.Redirect("/Admin/ManageProjects");
                }
            }
            else
            {
                Response.Redirect("/AdminLogin");
            }
        }




        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!(String.IsNullOrEmpty(editor1.Text) ||
                String.IsNullOrEmpty(title.Text) ||
                String.IsNullOrEmpty(Abstract.Text) ||
                String.IsNullOrEmpty(Tags.Text) ||
                String.IsNullOrEmpty(KeyWords.Text) || SelectedSubGroups.Items.Count == 0 || Abstract.Text.Count() < 130))
            {
                if (Session["ProjectIDForEdit"] != null)
                {



                    int id = Session["ProjectIDForEdit"].ToString().ToInt();
                    //Session.Remove("newProjectIDForEdit");
                    ProjectsRepository repArt = new ProjectsRepository();
                    GroupsRepository repo = new GroupsRepository();
                    Project art = repArt.FindeProjectByID(id);

                    art.Title = title.Text;
                    art.Content = editor1.Text;

                    if (FileUpload1.HasFile)
                    {
                        if (FileUpload1.FileBytes.Length > 1024 * 1024)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('حجم فایل بارگذاری شده بیشتر از 1 مگابایت است!')", true);

                            return;
                        }
                        string ext = Path.GetExtension(FileUpload1.FileName).ToLower();
                        if ((ext != ".jpg") && (ext != ".png"))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('فرمت فایل بارگذاری شده باید .jpg  یا .png  باشد!')", true);

                            return;
                        }
                        string filename = Path.GetFileName(FileUpload1.FileName);
                        string rand = DBManager.CurrentTimeWithoutColons() + DBManager.CurrentPersianDateWithoutSlash();
                        filename = rand + filename;
                        string ps = Server.MapPath(@"~\img\") + filename;
                        FileUpload1.SaveAs(ps);
                        FileStream fStream = File.OpenRead(ps);
                        byte[] contents = new byte[fStream.Length];
                        fStream.Read(contents, 0, (int)fStream.Length);
                        fStream.Close();
                        FileInfo fi = new FileInfo(ps);
                        fi.Delete();
                        art.Image = contents;
                        System.Drawing.Image img = imgResize.ToImage(contents);
                        System.Drawing.Image image = imgResize.Resize(img, 466, 466);
                        var myArray = image.ToByteArray();
                        art.ImgFisrtPage = myArray;

                    }





                    art.Abstract = Abstract.Text;
                    art.Tags = Tags.Text;
                    art.KeyWords = KeyWords.Text;

                    ProjectConRepository pcr = new ProjectConRepository();
                    pcr.deleteByProjectID(Session["ProjectIDForEdit"].ToString().ToInt());

                    ProjectsRepository ARTRep = new ProjectsRepository();
                    if (ARTRep.SaveProject(art))
                    {
                        bool result = true;
                        ProjectConRepository GRConRepo = new ProjectConRepository();
                        GRConRepo.DeletProjectConnections(id);
                        List<int> SelectedSubGroupsList = new List<int>();

                        int lastid = id;
                        int count = SelectedSubGroups.Items.Count;
                        if (count > 0)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                ProjectConnection GC = new ProjectConnection();
                                GC.ProjectID = lastid;
                                GC.GroupID = SelectedSubGroups.Items[i].Value.ToInt();
                                if (!GRConRepo.SaveProjectCon(GC))
                                {
                                    result = false;
                                }
                            }

                            Session.Add("ProjectLastIDForEmployeeFilterEdit", id);
                            Response.Redirect("AddProject/AddEmployeeToProjectEdit");
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('هیچ زیر گروهی انتخاب نشده است!')", true);
                        }

                        if (!result)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('مشکلی در زمان ثبت به وجود آمد،لطفا دوباره سعی کنید یا با پشتیبانی تماس بگیرید ! ');window.location ='/Admin/ManageProjects'", true);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ثبت با موفقیت انجام شد!');window.location ='/Admin/ManageBlogs'", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('مشکلی در زمان ثبت به وجود آمد،لطفا دوباره سعی کنید یا با پشتیبانی تماس بگیرید ! ');window.location ='/Admin/ManageProjects'", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' مشکلی در زمان لود کردن به وجود آمد دوباره سعی کنید ! ');window.location ='/Admin/ManageProjects'", true);
                }

            }

        }

        protected void DDLGroups2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupsRepository repo = new GroupsRepository();
            DataTable DT = new DataTable();
            if (DDLGroups2.SelectedValue != "-2")
            {
                DT = repo.LoadSubGroup(DDLGroups2.SelectedValue.ToInt());

                if ((DT.Rows.Count > 0))
                {
                    SubGroups2.DataSource = DT;
                    SubGroups2.DataTextField = "Title";
                    SubGroups2.DataValueField = "GroupID";
                    SubGroups2.DataBind();
                    NoItemDiv.InnerText = "";
                }
                else
                {
                    SubGroups2.Items.Clear();
                    SubGroups2.Items.Insert(0, new ListItem(DDLGroups2.SelectedItem.ToString(), DDLGroups2.SelectedValue.ToString()));
                    NoItemDiv.InnerText = "این گروه هیچ زیر گروهی ندارد،میتوانید نام گروه را اضافه کنید";
                    NoItemDiv.Attributes["class"] = "textok";
                }
            }
            else
            {
                SubGroups2.Items.Clear();
                NoItemDiv.InnerText = "";
            }

        }

        protected void AddToSub2_Click(object sender, EventArgs e)
        {
            if (SubGroups2.SelectedIndex != -1)
            {
                bool isadd = false;
                string text = SubGroups2.SelectedItem.Value;
                for (int i = 0; i < SelectedSubGroups.Items.Count; i++)
                {
                    if (SelectedSubGroups.Items[i].Value == text)
                    {
                        isadd = true;
                    }
                }
                if (!isadd)
                {
                    SelectedSubGroups.Items.Add(SubGroups2.SelectedItem.Text);
                    SelectedSubGroups.Items[SelectedSubGroups.Items.Count - 1].Value = SubGroups2.SelectedItem.Value;
                    btnSave.Enabled = true;
                    diverror.InnerText = "";
                    NoItemDiv.InnerText = "";
                }
                else
                {
                    NoItemDiv.InnerText = "این مورد قبلا اضافه شده است!";
                    NoItemDiv.Attributes["class"] = "error";
                }
            }
            else
            {
                NoItemDiv.InnerText = "شما هیچ موردی را انتخاب نکرده اید!";
                NoItemDiv.Attributes["class"] = "error";
            }
        }

        protected void RemoveFromSub2_Click(object sender, EventArgs e)
        {
            if (SelectedSubGroups.SelectedIndex != -1)
            {
                SelectedSubGroups.Items.RemoveAt(SelectedSubGroups.SelectedIndex);
                NoItemDiv.InnerText = "";
                if (SelectedSubGroups.Items.Count == 0)
                {
                    btnSave.Enabled = false;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('هیچ گروهی انتخاب نشده!')", true);
                    diverror.InnerText = "هیچ گروهی انتخاب نشده!";
                }
            }
            else
            {
                NoItemDiv.InnerText = "شما هیچ موردی را انتخاب نکرده اید!";
                NoItemDiv.Attributes["class"] = "error";
            }
        }
    }
}
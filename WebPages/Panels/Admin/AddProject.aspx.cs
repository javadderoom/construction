using Common;
using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages.Panels.Admin
{
    public partial class AddProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSave.Enabled = false;
                diverror.InnerText = "هیچ گروهی انتخاب نشده!";
                GroupsRepository repo = new GroupsRepository();
                DDLGroups.DataSource = repo.LoadAllGroups();
                DDLGroups.DataTextField = "Title";
                DDLGroups.DataValueField = "GroupID";
                DDLGroups.DataBind();
                DDLGroups.Items.Insert(0, new ListItem("یک گروه انتخاب کنید", "-2"));

            }

        }
        protected void DDLGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupsRepository repo = new GroupsRepository();
            if (DDLGroups.SelectedValue != "-2")
            {
                DataTable DT = new DataTable();
                DT = repo.LoadSubGroup(DDLGroups.SelectedValue.ToInt());

                if ((DT.Rows.Count > 0))
                {
                    SubGroups.DataSource = DT;
                    SubGroups.DataTextField = "Title";
                    SubGroups.DataValueField = "GroupID";
                    SubGroups.DataBind();
                    NoItemDiv.InnerText = "";
                }
                else
                {
                    SubGroups.Items.Clear();
                    SubGroups.Items.Insert(0, new ListItem(DDLGroups.SelectedItem.ToString(), DDLGroups.SelectedValue.ToString()));
                    NoItemDiv.InnerText = "این گروه هیچ زیر گروهی ندارد،میتوانید نام گروه را اضافه کنید";
                    NoItemDiv.Attributes["class"] = "textok";
                }

            }
            else
            {
                SubGroups.Items.Clear();
                NoItemDiv.InnerText = "";
            }


        }

        protected void AddToSub_Click(object sender, EventArgs e)
        {
            if (SubGroups.SelectedIndex != -1)
            {
                bool isadd = false;
                string text = SubGroups.SelectedItem.Text;
                for (int i = 0; i < SelectedSubGroups.Items.Count; i++)
                {
                    if (SelectedSubGroups.Items[i].Text == text)
                    {
                        isadd = true;
                    }
                }
                if (!isadd)
                {
                    SelectedSubGroups.Items.Add(text);
                    SelectedSubGroups.Items[SelectedSubGroups.Items.Count - 1].Value = SubGroups.SelectedItem.Value;
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

        protected void RemoveFromSub_Click(object sender, EventArgs e)
        {
            if (SelectedSubGroups.SelectedIndex != -1)
            {

                SelectedSubGroups.Items.RemoveAt(SelectedSubGroups.SelectedIndex);
                NoItemDiv.InnerText = "";
                if (SelectedSubGroups.Items.Count == 0)
                {
                    btnSave.Enabled = false;
                    diverror.InnerText = "هیچ گروهی انتخاب نشده!";
                }
            }
            else
            {
                NoItemDiv.InnerText = "شما هیچ موردی را انتخاب نکرده اید!";
                NoItemDiv.Attributes["class"] = "error";
            }


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if ((String.IsNullOrEmpty(editor1.Text) == false) &&
                (Abstract.Text.Length >= 130) &&
                (FileUpload1.HasFile) &&
                (String.IsNullOrEmpty(title.Text) == false) &&
                (String.IsNullOrEmpty(Abstract.Text) == false) &&
                (String.IsNullOrEmpty(Tags.Text) == false) &&
                (String.IsNullOrEmpty(KeyWords.Text) == false))
            {
                if (FileUpload1.FileBytes.Length > 1024 * 1024)
                {
                    diverror.InnerHtml = "حجم فایل بارگذاری شده بیشتر از 1 مگابایت است!";
                    return;
                }
                string ext = Path.GetExtension(FileUpload1.FileName).ToLower();
                if ((ext != ".jpg") && (ext != ".png"))
                {
                    diverror.InnerHtml = "فرمت فایل بارگذاری شده باید .jpg  یا .png  باشد!";
                    return;
                }


                Project ART = new Project();
                ART.Title = title.Text;
                ART.Content = editor1.Text;


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
                ART.Image = contents;



                ART.Abstract = Abstract.Text;
                ART.PostDateTime = OnlineTools.persianFormatedDate();

                ART.Tags = Tags.Text;
                ART.KeyWords = KeyWords.Text;
                ProjectsRepository ARTRep = new ProjectsRepository();
                if (ARTRep.SaveProject(ART))
                {
                    bool result = true;
                    ProjectConRepository GRConRepo = new ProjectConRepository();
                    List<int> SelectedSubGroupsList = new List<int>();

                    int lastid = ARTRep.GetLastProjectID();
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
                    }
                    else
                    {
                        diverror.InnerText = "هیچ زیر گروهی انتخاب نشده است!";
                    }

                    if (!result)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('مشکلی در زمان ثبت به وجود آمد،لطفا دوباره سعی کنید یا با پشتیبانی تماس بگیرید ! ');window.location ='/Admin/ManageProjects'", true);

                    }
                    else
                    {
                        Response.Redirect("/Admin/ManageProjects");
                    }

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('مشکلی در زمان ثبت به وجود آمد،لطفا دوباره سعی کنید یا با پشتیبانی تماس بگیرید ! ');window.location ='/Admin/ManageProjects'", true);

                }
            }


        }
    }
}

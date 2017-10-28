﻿using Common;
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
    public partial class EdidProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ProjectIDForEdit"] != null)
                {
                    int id = Session["ProjectIDForEdit"].ToString().ToInt();
                    Session.Add("newProjectIDForEdit", id);
                    Session.Remove("ProjectIDForEdit");
                    ProjectsRepository repArt = new ProjectsRepository();
                    ProjectGroupsRepository repo = new ProjectGroupsRepository();
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

                    DDLGroups.DataSource = repo.LoadAllGroups();
                    DDLGroups.DataTextField = "Title";
                    DDLGroups.DataValueField = "GroupID";
                    DDLGroups.DataBind();
                    DDLGroups.Items.Insert(0, new ListItem("یک گروه انتخاب کنید", "-2"));
                }
                else
                {
                    Response.Redirect("");//manage posts
                }
            }
        }

        protected void DDLGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectGroupsRepository repo = new ProjectGroupsRepository();
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

        protected void AddToSub_Click(object sender, EventArgs e)
        {
            if (SubGroups.SelectedIndex != -1)
            {
                bool isadd = false;
                string text = SubGroups.SelectedItem.Value;
                for (int i = 0; i < SelectedSubGroups.Items.Count; i++)
                {
                    if (SelectedSubGroups.Items[i].Value == text)
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!(String.IsNullOrEmpty(editor1.Text) ||
                String.IsNullOrEmpty(title.Text) ||
                String.IsNullOrEmpty(Abstract.Text) ||
                String.IsNullOrEmpty(Tags.Text) ||
                String.IsNullOrEmpty(KeyWords.Text) || SelectedSubGroups.Items.Count == 0 || Abstract.Text.Count() < 130))
            {
                if (Session["newProjectIDForEdit"] != null)
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

                    int id = Session["newProjectIDForEdit"].ToString().ToInt();
                    Session.Remove("newProjectIDForEdit");
                    ProjectsRepository repArt = new ProjectsRepository();
                    ProjectGroupsRepository repo = new ProjectGroupsRepository();
                    Project art = repArt.FindeProjectByID(id);

                    art.Title = title.Text;
                    art.Content = editor1.Text;

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

                    art.Abstract = Abstract.Text;
                    art.Tags = Tags.Text;
                    art.KeyWords = KeyWords.Text;
                    ProjectsRepository ARTRep = new ProjectsRepository();
                    if (ARTRep.SaveProject(art))
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
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('هیچ زیر گروهی انتخاب نشده است!')", true);
                        }

                        if (!result)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('مشکلی در زمان ثبت به وجود آمد،لطفا دوباره سعی کنید یا با پشتیبانی تماس بگیرید ! ');window.location ='مدیریت-وبلاگ-ها'", true);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ثبت با موفقیت انجام شد!');window.location ='مدیریت-وبلاگ-ها'", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('مشکلی در زمان ثبت به وجود آمد،لطفا دوباره سعی کنید یا با پشتیبانی تماس بگیرید ! ');window.location ='مدیریت-وبلاگ-ها'", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' مشکلی در زمان لود کردن به وجود آمد دوباره سعی کنید ! ');window.location ='مدیریت-وبلاگ-ها'", true);
                }
            }
        }
    }
}
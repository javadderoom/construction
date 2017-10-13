using Common;
using DataAccess.Repository;
using System;
using System.Data;
//using System.Globalization;
using System.Web.UI.WebControls;

namespace WebPages.Panels.Admin
{
    public partial class AddNews1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //OnlineTools.persianFormatedDate();
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
                SubGroups.Items.Insert(0, new ListItem("گروه : " + DDLGroups.SelectedItem.ToString(), DDLGroups.SelectedValue.ToString()));
                NoItemDiv.InnerText = "این گروه هیچ زیر گروهی ندارد،میتوانید نام گروه را اضافه کنید";
                NoItemDiv.Attributes["class"] = "textok";
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

        }
    }

}

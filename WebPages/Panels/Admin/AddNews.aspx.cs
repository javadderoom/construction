using System;
using System.Collections.Generic;
using System.Web.UI;

namespace WebPages.Panels.Admin
{
    public partial class AddNews1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> mylist = new List<string> { "a", "b", "c", "d" };
                List<string> mylist2 = new List<string> { "e", "f", "g", "h" };
                List<string> mylist3 = new List<string> { "i", "j", "k", "l" };
                foreach (string text in mylist)
                {
                    SelectedSubGroups.Items.Add(text);
                }
                foreach (string text in mylist2)
                {
                    SubGroups.Items.Add(text);
                }
                foreach (string text in mylist3)
                {
                    DDLGroups.Items.Add(text);
                }
            }



        }
        private bool stringCheck()
        {
            bool ans = true;
            if (String.IsNullOrEmpty(editor1.Text))
            {
                Response.Write("<script language=javascript>alert('شما هیچ متنی وارد نکرده اید!');</script>");
                ans = false;
            }
            if (String.IsNullOrEmpty(title.Text) || String.IsNullOrEmpty(Abstract.Text) || String.IsNullOrEmpty(KeyWords.Text) || String.IsNullOrEmpty(Tags.Text))
            {
                Response.Write("<script language=javascript>alert('لطفا دوباره چک کنید،یکی از باکس ها خالی میباشد!');</script>");
                ans = false;
            }

            return ans;
        }

        protected void Save_Click(object sender, EventArgs e)
        {

        }

        protected void DDLGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubGroups.Items.Add("OK");


        }

        protected void AddToSub_Click(object sender, EventArgs e)
        {
            if (SubGroups.SelectedIndex != -1)
            {
                SelectedSubGroups.Items.Add(SubGroups.SelectedItem.Text);
                SubGroups.Items.RemoveAt(SubGroups.SelectedIndex);
            }
            else
            {


                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "key_name", "alert('شما هیچ موردی را انتخاب نکرده اید!');", true);
            }

        }

        protected void RemoveFromSub_Click(object sender, EventArgs e)
        {
            if (SelectedSubGroups.SelectedIndex != -1)
            {
                SubGroups.Items.Add(SelectedSubGroups.SelectedItem.Text);
                SelectedSubGroups.Items.RemoveAt(SelectedSubGroups.SelectedIndex);
            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "key_name", "alert('شما هیچ موردی را انتخاب نکرده اید!');", true);
            }


        }
    }

}

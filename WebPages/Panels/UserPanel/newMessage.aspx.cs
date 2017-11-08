using Common;
using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages.Panels.UserPanel
{
    public partial class newMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] != null)
            {








            }
            else
            {
                Response.Redirect("/Login");
            }
        }

        protected void btnViewAll_ServerClick(object sender, EventArgs e)
        {

        }

        protected void btnSend_ServerClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSubject.Value) || string.IsNullOrEmpty(tbxMessageText.Value))
                return;
            string ext = Path.GetExtension(FileUpload1.FileName).ToLower();
            if (ext != ".zip" && ext != "" && ext != null)
            {
                lblWarning.Text = "فرمت فایل مجاز نیست";
                lblWarning.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (FileUpload1.FileBytes.Length > 1024 * 1024)
            {
                lblWarning.Text = "حجم فایل بارگذاری شده بیشتر از 1 مگابایت است";
                lblWarning.ForeColor = System.Drawing.Color.Red;
                return;
            }

            int id = Session["userid"].ToString().ToInt();
            string tbl = "use";

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
            bool done = true;
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    Chat c = new Chat();
                    c.ChatTitle = txtSubject.Value;
                    c.AdminID = 1;
                    c.User_Employee_ID = id;
                    ChatsRepository cr = new ChatsRepository();
                    cr.SaveChats(c);

                    Message msg = new Message();

                    msg.MessageText = tbxMessageText.Value;
                    msg.MessageDate = DBManager.CurrentPersianDate();
                    msg.MessageTime = DBManager.CurrentTime();
                    msg.SenderTable = tbl;
                    msg.SenderID = id;
                    msg.ChatID = cr.getLastChatID();
                    msg.hasSeen = true;
                    if (contents.Length == 0)
                        msg.MessageFile = null;
                    else
                        msg.MessageFile = contents;

                    MessageRepository mr = new MessageRepository();
                    mr.SaveMessages(msg);
                    ts.Complete();

                    lblWarning.Text = "پیام شما با موفقیت ارسال شد";
                    lblWarning.ForeColor = System.Drawing.Color.Green;
                    txtSubject.Value = "";
                    tbxMessageText.Value = "";
                }
                catch
                {
                    done = false;
                    lblWarning.Text = "در ارسال پیام مشکلی بوجود آمد.لطفا مجددا سعی کنید";
                    lblWarning.ForeColor = System.Drawing.Color.Red;
                }
            }
            if (done)
            {
                Response.Redirect("/User/Inbox");
            }


        }


    }
}
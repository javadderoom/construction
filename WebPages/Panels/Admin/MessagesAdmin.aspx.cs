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
    public partial class MessagesAdmin : System.Web.UI.Page
    {
        int chatid = 0;
        int userid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            chatid = Session["chatidforMessages"].ToString().ToInt();
            userid = Session["useridforMessages"].ToString().ToInt();

            if (!IsPostBack)
            {
                setLabels();
            }
            else
            {
                string elemid = Request.Form["__EVENTTARGET"].ToString();
                if (elemid.Substring(0, 7) == "btnmsgx")
                {

                    int elid = Int32.Parse(elemid.Substring(7));
                    try
                    {
                        download(elid);
                    }
                    catch
                    {

                    }


                }

            }
        }

        private void setLabels()
        {
            lblid.InnerText = "صندوق پیام انتخابی :" + chatid;

            MessageRepository mr = new MessageRepository();
            DataTable dt = mr.getMessagesInfoOfEmployee(chatid);

            lblidnum.InnerText = chatid.ToString();
            lblStartTime.InnerText = dt.Rows[0][5].ToString();
            lblSubject.InnerText = dt.Rows[0][1].ToString();
            //lblusername.InnerText = dt.Rows[0][4].ToString();
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            if (tbxMessageText.Value.Length == 0)
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

            // int id = Session["userid"].ToString().ToInt();
            string tbl = "adm";

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
            try
            {
                Message msg = new Message();

                msg.MessageText = tbxMessageText.Value;
                msg.MessageDate = DBManager.CurrentPersianDate();
                msg.MessageTime = DBManager.CurrentTime();
                msg.SenderTable = tbl;
                msg.SenderID = Session["adminid"].ToString().ToInt();
                msg.ChatID = chatid;
                msg.hasSeen = true;
                if (contents.Length == 0)
                    msg.MessageFile = null;
                else
                    msg.MessageFile = contents;

                MessageRepository mr = new MessageRepository();
                mr.SaveMessages(msg);

                tbxMessageText.InnerText = "";
                lblWarning.Text = "";
            }
            catch
            {
                lblWarning.Text = "در ارسال پیام مشکلی بوجود آمد.لطفا مجددا سعی کنید";
                lblWarning.ForeColor = System.Drawing.Color.Red;
            }

        }
        public string messages()
        {
            MessageRepository mr = new MessageRepository();
            DataTable dt = mr.getMessages(chatid);
            int msgcnt = mr.getChatMessgesCount(chatid);
            //string s = "<div id = \"msg\" style = \"width: 50%; border: 1px solid #dad0d0; border-radius: 5px; margin: auto; margin-bottom: 20px; direction: rtl; overflow-wrap: break-word\" > " +
            //        "<div id = \"mhead\" style = \"height: 40px; background-color: #e4dbdb; padding: 10px\" >" +
            //            "<div style = \"float: left\" > jhgjh </div>" +
            //            "<div style = \"float: right\" >,kj,h,mn </div>" +
            //        "</div>" +
            //        "<div id = \"mmain\" style = \"padding: 10px\" >,fjvnfxdj,nbxdknbldskjbkldsnmbj.; gbkjskbd; sofghnkd; lm </div>" +
            //        "<div id = \"mfoot\" style = \"height: 30px; background-color: #ede6e6; padding: 10px\" >" +
            //            "<a href = \"\" > لینک دانلود فایل پیوست </a>" +

            //        "</div>" +
            //  "</div>";
            string tag = "";
            string a = "<input type = 'button' id = 'btnmsgx1' name = 'btn21' onclick = \"__doPostBack('btnmsgx1','')\" value = 'Click Here' />";
            string aa = "";
            string pers = "";
            for (int i = 0; i < msgcnt; i++)
            {
                if (dt.Rows[i][4] != DBNull.Value)
                    aa = "<input type = 'button' style='border:none;border-radius:5px;color:blue;background-color:#ede6e6;' id = 'btnmsgx1' name = 'btn21' onclick = \"__doPostBack('btnmsgx" + dt.Rows[i][0].ToString() + "','')\" value = 'دانلود فایل پیوست' />";
                else
                    aa = "";

                if (dt.Rows[i][5].ToString() == "adm")
                    pers = "شما : ";
                else
                    pers = "کاربر :";


                tag += "<div id = \"msg\" style = \"width: 50%; border: 1px solid #dad0d0; margin: auto; margin-bottom: 20px; direction: rtl; overflow-wrap: break-word\" > " +
                    "<div id = \"mhead\" style = \"height: 40px; background-color: #18bc9c; padding: 10px\" >" +
                        "<div style = \"float: left;color:white\" > " + dt.Rows[i][9].ToString() + " </div>" +
                        "<div style = \"float: right\" >" + pers + " </div>" +
                    "</div>" +
                    "<div id = \"mmain\" style = \"padding: 10px\" >" + dt.Rows[i][1].ToString() + " </div>" +
                    "<div id = \"mfoot\" style = \"height: 40px; background-color: #ede6e6; padding: 10px\" >" +
                        aa +

                    "</div>" +
              "</div>";




            }
            return tag;
        }

        protected void btnDownload_ServerClick(object sender, EventArgs e)
        {
            string controlName = Request.Params["__EVENTTARGET"];
            Response.Redirect(controlName);
        }
        public void download(int idname)
        {
            string ToSaveFileTo = KnownFolders.GetPath(KnownFolder.Downloads) + "\\" + DBManager.CurrentPersianDateWithoutSlash() + DBManager.CurrentTimeWithoutColons() + "file.zip";// Server.MapPath("~\\File\\file.zip");

            using (SqlConnection cn = new SqlConnection(OnlineTools.conString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(string.Format("select MessageFile from Messages where MessageID = {0}", idname), cn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                    {
                        if (dr.Read())
                        {

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
                }
            }
        }

    }
}
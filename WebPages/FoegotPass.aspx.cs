using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages._construction
{
    public partial class FoegotPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillImageText();
            }
        }
        private void FillImageText()
        {
            try
            {
                Random rdm = new Random();
                string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                StringBuilder ImgValue = new StringBuilder();
                for (int i = 0; i < 5; i++)
                {
                    ImgValue.Append(combination[rdm.Next(combination.Length)]);
                    Session.Add("ImgValue", ImgValue.ToString());
                    btnImg.ImageUrl = "catchimage.aspx?";
                }
            }
            catch
            {
                throw;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxMail.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('متنی وارد نشده است ! ');", true);
                return;
            }
            if (Session["ImgValue"].ToString() == txtImage.Value.ToUpper())
            {

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('کد وارد شده صحیح نمی باشد ! ');", true);
                txtImage.Value = "";
                Session.Remove("ImgValue");
                FillImageText();
                return;
            }
            ///////////////////////////////////////////////////////////////////////////////////
            if (rdiEmployees.Checked == true)
            {
                EmployeesRepository r = new EmployeesRepository();
                Employee emp = r.ChekEmployee(tbxMail.Text);
                if (emp == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('چنین کاربری وجود ندارد ! ');", true);
                    txtImage.Value = "";
                    Session.Remove("ImgValue");
                    FillImageText();
                    return;
                }
                else
                {
                    string smtpAddress = "smtp.gmail.com";
                    int portNumber = 587;
                    bool enableSSL = true;

                    string emailFrom = "hamoonshahsavar@gmail.com";
                    string password = "2210226104H";
                    string emailTo = emp.Email;
                    string subject = "فراموشی رمز";
                    string body = "<p style='direction: rtl; text - align:right'><p><span style='font-size:18px'><strong>کاربر محترم سلام.</strong></span></p><p>این پیام شامل رمز ورود شما میباشد و به این دلیل برای شما ارسال شده که شخصی ایمیل شما را در بخش فراموشی رمز عبور وارد کرده است.</p><p>اگر این شخص شما نبوده اید این پیام را نادیده بگیرید،در غیر این صورت میتوانید با اطلاعات زیر وارد شوید :</p><p>نام کاربری :&quot;" + emp.UserName + "&quot;</p><p>رمزعبور :&quot;" + emp.Password + "&quot;</p><p style='text-align:center'>با تشکر</p><p style='text-align:center'>تیم پشتیبانی <a href='http://localhost:6421'>وبسایت</a></p></p>";

                    using (MailMessage mail = new MailMessage())
                    {
                        bool result = true;
                        mail.From = new MailAddress(emailFrom);
                        mail.To.Add(emailTo);
                        mail.Subject = subject;
                        mail.Body = body;
                        mail.IsBodyHtml = true;


                        using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                        {
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = new NetworkCredential(emailFrom, password);
                            smtp.EnableSsl = enableSSL;
                            try
                            {
                                smtp.Send(mail);

                            }
                            catch (Exception)
                            {

                                result = false;
                            }

                        }
                        if (result)
                        {
                            Response.Redirect("/Login");
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('مشکلی در زمان ارسال به وجود امد،دوباره سعی کنید ! ');", true);
                        }
                    }

                }
            }
            else
            {
                UsersRepository r = new UsersRepository();
                User user = r.ChekUser(tbxMail.Text);
                if (user == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('چنین کاربری وجود ندارد !  ');", true);
                    txtImage.Value = "";
                    FillImageText();
                    return;
                }

                else
                {

                    string smtpAddress = "smtp.gmail.com";
                    int portNumber = 587;
                    bool enableSSL = true;

                    string emailFrom = "hamoonshahsavar@gmail.com";
                    string password = "2210226104H";
                    string emailTo = user.Email;
                    string subject = "فراموشی رمز";
                    string body = "<p style='direction: rtl; text - align:right'><p><span style='font-size:18px'><strong>کاربر محترم سلام.</strong></span></p><p>این پیام شامل رمز ورود شما میباشد و به این دلیل برای شما ارسال شده که شخصی ایمیل شما را در بخش فراموشی رمز عبور وارد کرده است.</p><p>اگر این شخص شما نبوده اید این پیام را نادیده بگیرید،در غیر این صورت میتوانید با اطلاعات زیر وارد شوید :</p><p>نام کاربری :&quot;" + user.UserName + "&quot;</p><p>رمزعبور :&quot;" + user.Password + "&quot;</p><p style='text-align:center'>با تشکر</p><p style='text-align:center'>تیم پشتیبانی <a href='http://localhost:6421'>وبسایت</a></p></p>";


                    using (MailMessage mail = new MailMessage())
                    {
                        bool result = true;
                        mail.From = new MailAddress(emailFrom);
                        mail.To.Add(emailTo);
                        mail.Subject = subject;
                        mail.Body = body;
                        mail.IsBodyHtml = true;


                        using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                        {
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = new NetworkCredential(emailFrom, password);
                            smtp.EnableSsl = enableSSL;
                            try
                            {
                                smtp.Send(mail);

                            }
                            catch (Exception)
                            {

                                result = false;
                            }

                        }
                        if (result)
                        {
                            Response.Redirect("/Login");
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('مشکلی در زمان ارسال به وجود امد،دوباره سعی کنید ! ');", true);
                        }
                    }

                }
            }
        }
    }
}

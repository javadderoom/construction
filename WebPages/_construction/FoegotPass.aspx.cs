using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}

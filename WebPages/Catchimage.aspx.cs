using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages
{
    public partial class Catchimage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Clear();
            int height = 30;
            int width = 70;
            Bitmap bt = new Bitmap(width, height);

            RectangleF rectf = new RectangleF(7, 5, 0, 0);

            Graphics grph = Graphics.FromImage(bt);
            grph.Clear(Color.White);
            grph.SmoothingMode = SmoothingMode.AntiAlias;
            grph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grph.PixelOffsetMode = PixelOffsetMode.HighQuality;
            grph.DrawString(Session["ImgValue"].ToString(), new Font("Times New Roman", 13, FontStyle.Regular), Brushes.Blue, rectf);
            grph.DrawRectangle(new Pen(Color.Green), 1, 1, width - 2, height - 2);
            grph.Flush();
            Response.ContentType = "images/download.png";
            bt.Save(Response.OutputStream, ImageFormat.Jpeg);
            grph.Dispose();
            bt.Dispose();

        }
    }
}
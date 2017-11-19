using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class imgResize
    {
        public static Image Resize(Image originalImage, int w, int h)
        {
            //Original Image attributes

            int originalWidth = originalImage.Width;
            int originalHeight = originalImage.Height;

            // Figure out the ratio
            double ratioX = (double)w / (double)originalWidth;
            double ratioY = (double)h / (double)originalHeight;
            // use whichever multiplier is smaller
            double ratio = ratioX < ratioY ? ratioX : ratioY;

            // now we can get the new height and width
            int newHeight = Convert.ToInt32(originalHeight * ratio);
            int newWidth = Convert.ToInt32(originalWidth * ratio);

            Image thumbnail = new Bitmap(newWidth, newHeight);
            Graphics graphic = Graphics.FromImage(thumbnail);
            thumbnail.Dispose();
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = CompositingQuality.HighQuality;

            graphic.Clear(Color.Transparent);
            graphic.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            Bitmap bmp = new Bitmap(originalImage, newWidth, newHeight);

            Image img = bmp;

            return img; ;
        }

        private static readonly ImageConverter _imageConverter = new ImageConverter();

        public static Image ToImage(this byte[] byteArrayIn)
        {
            var ms = new MemoryStream(byteArrayIn);

            var returnImage = Image.FromStream(ms);
            ms.Dispose();
            return returnImage;
        }

        public static byte[] ToByteArray(this Image imageIn)
        {
            var ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] re = ms.ToArray();
            ms.Dispose();
            return re;
        }
    }
}
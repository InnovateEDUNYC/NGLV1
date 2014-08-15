using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace NGL.Web.ImageTools
{
    public class Resizer
    {
        public static Stream ScaleImage(Stream inputStream, int maxWidth, int maxHeight)
        {
            var image = Image.FromStream(inputStream);
            var ratioX = (double) maxWidth/image.Width;
            var ratioY = (double) maxHeight/image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int) (image.Width*ratio);
            var newHeight = (int) (image.Height*ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);

            var imageStream = new MemoryStream();
            newImage.Save(imageStream, ImageFormat.Jpeg);
            imageStream.Position = 0;
            return imageStream;
        }
    }
}

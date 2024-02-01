using SkiaSharp;
using System.Text;

namespace Utils
{
    public class ImageResizer
    {
        #region Singleton

        public static ImageResizer Instance => instance.Value;

        private static Lazy<ImageResizer> instance = new Lazy<ImageResizer>(() => new ImageResizer());

        #endregion

        public byte[] ResizedImage(Stream imageStream, int width = 512)
        {
            try
            {
                SKBitmap image = SKBitmap.Decode(imageStream);

                var info = new SKImageInfo(width, (int)(width * (float)image.Height / image.Width));
                image = image.Resize(info, SKFilterQuality.High);

                using var ms = new MemoryStream();
                image.Encode(ms, SKEncodedImageFormat.Jpeg, 85);
                return ms.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ImageResizerEx: " + ex.Message);
            }
            return null;
        }

        public byte[] ResizedImage(byte[] imageBytes, int width = 512)
        {
            try
            {
                SKBitmap image = SKBitmap.Decode(imageBytes);

                var info = new SKImageInfo(width, (int)(width * (float)image.Height / image.Width));
                image = image.Resize(info, SKFilterQuality.High);

                using var ms = new MemoryStream();
                image.Encode(ms, SKEncodedImageFormat.Jpeg, 85);
                return ms.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ImageResizerEx: " + ex.Message);
            }
            return null;
        }

        public string ResizedImage(string base64Image, int width = 512)
        {
            return Convert.ToBase64String(ResizedImage(Convert.FromBase64String(base64Image), width));
        }
    }
}

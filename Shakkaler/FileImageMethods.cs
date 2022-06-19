using ImageMagick;

namespace Shakkaler
{
    internal static class FileImageMethods
    {

        internal static MagickImage OpenFile(string path)
        {
            try
            {
                MagickImage image = new(path);
                return image;
            }
            catch (MagickException e)
            {
                throw new Exception(e.Message);
            }
        }
        internal static void ResizeFile(MagickImage image)
        {
            try
            {
                MagickGeometry size = new(image.Width / 2, image.Height / 2)
                {
                    IgnoreAspectRatio = true
                };
                image.Resize(size);
            }
            catch (MagickException e)
            {
                throw new Exception(e.Message);
            }
        }

        internal static void CompressFile(MagickImage image, int compression)
        {
            try
            {
                image.Quality = compression;
            }
            catch (MagickException e)
            {
                throw new Exception(e.Message);
            }
        }

        internal static void SaveFile(MagickImage image, string path)
        {
            try
            {
                image.Write(path);
                image.Dispose();
            }
            catch (MagickException e)
            {
                throw new Exception(e.Message);
            }
        }

        internal static void SaveFileInDirectory(MagickImage image, string path,string name)
        {
            try
            {
                image.Write(path+name);
                image.Dispose();
            }
            catch (MagickException e)
            {
                throw new Exception(e.Message);
            }
        }

        internal static void CreateWatermark(MagickImage image, MagickImage watermark)
        {
            try
            {
                image.Composite(watermark, Gravity.Southeast, CompositeOperator.Over);
                image.Evaluate(Channels.Alpha, EvaluateOperator.Divide,10);
            }
            catch (MagickException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

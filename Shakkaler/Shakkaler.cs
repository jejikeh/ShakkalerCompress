using ImageMagick;
using System.Threading.Tasks;


namespace Shakkaler
{
    public static class Shakkal
    {
        public static void CompressAndOverrideFile(string openPath, string savePath, int compression)
        {
            try
            {
                MagickImage image = FileMethods.OpenFile(openPath);
                FileMethods.ResizeFile(image);
                FileMethods.CompressFile(image, compression);
                FileMethods.SaveFile(image, savePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void CompressAndSaveFile(string openPath, string savePath,string name, int compression)
        {
            try
            {
                MagickImage image = FileMethods.OpenFile(openPath);
                FileMethods.ResizeFile(image);
                FileMethods.CompressFile(image, compression);
                FileMethods.SaveFileInDirectory(image, savePath,name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void CompressAndSaveDirectoryFiles(string openDir, string saveDir, int compression)
        {
            string[] files = Directory.GetFiles($"{openDir}", "*.jpg");
            Console.WriteLine($"The number of Images {files.Length}");

            Parallel.For(0, files.Length, i => {
                string nameFile = i.ToString() + ".jp3g";
                CompressAndSaveFile(files[i], saveDir, nameFile, compression);
            });
        }

        public static void CompressAndSaveDirectoryFiles(string openDir, string saveDir,string startName ,int compression)
        {
            string[] files = Directory.GetFiles($"{openDir}", "*.jpg");
            Console.WriteLine($"The number of Images {files.Length}");

            /*
            for (int i = 0; i < files.Length; i++)
            {
                string nameFile = startName + i.ToString() + ".jpg";
                CompressAndSaveFile(files[i], saveDir, nameFile, compression);
            }
            */

            Parallel.For(0, files.Length, i => {
                string nameFile = startName + i.ToString() + ".jpg";
                CompressAndSaveFile(files[i], saveDir, nameFile, compression);
            });

        }
    }
}
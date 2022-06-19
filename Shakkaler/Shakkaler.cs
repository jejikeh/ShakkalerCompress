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
                MagickImage image = FileImageMethods.OpenFile(openPath);
                FileImageMethods.ResizeFile(image);
                FileImageMethods.CompressFile(image, compression);
                FileImageMethods.SaveFile(image, savePath);
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
                MagickImage image = FileImageMethods.OpenFile(openPath);
                FileImageMethods.ResizeFile(image);
                FileImageMethods.CompressFile(image, compression);
                FileImageMethods.SaveFileInDirectory(image, savePath,name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void CompressAndSaveFileWithWatermark(string openPath, string savePath, string name, int compression, string watermarkPath)
        {
            try
            {
                MagickImage image = FileImageMethods.OpenFile(openPath);
                MagickImage watermark = FileImageMethods.OpenFile(watermarkPath);
                FileImageMethods.ResizeFile(image);
                FileImageMethods.CreateWatermark(image, watermark);
                FileImageMethods.CompressFile(image, compression);
                FileImageMethods.SaveFileInDirectory(image, savePath, name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static async Task CompressAndSaveFileAsync(string openPath, string savePath, string name, int compression)
        {
            await Task.Run(async () =>
            {
                try
                {
                    MagickImage image = FileImageMethods.OpenFile(openPath);
                    FileImageMethods.ResizeFile(image);
                    FileImageMethods.CompressFile(image, compression);
                    FileImageMethods.SaveFileInDirectory(image, savePath, name);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    await CompressAndSaveFileAsync(openPath, savePath, name, compression);
                }
            });
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

            Parallel.For(0, files.Length, i => {
                string nameFile = startName + i.ToString() + ".jpg";
                CompressAndSaveFile(files[i], saveDir, nameFile, compression);
            });

        }

        public static void CompressAndSaveDirectoryFilesWithWatermark(string openDir, string saveDir, string startName, int compression,string watermarkPath)
        {
            string[] files = Directory.GetFiles($"{openDir}", "*.jpg");
            Console.WriteLine($"The number of Images {files.Length}");

            Parallel.For(0, files.Length, i => {
                string nameFile = startName + i.ToString() + ".jpg";
                CompressAndSaveFileWithWatermark(files[i], saveDir, nameFile, compression,watermarkPath);
            });

        }


        public async static Task CompressAudioFileAsync(string openFile, string saveFile)
        {
            await Task.Run(async () =>
            {
                try
                {
                    var currentDirectory = Directory.GetCurrentDirectory();
                    var basePath = currentDirectory.Split(new string[] { "\\bin" }, StringSplitOptions.None)[0];
                    FfmpegWrapper ffmpegWrapper = new();
                    ffmpegWrapper.ExecuteCommand($" -i {basePath + openFile} -c:a libmp3lame -b:a 8k -ac 2 {basePath + saveFile}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    await CompressAudioFileAsync(openFile,saveFile);
                }
            });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shakkaler
{
    public class FfmpegWrapper
    {
        private ProcessStartInfo m_proccesStartInfo = new();

        public FfmpegWrapper()
        {
            m_proccesStartInfo.CreateNoWindow = false;
            m_proccesStartInfo.UseShellExecute = false;
            m_proccesStartInfo.RedirectStandardOutput = true;
            var currentDirectory = Directory.GetCurrentDirectory();
            var basePath = currentDirectory.Split(new string[] { "\\bin" }, StringSplitOptions.None)[0];
            m_proccesStartInfo.FileName = Path.Combine(basePath, "ffmpeg\\ffmpeg.exe");
            
        }

        public void ExecuteCommand(string arguments)
        {
            m_proccesStartInfo.Arguments = arguments;

            Console.WriteLine(string.Format(
                "Executing \"{0}\" with arguments \"{1}\".\r\n",
                m_proccesStartInfo.FileName,
                m_proccesStartInfo.Arguments));

            try
            {
                using (Process? process = Process.Start(m_proccesStartInfo))
                {
                    while (!process.StandardOutput.EndOfStream)
                    {
                        string line = process.StandardOutput.ReadLine();
                        Console.WriteLine(line);
                    }

                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
    }
}

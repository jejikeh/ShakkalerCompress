using System.IO;
using Shakkaler;
using System.Diagnostics;

string openPath = @"C:\Users\jejik\Jejikeh\programming\.net\shakaly\ShakallerImageCompression\Shakaller\Shakkaler\Examples\PngCompress\images\";
string savePath = @"C:\Users\jejik\Jejikeh\programming\.net\shakaly\ShakallerImageCompression\Shakaller\Shakkaler\Examples\PngCompress\compressed\";
string logoPath = @"C:\Users\jejik\Jejikeh\programming\.net\shakaly\ShakallerImageCompression\Shakaller\Shakkaler\Examples\PngCompress\watermark.png";
//Shakkal.CompressAndSaveFile(openPath,savePath,10);


Stopwatch stopwatch = new Stopwatch();

stopwatch.Start();
Shakkal.CompressAndSaveDirectoryFilesWithWatermark(openPath,savePath,"hello",10,logoPath);
stopwatch.Stop();
Console.WriteLine($"Ellapsed ms : {stopwatch.ElapsedMilliseconds}");


// 2952


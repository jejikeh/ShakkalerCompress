using System.IO;
using Shakkaler;
using System.Diagnostics;

string openPath = @"yourpath\images\";
string savePath = @"yourpath\compressed\";

//Shakkal.CompressAndSaveFile(openPath,savePath,10);


Stopwatch stopwatch = new Stopwatch();

stopwatch.Start();
Shakkal.CompressAndSaveDirectoryFiles(openPath,savePath,"hello",10);
stopwatch.Stop();
Console.WriteLine($"Ellapsed ms : {stopwatch.ElapsedMilliseconds}");


// 2952


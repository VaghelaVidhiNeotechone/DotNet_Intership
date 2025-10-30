using System;
using Ionic.Zip; 
namespace DotNetZipDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating archive.zip...");
            using (ZipFile zip = new ZipFile())
            {
                zip.AddFile("file1.txt", "");
                zip.AddFile("file2.txt", "");
                zip.Save("archive.zip");
            }
            Console.WriteLine("archive.zip created!\n");
            Console.WriteLine("Extracting archive.zip to extracted-folder...");
            using (ZipFile zip = ZipFile.Read("archive.zip"))
            {
                zip.ExtractAll("extracted-folder");
            }
            Console.WriteLine("Files extracted to extracted-folder!\n");
            Console.WriteLine("Adding new-file.txt to existing archive...");
            System.IO.File.WriteAllText("new-file.txt", "This is a new file to add.");
            using (ZipFile zip = ZipFile.Read("archive.zip"))
            {
                zip.AddFile("new-file.txt", "");
                zip.Save();
            }
            Console.WriteLine("new-file.txt added to archive.zip!\n");
            Console.WriteLine("Creating encrypted-archive.zip...");
            using (ZipFile zip = new ZipFile())
            {
                zip.Password = "secure-password";
                zip.AddFile("file1.txt", "");
                zip.Save("encrypted-archive.zip");
            }
            Console.WriteLine("encrypted-archive.zip created!\n");
            Console.WriteLine("Extracting encrypted zip...");
            using (ZipFile zip = ZipFile.Read("encrypted-archive.zip"))
            {
                zip.Password = "secure-password";
                zip.ExtractAll("extracted-encrypted");
            }
            Console.WriteLine("Encrypted zip extracted!\n");

            Console.WriteLine("All operations complete. Press any key to exit.");
            Console.ReadKey();
        }
    }
}

using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipExtractor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the ZIP file (you can use full path if needed)
                string zipPath = "archive.zip";

                // Folder to extract files into
                string extractFolder = "extracted-folder";

                // Read and extract
                using (ZipFile zip = ZipFile.Read(zipPath))
                {
                    zip.ExtractAll(extractFolder, ExtractExistingFileAction.OverwriteSilently);
                    zip.AddFile("new.txt", "");  // Add to root
                    zip.Save();

                    zip.Password = "secure-password";
                    zip.ExtractAll("secure-folder", ExtractExistingFileAction.OverwriteSilently);
                }

                Console.WriteLine("Extraction completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine(); // Pause console
        }
    }
}

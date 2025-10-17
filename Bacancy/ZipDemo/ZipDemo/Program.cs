using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;

namespace ZipDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    zip.AddFile("First.txt", ""); // Add to root
                    zip.AddFile("Second.txt", "");
                    zip.Save("archive.zip"); // Create archive.zip

                    zip.Password = "secure-password";     // Set a password
                    zip.Encryption = EncryptionAlgorithm.WinZipAes256; // Optional: Set encryption
                    zip.AddFile("Add.txt", "");
                    zip.Save("encrypted-archive.zip");
                }

                Console.WriteLine("Zip file created successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

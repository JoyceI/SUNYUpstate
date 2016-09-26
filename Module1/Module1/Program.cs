using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Module1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Writing a file");
            FileStream theFile = File.Open
                (@"C:\Lab\File1.txt",FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(theFile);
            var input = Directory.GetFiles(
                @"C:\Lab",
                "*.txt",
                SearchOption.AllDirectories);
        
            foreach (var ptr in input)
            {
                 writer.WriteLine(ptr);
                 writer.WriteLine(
                     "Dir:{0}, FileName:{1}, FileExt:{2}",
                     Path.GetDirectoryName(ptr),
                     Path.GetFileNameWithoutExtension(ptr),
                     Path.GetExtension(ptr)
                     );
            }
            writer.Close();
            theFile.Close();
            Console.ReadLine();
        }
    }
}

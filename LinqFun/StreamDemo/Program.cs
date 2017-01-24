using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //ByteArrayWriteStreamRead();
            string[] names = { "Shannon", "William", "Jason", "Barb", "Iain", "Teresa", "Mary", "Billie Jo", "Jordan", "Michelle" };

            string output = String.Join(",", names);
            //construct a stream writer from file
            StreamWriter sw = new StreamWriter(@"C:\Lab\file2.txt");
            // you can also construct a stream writer from memorystream
            MemoryStream ms = new MemoryStream(100);
            StreamWriter sw2 = new StreamWriter(ms);

            sw.WriteLine(output);
            sw2.WriteLine(output);
            sw.Flush();
            sw2.Flush();
            Console.ReadLine();


        }

        private static void ByteArrayWriteStreamRead()
        {
            FileStream fs = File.Open(@"C:\Lab\file1.bin", FileMode.OpenOrCreate);
            byte[] somedata = Encoding.ASCII.GetBytes("Hello World");
            fs.Write(somedata, 0, somedata.Length);
            fs.Close();

            StreamReader reader = File.OpenText(@"C:\Lab\file1.bin");
            Console.WriteLine(reader.ReadLine());
        }
    }
}

using HRLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLibTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> connStrings = new Dictionary<string, string>();
            char[] splitter = { '=' };
            foreach ( string line in File.ReadAllLines(@"c:\Lab\ConnString.txt"))
            {
                string[] KV = line.Split(splitter,2);
                connStrings.Add(KV[0], KV[1]);
            }

            HRDataAccess util =
                new HRDataAccess(
                    connStrings["HR"]);
            HR myDS = util.GetFullHRDataSet();
            Console.WriteLine(myDS.EMPLOYEES.Count);
            myDS.WriteXml(@"C:\\Lab\myDS.xml");
        }
    }
}

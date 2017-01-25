using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportTool.RS;
using System.Net;
using System.IO;
namespace ReportTool
{
    class Program
    {
        static void Main(string[] args)
        {
            string report = "/SUNY Practice/CustomerList";
            string format = "PDF";
            string fileOut = @"C:\Lab\test.pdf";
            
            WebClient client = new WebClient();
            
            string url = string.Format("http://ssrs.objectmage.com/reportserver?{0}&rs:format={1}",
                report,
                format);

            client.Credentials = new NetworkCredential("student", "password");
            byte[] file = client.DownloadData(url);
            File.WriteAllBytes(fileOut, file);

            

 
            



        }
    }
}

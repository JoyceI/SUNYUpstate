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
            
            //@"C:\Lab\test3.xml";
            //string report = "/SUNY Practice/CustomerList";
            //string format = "xml";
            //string fileOut = @"C:\Lab\test3.xml";
            try
            {
                string serverName = args[0];
                string report = args[1];
                string format = args[2];
                string fileOut = args[3];
                string username = args[4];
                string password = args[5];

                WebClient client = new WebClient();

                string url = string.Format("http://{0}/reportserver?{1}&rs:format={2}",
                    serverName,
                    report,
                    format);

                client.Credentials = new NetworkCredential(username, password);
                byte[] file = client.DownloadData(url);
                File.WriteAllBytes(fileOut, file);
            }
            catch (Exception)
            {
                Console.WriteLine("Sample Usage: \n ReportTool.exe ssrs.objectmage.com \"/SUNY Practice/CustomerList\" PDF \"c:\\Lab\\Report.Pdf\" student Pa$$w0rd1 ");
            }
            
            

 
            



        }
    }
}

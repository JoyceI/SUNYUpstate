using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SSRSRenderWebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string reportName = "/CubeReport-Victor/ABC";
            string format = "EXCEL";
            string fileOut = @"C:\Lab\test.xls";
            WebClient client = new WebClient();
            string url = string.Format("http://192.168.10.121/reportserver?{0}&rs:format={1}",
                reportName,
                format);
            
            client.UseDefaultCredentials = true;
            byte[] file = client.DownloadData(url);
            File.WriteAllBytes(fileOut, file);
        }
    }
}

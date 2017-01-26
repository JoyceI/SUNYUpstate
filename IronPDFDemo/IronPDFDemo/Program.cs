using IronPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronPDFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlToPdf HtmlToPdf = new IronPdf.HtmlToPdf();
            PdfResource PDF = HtmlToPdf.RenderUrlAsPdf(new Uri("http://amazon.com"));
            PDF.SaveAs(@"File.Pdf");
        }
    }
}

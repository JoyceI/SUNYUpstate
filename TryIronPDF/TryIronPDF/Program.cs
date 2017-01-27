using IronPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryIronPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlToPdf HtmlToPdf = new IronPdf.HtmlToPdf();
            PdfResource PDF = HtmlToPdf.RenderUrlAsPdf(new Uri("http://ironpdf.com"));
            PDF.SaveAs(@"File.Pdf");
        }
    }
}

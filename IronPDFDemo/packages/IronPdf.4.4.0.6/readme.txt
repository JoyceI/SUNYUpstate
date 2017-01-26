PDF Generation for .Net Developers
IronPDF is the fun, stable C# PDF Library. It makes use of HTML and CSS skills that developers already have to  generating PDFs.

It can generate PDF Files from HTML5,XHTML,Javascript and CSS as well as Jpg, Png, Gif , Bmp and, Tiff and SVG images.


C# Code Example - HTML to PDF:
----------------------------------
        using IronPdf;
        //
        HtmlToPdf HtmlToPdf = new IronPdf.HtmlToPdf();
        PdfResource PDF = HtmlToPdf.RenderHtmlAsPdf(@"<h1>Hello World</h1>");
        PDF.SaveAs(@"Path\File.Pdf");        



C# Code Example - URL to PDF:
----------------------------------
        using IronPdf;
        //
        HtmlToPdf HtmlToPdf = new IronPdf.HtmlToPdf();
        PdfResource PDF = HtmlToPdf.RenderUrlAsPdf(new Uri("http://ironpdf.com"));
        PDF.SaveAs(@"Path\File.Pdf");


C# ASP.NET Code Example - ASPX:

      using IronPdf;
       //...
      private void Form1_Load(object sender, EventArgs e)
      {
      AspxToPdf.RenderThisPageAsPDF();      
      //Changes the ASPX output into a pdf instead of html   
      }
      
      
Print Options:
----------------------------------
        HtmlToPdf HtmlToPdf = new IronPdf.HtmlToPdf();
        HtmlToPdf.PrintOptions.DPI = 300;
        HtmlToPdf.PrintOptions.PaperSize = PdfPrintOptions.PdfPaperSize.A4;
        HtmlToPdf.PrintOptions.EnableJavaScript = true;
        HtmlToPdf.PrintOptions.CssMediaType =  PdfPrintOptions.PdfCssMediaType.Screen;
        HtmlToPdf.PrintOptions.Header = "{page} of {total-pages}";
        HtmlToPdf.PrintOptions.GrayScale = false;
        //.. many more options available at http://ironpdf.com/c%23-pdf-documentation/html/N_IronPdf.htm

Homepage & Documentation: http://ironpdf.com


using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Codaxy.WkHtmlToPdf.Tests
{
	class Program
	{
		static void Main(string[] args)
		{
            Console.InputEncoding = Encoding.UTF8;

			PdfConvert.Environment.Debug = false;
            //PdfConvert.ConvertHtmlToPdf(new PdfDocument { Url = "http://www.codaxy.com" }, new PdfOutput
            //{
            //    OutputFilePath = "codaxy.pdf"
            //});
            //PdfConvert.ConvertHtmlToPdf(new PdfDocument 
            //{ 
            //    Url = "http://www.codaxy.com",
            //    HeaderLeft = "[title]",
            //    HeaderRight = "[date] [time]",
            //    FooterCenter = "Page [page] of [topage]"
            
            //}, new PdfOutput
            //{
            //    OutputFilePath = "codaxy_hf.pdf"
            //});
            //PdfConvert.ConvertHtmlToPdf(new PdfDocument { Url = "-", Html = "<html><h1>test</h1></html>"}, new PdfOutput
            //{
            //    OutputFilePath = "inline.pdf"
            //});
            //PdfConvert.ConvertHtmlToPdf(new PdfDocument { Url = "-", Html = "<html><h1>測試</h1></html>" }, new PdfOutput
            //{
            //    OutputFilePath = "inline_cht.pdf"
            //});


            PdfDocument p = new PdfDocument();
            p.Url = @"D:\Proyectos personales\wkhtmltopdf-master\Propia\Factura.html"; //"-";
            //p.Html = "<p><strong><span style=\"font-size: medium;\">HTML Improved Code</span></strong></p>"+
            //            "<p>Improved HTML editor with more features like:</p>"+
            //            "<p>Code highlighting</p>"+
            //            "<p>Auto-indenting</p>"+
            //            "<p>Undo/Redo</p>"+
            //            "<p>Auto set of the cursor in the code relative to the real view</p>"+
            //            "<p>Line numbers</p>";
            PdfConvert.ConvertHtmlToPdf(p, new PdfOutput() { OutputFilePath = "testAbraham.pdf" });


            //PdfConvert.ConvertHtmlToPdf("http://tweakers.net", "tweakers.pdf");
        }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Web.Business.Services
{
    public static class HtmlToPdfService
    {
        public static void ConvertHtmlToPdf()
        {
            try
            {
                //String html = File.ReadAllText("www.elmbergdevelopment.se/lunch/");
                var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                //htmlToPdf.GeneratePdf(html, null, "C:/temp/lunchToPdf.pdf");
                htmlToPdf.GeneratePdfFromFile("http://www.nrecosite.com/", null, "C:/temp/htmlToPdf.pdf");             
            }
            catch (Exception e)
            {             
                throw;
            }           
        }
    }
}
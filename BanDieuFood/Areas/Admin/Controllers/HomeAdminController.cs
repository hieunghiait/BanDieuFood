using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanDieuFood.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/Home
  
        public ActionResult Index()
        {
            if (Session["Email"] != null)
            {
                return View("Index", "HomeAdmin");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

            
        }
        //public ActionResult ExportFilePDF()
        //{// instantiate a html to pdf converter object
        //    HtmlToPdf converter = new HtmlToPdf();

        //    // set converter options
        //    converter.Options.PdfPageSize = PdfSize.A4;
        //    converter.Options.PdfPageOrientation = pdfOrientation;
        //    converter.Options.WebPageWidth = webPageWidth;
        //    converter.Options.WebPageHeight = webPageHeight;

        //    // create a new pdf document converting an html string
        //    PdfDocument doc = converter.ConvertHtmlString(htmlString, baseUrl);

        //    // save pdf document
        //    doc.Save(Response, false, "Sample.pdf");

        //    // close pdf document
        //    doc.Close();
        //    return View();

        //}
        public ActionResult TestPage()
        {
            
            return View();
        }
    }
}
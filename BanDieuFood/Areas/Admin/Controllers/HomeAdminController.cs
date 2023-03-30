using System;
using System.Collections.Generic;
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
        public ActionResult TestPage()
        {
            
            return View();
        }
    }
}
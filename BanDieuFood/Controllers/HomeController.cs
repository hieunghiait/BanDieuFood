using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanDieuFood.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();

        }
        public ActionResult SingleNews()
        {
            return View();
        }
        public ActionResult New()
        {
            return View();

        }
        public ActionResult News()
        {
            return View();

        }
        public ActionResult Contact()
        {
            return View();

        }
    }
}
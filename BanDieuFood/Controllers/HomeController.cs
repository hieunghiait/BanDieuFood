﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanDieuFood.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult About()
        {


            return View();
        }
        public ActionResult Error404()
        {


            return View();
        }
        public ActionResult Contact() 
        {
            return View();
        }
    }
}
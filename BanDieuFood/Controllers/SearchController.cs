using BanDieuFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanDieuFood.Controllers
{
    public class SearchController : Controller
    {
        private readonly BanDieuDBContext _context;
        public SearchController(BanDieuDBContext context)
        {
            _context = context;
        }
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult FindProduct(string keyword)
        {
            List<Product> ls = new List<Product>();
            if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
            {
                return PartialView("ListProductSearchPartialView", null);
            }
            ls = _context.Products
                                  .Where(x => x.ProductName.Contains(keyword))
                                  .OrderByDescending(x => x.ProductName)
                                  .Take(10)
                                  .ToList();
            if (ls == null)
            {
                return PartialView("ListProductSearchPartialView", null);
            }
            else
            {
                return PartialView("ListProductSearchPartialView", ls);
            }
        }
    }
}
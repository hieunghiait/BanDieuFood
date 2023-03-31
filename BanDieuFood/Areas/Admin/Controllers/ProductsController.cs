using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BanDieuFood.Models;
using Microsoft.Ajax.Utilities;

namespace BanDieuFood.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private BanDieuDBContext db = new BanDieuDBContext();

        // GET: Admin/Products

        public ActionResult Index(string searchString, string sortOrder)
        {
            // 1. Thêm biến NameSortParm để biết trạng thái sắp xếp tăng, giảm ở View
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = String.IsNullOrEmpty(sortOrder) ? "price_desc" : "price_asc";
            ViewBag.IDSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "id_asc";
            IQueryable <Product> products = db.Products.Include(p => p.Category);
     
                switch (sortOrder)
                {
                    case "name_desc":
                        {
                            products = products.OrderByDescending(p => p.ProductName);
                            break;
                        }
                    case "price_desc":
                        {
                            products = products.OrderByDescending(p => p.Price);
                            break;
                        }
                    case "price_asc":
                        {
                            products = products.OrderBy(p => p.Price);
                            break;
                        }
                    case "id_desc":
                        {
                            products = products.OrderByDescending(p => p.ProductID);
                            break;
                        }
                    case "id_asc":
                        {
                            products = products.OrderBy(p => p.ProductID);
                            break;
                        }
                    //mặc định sắp sếp giá tăng dần
                    default:
                        {
                            products = products.OrderBy(p => p.ProductName);
                            break;
                        }
                }
            ViewBag.KeyWord = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                products = products.Where(c => c.ProductName.ToLower().Contains(searchString));
            }
            return View(products.ToList());
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,Image,Quantity,Price,Unit,CategoryID")] Product product, HttpPostedFileBase fileUpload)
        {
            var guid = Guid.NewGuid().ToString();
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["upload"];
                if (fileUpload != null && file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/AssetsAdmin/img"), guid + filename);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.Thongbao = "Vui lòng chọn ảnh";
                    } else
                    {
                        file.SaveAs(path);
                        product.Image = guid + filename;
                    }  
                }
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index", "Products");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,Image,Quantity,Price,Unit,CategoryID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

using BanDieuFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanDieuFood.Controllers
{
    public class CartController : Controller
    {
        private readonly BanDieuDBContext _context;

        public CartController(BanDieuDBContext context)
        {
            _context = context;

        }
        // GET: Cart
        public List<CartItem> GioHang
        {
            get
            {
                List<CartItem> Cart = (List<CartItem>)Session["giohang"];
                if (Cart == default(List<CartItem>))
                {
                    Cart = new List<CartItem>();
                }
                return Cart;
            }
        }
        public ActionResult AddToCart(int productID, int? amount)
        {
            List<CartItem> cart = GioHang;

            try
            {
                //Them san pham vao gio hang
                CartItem item = cart.SingleOrDefault(p => p.product.ProductID == productID);
                if (item != null) // da co => cap nhat so luong
                {
                    item.amount = item.amount + amount.Value;
                    //luu lai session
                    List<CartItem> Cart1 = (List<CartItem>)Session["giohang"];
                }
                else
                {
                    Product hh = _context.Products.SingleOrDefault(p => p.ProductID == productID);
                    item = new CartItem
                    {
                        amount = amount.HasValue ? amount.Value : 1,
                        product = hh
                    };
                    cart.Add(item);
                }

                //Luu lai Session
                List<CartItem> Cart = (List<CartItem>)Session["giohang"];

                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
        public ActionResult UpdateCart(int productID, int? amount)
        {
            //Lay gio hang ra de xu ly
            List<CartItem> Cart = (List<CartItem>)Session["giohang"];
            try
            {
                if (Cart != null)
                {
                    CartItem item = Cart.SingleOrDefault(p => p.product.ProductID == productID);
                    if (item != null && amount.HasValue) // da co -> cap nhat so luong
                    {
                        item.amount = amount.Value;
                    }
                    List<CartItem> Cart1 = (List<CartItem>)Session["giohang"];

                }
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
        public ActionResult Remove(int productID)
        {

            try
            {
                List<CartItem> gioHang = GioHang;
                CartItem item = gioHang.SingleOrDefault(p => p.product.ProductID == productID);
                if (item != null)
                {
                    gioHang.Remove(item);
                }
                //luu lai session
                List<CartItem> Cart = (List<CartItem>)Session["giohang"];
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            return View();
        }
    }
}
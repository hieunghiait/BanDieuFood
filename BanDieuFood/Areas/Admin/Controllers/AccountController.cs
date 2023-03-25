using BanDieuFood.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BanDieuFood.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private BanDieuDbContext _dbContext = new BanDieuDbContext();

        // GET: Admin/Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(User model)
        {
            try
            {
                using (_dbContext)
                {
                    bool IsValidUser = _dbContext.Users.Any(user => user.UserName.ToLower() ==
                         model.UserName.ToLower() && user.Password == model.Password);
                    if (IsValidUser)
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, false);
                        return RedirectToAction("Index", "HomeAdmin");
                    }
                    ModelState.AddModelError("", "Tên tài khoản hoặc mật khẩu không đúng");
                    return View();
                }
            }
            catch(Exception ex) 
            {
                ModelState.AddModelError("", $"Có lỗi xảy ra: {ex.Message}");
                return View();
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User model) 
        {
            //Nếu model tồn tại
            if (ModelState.IsValid) 
            {
                
            }
            return View();
        }
    }
}
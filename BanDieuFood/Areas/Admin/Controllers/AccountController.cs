using BanDieuFood.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace BanDieuFood.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private BanDieuDBContext _dbContext = new BanDieuDBContext();
        
        // GET: Admin/Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                using (_dbContext = new BanDieuDBContext())
                {
                    try
                    {
                        var check = _dbContext.Users.Where(a => a.Email.Equals(model.Email) && a.Password.Equals(model.Password)).FirstOrDefault();

                        if (check != null)
                        {
                            Session["UserName"] = check.UserName.ToString();
                            return RedirectToAction("TestPage", "HomeAdmin");
                        }
                        else
                        {

                        }

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            
            Session.Remove("UserName");
            Session.Abandon();
            return View("Login", "Account");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User model) 
        {
            _dbContext = new BanDieuDBContext();
            if (ModelState.IsValid)
            {

                var checkUser = _dbContext.Users.FirstOrDefault(s => s.Email == model.Email);
                if (checkUser == null)
                {
                    _dbContext.Configuration.ValidateOnSaveEnabled = false;
                    var newUser = new User
                    {
                        FullName= model.FullName,   
                        Email = model.Email,    
                        UserName = model.UserName,  
                        Password= model.Password,   
                        Address= model.Address,
                        Phone= model.Phone, 
                    };
                    //Add model 
                    _dbContext.Users.Add(model);
                    //Lưu thay đổi 
                    _dbContext.SaveChanges();
                    return RedirectToAction("TestPage", "HomeAdmin");
                }
                else
                {
                    ViewBag.error = "Email đã tồn tại trong CSDL";
                    return View();
                }
            }
            else
                {
                    ModelState.AddModelError(string.Empty, "Email đã tồn tại");
                }
            return View("Register", "Account");
            }
        }
        //public static string GetMD5(string str)
        //{
        //    MD5 md5 = new MD5CryptoServiceProvider();
        //    byte[] fromData = Encoding.UTF8.GetBytes(str);
        //    byte[] targetData = md5.ComputeHash(fromData);
        //    string byte2String = null;

        //    for (int i = 0; i < targetData.Length; i++)
        //    {
        //        byte2String += targetData[i].ToString("x2");

        //    }
        //    return byte2String;
        //}

    }
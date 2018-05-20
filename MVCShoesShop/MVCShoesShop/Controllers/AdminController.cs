using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCShoesShop.Models;

namespace MVCShoesShop.Controllers
{
    public class AdminController : Controller
    {
        ShoesShopEntities db = new ShoesShopEntities();
        // GET: Admin
        //Trang đăng nhập
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var tendn = collection["username"];
            var matkhau = collection["password"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                DANG_NHAP ad = db.DANG_NHAP.SingleOrDefault(n => n.Username == tendn && n.Pass == matkhau);
                if (ad != null)
                {
                    Session["Taikhoanadmin"] = ad;
                    return RedirectToAction("Shoes", "SanPham");
                }
                else
                    ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }
        //Trang đăng xuất
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Shoes", "SanPham");
        }
    }
}
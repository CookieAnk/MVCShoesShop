using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCShoesShop.Models;

namespace MVCShoesShop.Controllers
{
    public class UserController : Controller
    {
        ShoesShopEntities db = new ShoesShopEntities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        //Trang đăng ký
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangky(FormCollection collection, KHACH_HANG kh)
        {
            var hoten = collection["HotenKH"];
            var tendn = collection["TenDN"];
            var matkhau = collection["Matkhau"];
            var matkhaunhaplai = collection["Matkhaunhaplai"];
            var diachi = collection["Diachi"];
            var email = collection["Email"];
            var dienthoai = collection["Dienthoai"];
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Name is require";
            }
            else if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "ID is require";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Password is require";
            }
            else if (String.IsNullOrEmpty(matkhaunhaplai) || matkhaunhaplai != matkhau)
            {
                ViewData["Loi4"] = "Pass doesn't match";
            }
            else if (String.IsNullOrEmpty(email))
            {
                ViewData["Loi5"] = "Email can't empty";
            }
            else if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi6"] = "Phone can't empty";
            }
            else
            {
                kh.TenKH = hoten;
                kh.IDLogin = tendn;
                kh.Pass = matkhau;
                kh.Email = email;
                kh.DiaChi = diachi;
                kh.SDT = dienthoai;
                db.KHACH_HANG.Add(kh);
                db.SaveChanges();
                return RedirectToAction("Dangnhap");
            }
            return this.DangKy();
        }

        // Đăng nhập
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var tendn = collection["TenDN"];
            var matkhau = collection["Matkhau"];
            var hoten = collection["HoTen"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "You must enter ID";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "You must enter password";
            }
            else
            {
                KHACH_HANG kh = db.KHACH_HANG.SingleOrDefault(n => n.IDLogin == tendn && n.Pass == matkhau);
                if (kh != null)
                {
                    //ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";
                    Session["Taikhoan"] = kh;
                    Session["HoTen"] = kh.TenKH;
                    return RedirectToAction("GioHang", "GioHang");
                }
                else
                    ViewBag.Thongbao = "Your ID or Password isn't right";
            }
            return View();
        }

        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("Index","Shop");
        }

        public ActionResult DonDatHang()
        {
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "User");
            }
            if (Session["Giohang"] == null)
            {
                return RedirectToAction("Index", "Shop");
            }
            return View();
        }
    }
}
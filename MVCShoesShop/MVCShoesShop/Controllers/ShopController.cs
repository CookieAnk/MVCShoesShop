using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCShoesShop.Models;
using PagedList;
using PagedList.Mvc;

namespace MVCShoesShop.Controllers
{
    public class ShopController : Controller
    {
        ShoesShopEntities db = new ShoesShopEntities();
        // GET: Shop
        // Trang Index
        public ActionResult Index(int? page, string searchString)
        {
            var sp = from p in db.SAN_PHAM select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                sp = sp.Where(s => s.TenSP.Contains(searchString));
            }
            ViewBag.SeachString = searchString;
            //tạo bien so trang
            int pageNumber = (page ?? 1);
            //tao bien quy dinh so san pham tren moi trang
            int pageSize = 12;
            return View(sp.ToList().OrderBy(n => n.MaSP).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult loaiSP()
        {
            var cate = from cd in db.LOAI_SAN_PHAM select cd;
            return PartialView(cate);
        }
        public ActionResult spTheoLoai(int id)
        {
            var product = from s in db.SAN_PHAM where s.MaLoaiSP == id select s;
            return View(product);
        }
        //Trang details
        public ActionResult Details(int id)
        {
            var product = from p in db.SAN_PHAM
                          where p.MaSP == id
                          select p;
            return View(product.Single());
        }
        // Trang About
        public ActionResult AboutUs()
        {
            return View();
        }
    }
}
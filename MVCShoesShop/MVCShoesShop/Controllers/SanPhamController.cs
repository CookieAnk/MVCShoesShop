using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCShoesShop.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace MVCShoesShop.Controllers
{
    public class SanPhamController : Controller
    {
        private ShoesShopEntities db = new ShoesShopEntities();

        // GET: Admin
        public ActionResult Shoes(int? page)
        {
            var sAN_PHAM = db.SAN_PHAM.Include(s => s.LOAI_SAN_PHAM);
            Session["SP"] = sAN_PHAM;
            if (Session["Taikhoanadmin"] == null || Session["Taikhoanadmin"].ToString() == "")
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Session["SP"] == null)
            {
                return RedirectToAction("Shoes", "SanPham");
            }
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            return View(db.SAN_PHAM.ToList().OrderBy(n => n.MaSP).ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            Session["SP"] = sAN_PHAM;
            if (Session["Taikhoanadmin"] == null || Session["Taikhoanadmin"].ToString() == "")
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Session["SP"] == null)
            {
                return RedirectToAction("Shoes", "SanPham");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (sAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(sAN_PHAM);
        }

        // GET: Admin/Create
        [HttpGet]
        public ActionResult Create()
        {
            if (Session["Taikhoanadmin"] == null || Session["Taikhoanadmin"].ToString() == "")
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Session["SP"] == null)
            {
                return RedirectToAction("Shoes", "SanPham");
            }
            ViewBag.MaLoaiSP = new SelectList(db.LOAI_SAN_PHAM, "MaLoaiSP", "TenLoai");
            return View();
        }
        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(/*[Bind(Include = "MaSP,TenSP,MaLoaiSP,SoLuongCon,DonGia,Images")]*/SAN_PHAM sAN_PHAM, HttpPostedFileBase fileUpload)
        {
            ViewBag.MaLoaiSP = new SelectList(db.LOAI_SAN_PHAM, "MaLoaiSP", "TenLoai", sAN_PHAM.MaLoaiSP);
            if (fileUpload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh bìa";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    // Lưu tên file, lưu ý bổ sung thư viện using System.IO;
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    // Lưu đường dẫn file
                    var path = Path.Combine(Server.MapPath("~/images"), fileName);
                    // Kiễm tra hình ảnh tồn tại
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                    }
                    else
                    {
                        //Lưu hình ảnh vào đường dẫn
                        fileUpload.SaveAs(path);
                    }
                    sAN_PHAM.Images = fileName;
                    // Lưu vào CSDL
                    db.SAN_PHAM.Add(sAN_PHAM);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Shoes");
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Taikhoanadmin"] == null || Session["Taikhoanadmin"].ToString() == "")
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Session["SP"] == null)
            {
                return RedirectToAction("Shoes", "SanPham");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            if (sAN_PHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiSP = new SelectList(db.LOAI_SAN_PHAM, "MaLoaiSP", "TenLoai", sAN_PHAM.MaLoaiSP);
            return View(sAN_PHAM);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,MaLoaiSP,SoLuongCon,DonGia,Images")] SAN_PHAM sAN_PHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sAN_PHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiSP = new SelectList(db.LOAI_SAN_PHAM, "MaLoaiSP", "TenLoai", sAN_PHAM.MaLoaiSP);
            return View(sAN_PHAM);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Taikhoanadmin"] == null || Session["Taikhoanadmin"].ToString() == "")
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Session["SP"] == null)
            {
                return RedirectToAction("Shoes", "SanPham");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            if (sAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(sAN_PHAM);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            db.SAN_PHAM.Remove(sAN_PHAM);
            db.SaveChanges();
            return RedirectToAction("Shoes");
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

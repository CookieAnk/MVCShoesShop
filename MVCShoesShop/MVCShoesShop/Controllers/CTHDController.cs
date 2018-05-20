using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCShoesShop.Models;

namespace MVCShoesShop.Controllers
{
    public class CTHDController : Controller
    {
        private ShoesShopEntities db = new ShoesShopEntities();

        // GET: CTHD
        public ActionResult Index()
        {
            var cT_HOA_DON = db.CT_HOA_DON.Include(c => c.HOA_DON).Include(c => c.SAN_PHAM);
            Session["cthd"] = cT_HOA_DON;
            if (Session["Taikhoanadmin"] == null || Session["Taikhoanadmin"].ToString() == "")
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Session["cthd"] == null)
            {
                return RedirectToAction("Index", "CTHD");
            }
            return View(cT_HOA_DON.ToList());
        }

        // GET: CTHD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HOA_DON cT_HOA_DON = db.CT_HOA_DON.SingleOrDefault(n => n.MaHD == id);
            if (cT_HOA_DON == null)
            {
                return HttpNotFound();
            }
            return View(cT_HOA_DON);
        }

        // GET: CTHD/Create
        public ActionResult Create()
        {
            ViewBag.MaHD = new SelectList(db.HOA_DON, "MaHD", "HinhThucThanhToan");
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "TenSP");
            return View();
        }

        // POST: CTHD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTHD,MaHD,MaSP,SoLuong,DonGia,ThanhTien")] CT_HOA_DON cT_HOA_DON)
        {
            if (ModelState.IsValid)
            {
                db.CT_HOA_DON.Add(cT_HOA_DON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHD = new SelectList(db.HOA_DON, "MaHD", "HinhThucThanhToan", cT_HOA_DON.MaHD);
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "TenSP", cT_HOA_DON.MaSP);
            return View(cT_HOA_DON);
        }

        // GET: CTHD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HOA_DON cT_HOA_DON = db.CT_HOA_DON.SingleOrDefault(n => n.MaHD == id);
            if (cT_HOA_DON == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHD = new SelectList(db.HOA_DON, "MaHD", "HinhThucThanhToan", cT_HOA_DON.MaHD);
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "TenSP", cT_HOA_DON.MaSP);
            return View(cT_HOA_DON);
        }

        // POST: CTHD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTHD,MaHD,MaSP,SoLuong,DonGia,ThanhTien")] CT_HOA_DON cT_HOA_DON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_HOA_DON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHD = new SelectList(db.HOA_DON, "MaHD", "HinhThucThanhToan", cT_HOA_DON.MaHD);
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "TenSP", cT_HOA_DON.MaSP);
            return View(cT_HOA_DON);
        }

        // GET: CTHD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HOA_DON cT_HOA_DON = db.CT_HOA_DON.SingleOrDefault(n => n.MaHD == id);
            if (cT_HOA_DON == null)
            {
                return HttpNotFound();
            }
            return View(cT_HOA_DON);
        }

        // POST: CTHD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CT_HOA_DON cT_HOA_DON = db.CT_HOA_DON.Find(id);
            db.CT_HOA_DON.Remove(cT_HOA_DON);
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

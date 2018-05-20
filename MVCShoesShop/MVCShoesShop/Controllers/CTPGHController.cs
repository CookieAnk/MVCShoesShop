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
    public class CTPGHController : Controller
    {
        private ShoesShopEntities db = new ShoesShopEntities();

        // GET: CTPGH
        public ActionResult Index()
        {
            var cT_PHIEU_GIAO_HANG = db.CT_PHIEU_GIAO_HANG.Include(c => c.PHIEU_GIAO_HANG).Include(c => c.SAN_PHAM);
            Session["ctpgh"] = cT_PHIEU_GIAO_HANG;
            if (Session["Taikhoanadmin"] == null || Session["Taikhoanadmin"].ToString() == "")
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Session["ctpgh"] == null)
            {
                return RedirectToAction("Index", "CTPGH");
            }
            return View(cT_PHIEU_GIAO_HANG.ToList());
        }

        // GET: CTPGH/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_PHIEU_GIAO_HANG cT_PHIEU_GIAO_HANG = db.CT_PHIEU_GIAO_HANG.SingleOrDefault(n => n.MaPGH == id);
            if (cT_PHIEU_GIAO_HANG == null)
            {
                return HttpNotFound();
            }
            return View(cT_PHIEU_GIAO_HANG);
        }

        // GET: CTPGH/Create
        public ActionResult Create()
        {
            ViewBag.MaPGH = new SelectList(db.PHIEU_GIAO_HANG, "MaPGH", "GhiChu");
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "TenSP");
            return View();
        }

        // POST: CTPGH/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPGH,MaSP,SoLuong,DonGia,ThanhTien")] CT_PHIEU_GIAO_HANG cT_PHIEU_GIAO_HANG)
        {
            if (ModelState.IsValid)
            {
                db.CT_PHIEU_GIAO_HANG.Add(cT_PHIEU_GIAO_HANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPGH = new SelectList(db.PHIEU_GIAO_HANG, "MaPGH", "GhiChu", cT_PHIEU_GIAO_HANG.MaPGH);
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "TenSP", cT_PHIEU_GIAO_HANG.MaSP);
            return View(cT_PHIEU_GIAO_HANG);
        }

        // GET: CTPGH/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_PHIEU_GIAO_HANG cT_PHIEU_GIAO_HANG = db.CT_PHIEU_GIAO_HANG.SingleOrDefault(n => n.MaPGH == id);
            if (cT_PHIEU_GIAO_HANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPGH = new SelectList(db.PHIEU_GIAO_HANG, "MaPGH", "GhiChu", cT_PHIEU_GIAO_HANG.MaPGH);
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "TenSP", cT_PHIEU_GIAO_HANG.MaSP);
            return View(cT_PHIEU_GIAO_HANG);
        }

        // POST: CTPGH/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPGH,MaSP,SoLuong,DonGia,ThanhTien")] CT_PHIEU_GIAO_HANG cT_PHIEU_GIAO_HANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_PHIEU_GIAO_HANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPGH = new SelectList(db.PHIEU_GIAO_HANG, "MaPGH", "GhiChu", cT_PHIEU_GIAO_HANG.MaPGH);
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "TenSP", cT_PHIEU_GIAO_HANG.MaSP);
            return View(cT_PHIEU_GIAO_HANG);
        }

        // GET: CTPGH/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_PHIEU_GIAO_HANG cT_PHIEU_GIAO_HANG = db.CT_PHIEU_GIAO_HANG.SingleOrDefault(n => n.MaPGH == id);
            if (cT_PHIEU_GIAO_HANG == null)
            {
                return HttpNotFound();
            }
            return View(cT_PHIEU_GIAO_HANG);
        }

        // POST: CTPGH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CT_PHIEU_GIAO_HANG cT_PHIEU_GIAO_HANG = db.CT_PHIEU_GIAO_HANG.SingleOrDefault(n => n.MaPGH == id);
            db.CT_PHIEU_GIAO_HANG.Remove(cT_PHIEU_GIAO_HANG);
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

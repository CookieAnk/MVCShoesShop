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
    public class CTDDHController : Controller
    {
        private ShoesShopEntities db = new ShoesShopEntities();

        // GET: CTDDH
        public ActionResult Index()
        {
            var cT_DON_DAT_HANG = db.CT_DON_DAT_HANG.Include(c => c.DON_DAT_HANG).Include(c => c.SAN_PHAM);
            Session["ctddh"] = cT_DON_DAT_HANG;
            if (Session["Taikhoanadmin"] == null || Session["Taikhoanadmin"].ToString() == "")
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Session["ctddh"] == null)
            {
                return RedirectToAction("Index", "CTDDH");
            }
            return View(cT_DON_DAT_HANG.ToList());
        }

        // GET: CTDDH/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_DON_DAT_HANG cT_DON_DAT_HANG = db.CT_DON_DAT_HANG.SingleOrDefault(n => n.MaDDH == id);
            if (cT_DON_DAT_HANG == null)
            {
                return HttpNotFound();
            }
            return View(cT_DON_DAT_HANG);
        }

        // GET: CTDDH/Create
        public ActionResult Create()
        {
            ViewBag.MaDDH = new SelectList(db.DON_DAT_HANG, "MaDDH", "MaDDH");
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "TenSP");
            return View();
        }

        // POST: CTDDH/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDDH,MaSP,SoLuong")] CT_DON_DAT_HANG cT_DON_DAT_HANG)
        {
            if (ModelState.IsValid)
            {
                db.CT_DON_DAT_HANG.Add(cT_DON_DAT_HANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDDH = new SelectList(db.DON_DAT_HANG, "MaDDH", "MaDDH", cT_DON_DAT_HANG.MaDDH);
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "TenSP", cT_DON_DAT_HANG.MaSP);
            return View(cT_DON_DAT_HANG);
        }

        // GET: CTDDH/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_DON_DAT_HANG cT_DON_DAT_HANG = db.CT_DON_DAT_HANG.SingleOrDefault(n => n.MaDDH == id);
            if (cT_DON_DAT_HANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDDH = new SelectList(db.DON_DAT_HANG, "MaDDH", "MaDDH", cT_DON_DAT_HANG.MaDDH);
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "TenSP", cT_DON_DAT_HANG.MaSP);
            return View(cT_DON_DAT_HANG);
        }

        // POST: CTDDH/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDDH,MaSP,SoLuong")] CT_DON_DAT_HANG cT_DON_DAT_HANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_DON_DAT_HANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDDH = new SelectList(db.DON_DAT_HANG, "MaDDH", "MaDDH", cT_DON_DAT_HANG.MaDDH);
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "TenSP", cT_DON_DAT_HANG.MaSP);
            return View(cT_DON_DAT_HANG);
        }

        // GET: CTDDH/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_DON_DAT_HANG cT_DON_DAT_HANG = db.CT_DON_DAT_HANG.SingleOrDefault(n => n.MaDDH == id);
            if (cT_DON_DAT_HANG == null)
            {
                return HttpNotFound();
            }
            return View(cT_DON_DAT_HANG);
        }

        // POST: CTDDH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CT_DON_DAT_HANG cT_DON_DAT_HANG = db.CT_DON_DAT_HANG.Find(id);
            db.CT_DON_DAT_HANG.Remove(cT_DON_DAT_HANG);
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

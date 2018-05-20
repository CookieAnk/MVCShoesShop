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
    public class LoaiSPController : Controller
    {
        private ShoesShopEntities db = new ShoesShopEntities();

        // GET: LoaiSP
        public ActionResult Index()
        {
            var lOAI_SAN_PHAM = db.LOAI_SAN_PHAM.Include(s => s.MaLoaiSP);
            Session["LSP"] = lOAI_SAN_PHAM;
            if (Session["Taikhoanadmin"] == null || Session["Taikhoanadmin"].ToString() == "")
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Session["LSP"] == null)
            {
                return RedirectToAction("Index", "LoaiSP");
            }
            return View(db.LOAI_SAN_PHAM.ToList());
        }

        // GET: LoaiSP/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAI_SAN_PHAM lOAI_SAN_PHAM = db.LOAI_SAN_PHAM.Find(id);
            if (lOAI_SAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(lOAI_SAN_PHAM);
        }

        // GET: LoaiSP/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiSP/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiSP,TenLoai")] LOAI_SAN_PHAM lOAI_SAN_PHAM)
        {
            if (ModelState.IsValid)
            {
                db.LOAI_SAN_PHAM.Add(lOAI_SAN_PHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOAI_SAN_PHAM);
        }

        // GET: LoaiSP/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAI_SAN_PHAM lOAI_SAN_PHAM = db.LOAI_SAN_PHAM.Find(id);
            if (lOAI_SAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(lOAI_SAN_PHAM);
        }

        // POST: LoaiSP/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiSP,TenLoai")] LOAI_SAN_PHAM lOAI_SAN_PHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAI_SAN_PHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOAI_SAN_PHAM);
        }

        // GET: LoaiSP/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAI_SAN_PHAM lOAI_SAN_PHAM = db.LOAI_SAN_PHAM.Find(id);
            if (lOAI_SAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(lOAI_SAN_PHAM);
        }

        // POST: LoaiSP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOAI_SAN_PHAM lOAI_SAN_PHAM = db.LOAI_SAN_PHAM.Find(id);
            db.LOAI_SAN_PHAM.Remove(lOAI_SAN_PHAM);
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

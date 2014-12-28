using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LMS.Models;

namespace LMS.Controllers
{
    public class OgrenciDersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OgrenciDers
        public ActionResult Index()
        {
            var ogrenciDers = db.OgrenciDers.Include(o => o.Ders).Include(o => o.Ogrenci);
            return View(ogrenciDers.ToList());
        }

        // GET: OgrenciDers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrenciDers ogrenciDers = db.OgrenciDers.Find(id);
            if (ogrenciDers == null)
            {
                return HttpNotFound();
            }
            return View(ogrenciDers);
        }

        // GET: OgrenciDers/Create
        public ActionResult Create()
        {
            ViewBag.DersID = new SelectList(db.Ders, "Id", "Ad");
            ViewBag.OgrenciId = new SelectList(db.Ogrencis, "Id", "Ad");
            return View();
        }

        // POST: OgrenciDers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DersID,OgrenciId")] OgrenciDers ogrenciDers)
        {
            if (ModelState.IsValid)
            {
                db.OgrenciDers.Add(ogrenciDers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DersID = new SelectList(db.Ders, "Id", "Ad", ogrenciDers.DersID);
            ViewBag.OgrenciId = new SelectList(db.Ogrencis, "Id", "Ad", ogrenciDers.OgrenciId);
            return View(ogrenciDers);
        }

        // GET: OgrenciDers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrenciDers ogrenciDers = db.OgrenciDers.Find(id);
            if (ogrenciDers == null)
            {
                return HttpNotFound();
            }
            ViewBag.DersID = new SelectList(db.Ders, "Id", "Ad", ogrenciDers.DersID);
            ViewBag.OgrenciId = new SelectList(db.Ogrencis, "Id", "Ad", ogrenciDers.OgrenciId);
            return View(ogrenciDers);
        }

        // POST: OgrenciDers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DersID,OgrenciId")] OgrenciDers ogrenciDers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogrenciDers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DersID = new SelectList(db.Ders, "Id", "Ad", ogrenciDers.DersID);
            ViewBag.OgrenciId = new SelectList(db.Ogrencis, "Id", "Ad", ogrenciDers.OgrenciId);
            return View(ogrenciDers);
        }

        // GET: OgrenciDers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrenciDers ogrenciDers = db.OgrenciDers.Find(id);
            if (ogrenciDers == null)
            {
                return HttpNotFound();
            }
            return View(ogrenciDers);
        }

        // POST: OgrenciDers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OgrenciDers ogrenciDers = db.OgrenciDers.Find(id);
            db.OgrenciDers.Remove(ogrenciDers);
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

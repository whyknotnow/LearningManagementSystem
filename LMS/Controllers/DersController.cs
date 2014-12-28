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
    public class DersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ders
        public ActionResult Index()
        {
            var ders = db.Ders.Include(d => d.OgretimGorevlisi);
            return View(ders.ToList());
        }

        // GET: Ders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ders ders = db.Ders.Find(id);
            if (ders == null)
            {
                return HttpNotFound();
            }
            return View(ders);
        }

        // GET: Ders/Create
        public ActionResult Create()
        {
            ViewBag.OgretimGorevlisiId = new SelectList(db.OgretimGorevlisis, "Id", "Ad");
            return View();
        }

        // POST: Ders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ad,Kod,OgretimGorevlisiId")] Ders ders)
        {
            if (ModelState.IsValid)
            {
                db.Ders.Add(ders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OgretimGorevlisiId = new SelectList(db.OgretimGorevlisis, "Id", "Ad", ders.OgretimGorevlisiId);
            return View(ders);
        }

        // GET: Ders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ders ders = db.Ders.Find(id);
            if (ders == null)
            {
                return HttpNotFound();
            }
            ViewBag.OgretimGorevlisiId = new SelectList(db.OgretimGorevlisis, "Id", "Ad", ders.OgretimGorevlisiId);
            return View(ders);
        }

        // POST: Ders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ad,Kod,OgretimGorevlisiId")] Ders ders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OgretimGorevlisiId = new SelectList(db.OgretimGorevlisis, "Id", "Ad", ders.OgretimGorevlisiId);
            return View(ders);
        }

        // GET: Ders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ders ders = db.Ders.Find(id);
            if (ders == null)
            {
                return HttpNotFound();
            }
            return View(ders);
        }

        // POST: Ders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ders ders = db.Ders.Find(id);
            db.Ders.Remove(ders);
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

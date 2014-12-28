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
    public class OgretimGorevlisiController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OgretimGorevlisi
        public ActionResult Index()
        {
            return View(db.OgretimGorevlisis.ToList());
        }

        // GET: OgretimGorevlisi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgretimGorevlisi ogretimGorevlisi = db.OgretimGorevlisis.Find(id);
            if (ogretimGorevlisi == null)
            {
                return HttpNotFound();
            }
            return View(ogretimGorevlisi);
        }

        // GET: OgretimGorevlisi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OgretimGorevlisi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ad,Soyad,KimlikNo,EPosta,DogumTarih")] OgretimGorevlisi ogretimGorevlisi)
        {
            if (ModelState.IsValid)
            {
                db.OgretimGorevlisis.Add(ogretimGorevlisi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ogretimGorevlisi);
        }

        // GET: OgretimGorevlisi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgretimGorevlisi ogretimGorevlisi = db.OgretimGorevlisis.Find(id);
            if (ogretimGorevlisi == null)
            {
                return HttpNotFound();
            }
            return View(ogretimGorevlisi);
        }

        // POST: OgretimGorevlisi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ad,Soyad,KimlikNo,EPosta,DogumTarih")] OgretimGorevlisi ogretimGorevlisi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogretimGorevlisi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ogretimGorevlisi);
        }

        // GET: OgretimGorevlisi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgretimGorevlisi ogretimGorevlisi = db.OgretimGorevlisis.Find(id);
            if (ogretimGorevlisi == null)
            {
                return HttpNotFound();
            }
            return View(ogretimGorevlisi);
        }

        // POST: OgretimGorevlisi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OgretimGorevlisi ogretimGorevlisi = db.OgretimGorevlisis.Find(id);
            db.OgretimGorevlisis.Remove(ogretimGorevlisi);
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

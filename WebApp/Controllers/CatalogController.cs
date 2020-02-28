using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YachtLib;

namespace WebApp.Controllers
{
    public class CatalogController : BasisController
    {
        
        // GET: Catalog
        public ActionResult Index()
        {
            var schiffs = db.Schiffs.Include(s => s.Basis).Include(s => s.Person);
            return View(schiffs.ToList());
        }

        // GET: Catalog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schiff schiff = db.Schiffs.Find(id);
            if (schiff == null)
            {
                return HttpNotFound();
            }
            return View(schiff);
        }

        // GET: Catalog/Create
        public ActionResult Create()
        {
            ViewBag.BasisId = new SelectList(db.Bases, "Id", "Ort");
            ViewBag.PersonId1 = new SelectList(db.People, "Id", "Name");
            return View();
        }

        // POST: Catalog/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EignerId,BasisId,PersonId1,Typ,Laenge,Baujahr,Schiffsname")] Schiff schiff)
        {
            if (ModelState.IsValid)
            {
                db.Schiffs.Add(schiff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BasisId = new SelectList(db.Bases, "Id", "Ort", schiff.BasisId);
            ViewBag.PersonId1 = new SelectList(db.People, "Id", "Name", schiff.PersonId1);
            return View(schiff);
        }

        // GET: Catalog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schiff schiff = db.Schiffs.Find(id);
            if (schiff == null)
            {
                return HttpNotFound();
            }
            ViewBag.BasisId = new SelectList(db.Bases, "Id", "Ort", schiff.BasisId);
            ViewBag.PersonId1 = new SelectList(db.People, "Id", "Name", schiff.PersonId1);
            return View(schiff);
        }

        // POST: Catalog/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EignerId,BasisId,PersonId1,Typ,Laenge,Baujahr,Schiffsname")] Schiff schiff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schiff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BasisId = new SelectList(db.Bases, "Id", "Ort", schiff.BasisId);
            ViewBag.PersonId1 = new SelectList(db.People, "Id", "Name", schiff.PersonId1);
            return View(schiff);
        }

        // GET: Catalog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schiff schiff = db.Schiffs.Find(id);
            if (schiff == null)
            {
                return HttpNotFound();
            }
            return View(schiff);
        }

        // POST: Catalog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Schiff schiff = db.Schiffs.Find(id);
            db.Schiffs.Remove(schiff);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Catalog/Order/5
        public ActionResult Order(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schiff schiff = db.Schiffs.Find(id);
            if (schiff == null)
            {
                return HttpNotFound();
            }
            
            return View(schiff);
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

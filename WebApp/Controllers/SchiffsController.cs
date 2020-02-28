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
    public class SchiffsController : BasisController
    {
       
        // GET: Schiffe
        public ActionResult Index()
        {
            var schiffs = db.Schiffs.Include(s => s.Basis).Include(s => s.Person);
            return View(schiffs.ToList());
        }

        // GET: Details von Schiffen
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

        // GET: Schiffe anlegen
        public ActionResult Create()
        {
            ViewBag.Admin = getRoleAdmin();
            ViewBag.BasisId = new SelectList(db.Bases, "Id", "Ort");
            ViewBag.PersonId1 = new SelectList(db.People, "Id", "Name");
            return View();
        }

        // POST: Schiffe anlegen
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BasisId,PersonId1,Typ,Laenge,Baujahr,Schiffsname")] Schiff schiff)
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

        // GET: Schiffe anpassen
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
            ViewBag.Admin = getRoleAdmin();
            ViewBag.BasisId = new SelectList(db.Bases, "Id", "Ort", schiff.BasisId);
            ViewBag.PersonId1 = new SelectList(db.People, "Id", "Name", schiff.PersonId1);
            return View(schiff);
        }

        // POST: Schiffe anpassen
   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BasisId,PersonId1,Typ,Laenge,Baujahr,Schiffsname")] Schiff schiff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schiff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Admin = getRoleAdmin();
            ViewBag.BasisId = new SelectList(db.Bases, "Id", "Ort", schiff.BasisId);
            ViewBag.PersonId1 = new SelectList(db.People, "Id", "Name", schiff.PersonId1);
            return View(schiff);
        }

        // GET: Schiffe löschen
        public ActionResult Delete(int? id)
        {
            ViewBag.Admin = getRoleAdmin();
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

        // POST: Schiffe löschen
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Schiff schiff = db.Schiffs.Find(id);
            db.Schiffs.Remove(schiff);
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

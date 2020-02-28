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
    public class BasesController : BasisController
    {
       
        // GET: Bases
        public ActionResult Index()
        {
            return View(db.Bases.ToList());
        }

        // GET: Bases/zeige Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basis basis = db.Bases.Find(id);
            if (basis == null)
            {
                return HttpNotFound();
            }
            return View(basis);
        }

        // GET: Bases/Erstellen von Häfen als Admin
        public ActionResult Create()
        {
            ViewBag.Admin = getRoleAdmin();
            
            return View();
        }
        
                 


        // POST: Bases/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ort,Land")] Basis basis)
        {
            if (ModelState.IsValid)
            {
                db.Bases.Add(basis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(basis);
        }

        // GET: Bases/Anpassen von Häfen
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basis basis = db.Bases.Find(id);
            if (basis == null)
            {
                return HttpNotFound();
            }
            {
                ViewBag.Admin = getRoleAdmin();

                return View(basis);
            }
            
        }

        // POST: Bases/Edit/5
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ort,Land")] Basis basis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(basis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(basis);
        }

        // GET: Bases/Löschen von Häfen
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basis basis = db.Bases.Find(id);
            if (basis == null)
            {
                return HttpNotFound();
            }
            {
                ViewBag.Admin = getRoleAdmin();

                return View(basis);
            }
            
        }

        // POST: Bases/Löschen von Häfen
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            {
                ViewBag.Admin = getRoleAdmin();

                return View();
            }
            Basis basis = db.Bases.Find(id);
            db.Bases.Remove(basis);
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

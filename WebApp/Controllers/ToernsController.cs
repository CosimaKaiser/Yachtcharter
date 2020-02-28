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
    public class ToernsController : BasisController
    {
        
        // GET: Toerns
        public ActionResult Index()
        {
            var toerns = db.Toerns.Include(t => t.Schiff);
            return View(toerns.ToList());
        }

        // GET: Toerndetails
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toern toern = db.Toerns.Find(id);
            if (toern == null)
            {
                return HttpNotFound();
            }
            return View(toern);
        }

        // GET: Erstellen und anlegen von Törns
        public ActionResult Create()
        {
            ViewBag.SchiffId = new SelectList(db.Schiffs, "Id", "Schiffsname");
            return View();
        }

        // POST: Erstellen von Törns
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SchiffId,Start,Ende")] Toern toern)
        {
            if (ModelState.IsValid)
            {
                db.Toerns.Add(toern);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Admin = getRoleAdmin();
            ViewBag.Customer = getRoleCustomer();
            ViewBag.SchiffId = new SelectList(db.Schiffs, "Id", "Schiffsname", toern.SchiffId);
            return View(toern);
        }

        // GET: Anpassen von Toerns
        public ActionResult Edit(int? id)
        {
            ViewBag.Admin = getRoleAdmin();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toern toern = db.Toerns.Find(id);
            if (toern == null)
            {
                return HttpNotFound();
            }
            ViewBag.SchiffId = new SelectList(db.Schiffs, "Id", "Schiffsname", toern.SchiffId);
            return View(toern);
        }

        // POST: Anpassen von Toerns
  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SchiffId,Start,Ende")] Toern toern)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toern).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SchiffId = new SelectList(db.Schiffs, "Id", "Schiffsname", toern.SchiffId);
            return View(toern);
        }

        // GET: Löschen von Törns
        public ActionResult Delete(int? id)
        {
            ViewBag.Admin = getRoleAdmin();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toern toern = db.Toerns.Find(id);
            if (toern == null)
            {
                return HttpNotFound();
            }
            return View(toern);
        }

        // POST: Löschen von Törns
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Admin = getRoleAdmin();
            Toern toern = db.Toerns.Find(id);
            db.Toerns.Remove(toern);
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

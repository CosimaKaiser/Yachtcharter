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
    public class LoginKundeController : BasisController
    {
      

        // GET: Login Schaltfläche in der Webnwendung
        public ActionResult Index()
        {
            return View(db.People.ToList());
        }

        // GET: Login Details in der Webanwendung
        public ActionResult Select(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            setPeopleId(id.Value);
            return RedirectToAction("Index");
        }
        
       
    }
}

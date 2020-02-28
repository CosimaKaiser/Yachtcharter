using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : BasisController
    {
        public ActionResult Index()
        {
            ViewBag.Admin = getRoleAdmin();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Hallo!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "If you need help or have any questions, please contact us under:";

            return View();
        }
    }
}
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
    public class BasisController : Controller
    {
        protected YachtModelContainer db = new YachtModelContainer();

        private static String PeopleIdKey = "PeopleId";
        public Person setPeople()
        {
            int? PeopleId = Session[PeopleIdKey] as int?;
            if (PeopleId == null) return null;
            Person res = db.People.Find(PeopleId);
            if (res == null) return null;
            ViewBag.People = res;
            _LoggedInPerson = res;
            return res;
        }
        private Person _LoggedInPerson = null;
        protected Person LoggedInPerson => _LoggedInPerson?? setPeople();
        protected bool HasPerson()     
        {
  
           return LoggedInPerson != null;
        }

        
            protected void setPeopleId(int PeopleId)
        {
            Session[PeopleIdKey] = PeopleId;
        }
        public bool getRoleAdmin()
        {
            if (LoggedInPerson != null)
            {
                return LoggedInPerson.RoleAdmin;
            }
            return false;
        }

        public bool getRoleCustomer()
        {
            if (LoggedInPerson != null)
            {
                return LoggedInPerson.RoleCustomer;
            }
            return false;
        }
    }
       
}

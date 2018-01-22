using EHealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace EHealth.Controllers
{
    public class HomeController : ApplicationController
    {
        [Authorize]
        public ActionResult Index(Person person)
        {
            if (Request.IsAuthenticated)
            {
                string username = User.Identity.Name;

                using (var ent = new EHealthDB2Entities())
                {
                    person = ent.Person.Where(p => p.username == username).Include(p => p.City).Include(p => p.City1).
                        Include(p => p.PhoneNumber).Include(p => p.PhoneNumber.Select(t => t.PhoneType)).
                        Include(p => p.Email).FirstOrDefault();
                }
            }

            return View(person);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

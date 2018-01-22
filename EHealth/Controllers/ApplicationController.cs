using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EHealth.Models;

namespace EHealth.Controllers
{
    public class ApplicationController : Controller
    {
        //
        // GET: /Application/
        //
        // GET: /Application/
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (User != null)
            {
                var username = User.Identity.Name;

                if (!string.IsNullOrEmpty(username))
                {
                    using (EHealthDB2Entities ent = new EHealthDB2Entities())
                    {
                        IQueryable<Person> person = from p in ent.Person
                                                  where p.username == username
                                                  select p;
                        string fullName = null;
                        foreach (Person p in person)
                        {
                            fullName = p.firstName + " " + p.lastName;
                        }
                        ViewData.Add("FullName", fullName);
                    }
                }
            }
            base.OnActionExecuted(filterContext);
        }

        public ApplicationController()
        {

        }

    }
}

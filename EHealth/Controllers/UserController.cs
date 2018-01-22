using EHealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EHealth.Controllers
{
    public class UserController : ApplicationController
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(LogInViewModel logIn)
        {
            if (ModelState.IsValid)
            {
                if (isValid(logIn.Username, logIn.Password))
                {
                    FormsAuthentication.SetAuthCookie(logIn.Username, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "");
                }
            }
            return View(logIn);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult LogOut(Person person)
        {
            return View();
        }

        private bool isValid(String username, String password)
        {
            //var crypto = new SimpleCrypto.PBKDF2();
            bool isValid = false;

            using (var ent = new EHealthDB2Entities())
            {

                var person = ent.Person.FirstOrDefault(p => p.username == username);

                if (person != null)
                {

                    if (person.password == password/*crypto.Compute(password, osoba.Salt)*/)
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;
        }

    }
}

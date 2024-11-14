using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using HDFCBankApp.Services;

namespace HDFCBankApp.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            AuthService authService = new AuthService();
            authService.Seeding();
            return View();
        }

        //POST:Auth
        [HttpPost]
        public ActionResult Login(string email, string password)
        {

            AuthService authService = new AuthService();
            if (authService.Login(email, password))
            {
                this.HttpContext.Session["loggedinUser"] = email;
                return RedirectToAction("welcome");
            }
            else
            {

                return View();
            }

        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string firstname, string lastname, string email, long contactno, string location)
        {
            IAuthService authService = new AuthService();
            if (authService.Register(firstname, lastname, email, contactno, location))
            {
                this.HttpContext.Session["loggedinUser"] = email;
                return RedirectToAction("welcome");
            }
            else
            {
                return View();
            }
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        public ActionResult Welcome()
        {
            string email = this.HttpContext.Session["loggedinUser"] as string;
            ViewBag.Email = email;
            return View();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankingPortal.Services;

namespace BankingPortal.Controllers
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
        public ActionResult Register(string firstname, string lastname, string email, long contactno, string address)
        {
            IAuthService authService = new AuthService();
            if (authService.Register(firstname, lastname, email, contactno, address))
            {
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
            return View();
        }


    }
}
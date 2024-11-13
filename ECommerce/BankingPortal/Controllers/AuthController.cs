using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankingPortal.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()

        {
            return View();
        }

        //POST:Auth
        [HttpPost]
        public ActionResult Login(string email, string password)
        {

            if (email == "shruti@gmail.com" && password == "123")
            {
                return RedirectToAction("Welcome");
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
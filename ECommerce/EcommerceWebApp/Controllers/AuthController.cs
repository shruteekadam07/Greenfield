using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceWebApp.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Login() 
        {
            return View();
        
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult ForgotPassword() 
        { 
            return View();
        }
        public ActionResult ResetPassword()
        {
            return View();
        }
    }
}
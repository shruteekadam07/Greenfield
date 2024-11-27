using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Specification;
using EcommerceServices;

namespace AuthWebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();

        }

        public ActionResult GetUsers()
        {

            //anonymous type----->object created without name, class known by its content
            var result = new
            {
                Id = 12,
                FirstName = "Shruti",
                LastName = "Kadam"
            };
            return Json(result,JsonRequestBehavior.AllowGet);
           
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            string result = "invalid user";
            if (email == "shruti@gmail.com" && password == "123")
            {
                result = "Valid user";
            }
            return Json(result, JsonRequestBehavior.AllowGet);

        }


        public ActionResult SignIn()
        {
            return View();

        }

        [HttpPost]
        public ActionResult SignIn(string email, string password)
        {

            IAuthService svc = new AuthService();
            string result = "Invalid User";
            if (svc.Login(email, password))
            {
                result = "Valid User";
            }
            return Json(result, JsonRequestBehavior.AllowGet);

        }


        //classical javascript and dom manipultaion
        public ActionResult Storage()
        {
            return View();  
        }


        public ActionResult JqueryDemo()
        {
            return View();
        }

        public ActionResult Login2()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult GDI()
        {
            return View();
        }

        public ActionResult CreditPayment()
        {
            return View();
        }

        public ActionResult Catalog()
        {
            return View();
        }

        public ActionResult CatalogAJAX()
        {
            return View();
        }

    }
}


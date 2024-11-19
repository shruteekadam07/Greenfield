using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AuthWebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult GetUser()
        {
            ViewBag.Title = "Home Page";

            return View();

            //anonymous type----->object created without name, class known by its content
            var result = new
            {
                Id = 12,
                FirstName = "Shruti",
                LastName = "Kadam"
            };
            return Json(result,JsonRequestBehavior.AllowGet);
            //
            //
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
                result = "Vlid user";
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

            //validation logic

            return View(email);
           // return Json();

        }
    }
}


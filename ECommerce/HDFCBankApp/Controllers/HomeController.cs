using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HDFCBankApp.Models;

namespace HDFCBankApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            string company = "Simplify Healthcare";
            ViewBag.Company = company;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            Contact cnt = new Contact
            {
                ContactNumber = "9022371763",
                Email = "admin@simplifyhealthcare.com",
                Website = "www.simplifyhealthcare.com"
            };
            ViewData["contact"] = cnt;
            return View();
        }

        public ActionResult ThankYou()
        {
            string theMessage = TempData["mymessage"] as string;
            ViewData["processmessage"] = theMessage;
            return View();
        }
    }
}
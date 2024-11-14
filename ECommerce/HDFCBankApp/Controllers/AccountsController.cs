using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

//STUDY TEMP DATA

namespace HDFCBankApp.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Index()
        {

            string theMessage = "i am manager" ;
            TempData["mymessage"]=theMessage;
            //return View();
            return RedirectToAction("thankyou", "home");
        }

       

        public ActionResult Process()
        {
            string theMessage = TempData["mymessage"] as string;
            ViewData["processmessage"] = theMessage;
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HDFCBankApp.Models;

namespace HDFCBankApp.Controllers
{
    public class CustomersController : Controller
    {
        private List<Customer> list = new List<Customer>();

        public CustomersController() {
            list.Add(new Customer { Id = 1, Name = "Microsoft", Email = "kahaga@gmail.com", Location = "mumbai", ContactNumber = "7897554" });


        }

        // GET: Customers
        public ActionResult Index()
        {
            ViewData["list"] = list;
            return View();
        }

        public ActionResult Details(int id)
        {
            Customer customer = list.Find(cust=> cust.Id == id);
                return View(customer);
        }
    }
}
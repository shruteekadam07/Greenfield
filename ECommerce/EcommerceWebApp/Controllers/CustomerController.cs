using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceWebApp.Models;

namespace EcommerceWebApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer { Id=1,Name="Shruti Kadam",Address="Pune",Email="Kadamshruti9661@gmail.com"});
            
            return View(customers);
        }
    }
}


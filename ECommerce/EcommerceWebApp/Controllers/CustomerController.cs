using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using EcommerceWebApp.Models;
using ECommerceEntities;

namespace EcommerceWebApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            
            CustomerProfile theProfile = new CustomerProfile();
            theProfile.theCustomer = new Customer
            {
                Id = 12,
                FirstName = "Raj",
                LastName = "Mane",
                Contact = "9883478569",
                Email = "raj.mane@gmail.com"
            };

            theProfile.OrderHistory = new List<Order>();
            theProfile.OrderHistory.Add(new Order { OrderId = 12, Status = "delivered", Orderdate = DateTime.Now, Amount = 76000 });
            theProfile.OrderHistory.Add(new Order { OrderId = 16, Status = "cancelled", Orderdate = DateTime.Now, Amount = 34000 });

            ViewData["profile"] = theProfile;
            return View();
            // List<Customer> customers = new List<Customer>();
            //customers.Add(new Customer { Id=1,Name="Shruti Kadam",Address="Pune",Email="Kadamshruti9661@gmail.com"});         
            //return View(customers);
        }
    }
}


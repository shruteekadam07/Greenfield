using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceWebApp.Models;


namespace EcommerceWebApp.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult OrderView()
        {
            List<Order> orders = new List<Order>();
            orders.Add(new Order { OrderId = 1, OrderStatus = "Shruti Kadam",OrderAmount=4500  });
            return View(orders);
        }
    }
}
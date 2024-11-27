using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerceEntities;
using ECommerceServices;
using Specification;


namespace EcommerceWebApp.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult OrderView()
        {
            List<Order> orders = new List<Order>();
            orders.Add(new Order { OrderId = 1, Status = "Shruti Kadam",Amount=4500  });
            return View(orders);
        }

        public ActionResult Index()
        {
            OrderService svc = new OrderService();
            return View(svc.GetAll());
        }

        public ActionResult BuyNow()
        {
            Cart cart = (Cart)this.HttpContext.Session["cart"];
            IOrderService service = new OrderService();
            ICartService svc = new CartService(cart);
            List<Item> items = svc.GetAll();
            int id = (service.GetAll().Count) + 1;
            double amt = svc.GetTotalAmount(items);
            if (service.Insert(new Order
            {
                Orderdate = DateTime.Now,
                Amount = amt,
                Status = "processing",
                myCart = cart,
                OrderId = id
            }))
            {
                svc.Clear();
                return RedirectToAction($"OrderDetails/{id}");

            }
            return RedirectToAction("Index");
        }

        public ActionResult OrderDetails(int id)
        {
            IOrderService svc = new OrderService();
            Order o = svc.Get(id);

            return View(o);
        }



    }
}
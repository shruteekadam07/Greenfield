using ECommerceEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Specification;
using EcommerceServices;


namespace EcommerceWebApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            Cart mycart = (Cart)this.HttpContext.Session["cart"];
            ICartService svc= new CartService(mycart);
            List<Item> cart=svc.GetAll();
            ViewData["cart"]=cart;
            return View();
        }

        public ActionResult AddtoCart(int id)
        {
            ViewBag.id = id;

            return View();
        }
        [HttpPost]
        public ActionResult AddtoCart(Item theItem)
        {

            Cart mycart = (Cart)this.HttpContext.Session["cart"];
            mycart.Items.Add(theItem);
            return RedirectToAction("Index","Product");
        }
        public ActionResult RemovefromCart(int id)
        {
            Cart mycart = (Cart)this.HttpContext.Session["cart"];
            mycart.Items.RemoveAll((item) => (item.ProductId == id));
            return RedirectToAction("Index","ShoppingCart");
        }

    }
}
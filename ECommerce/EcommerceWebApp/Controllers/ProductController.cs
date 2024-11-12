using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POCOLib;

namespace EcommerceWebApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
           //IProductService svc = new ProductService();
            //List<Product> products = svc.GetAll();
            //return View(products);
            List<Product> products = new List<Product>();
            products.Add(new Product { ProductId = 1, Title = "Jasmine", Description = "Fragnance", UnitPrice = 32, Quantity = 30, ImageUrl = "/Images/j.jpg" });


            return View(products);
        }
        public ActionResult Details() 
        {
            return View();
        
        }
        public ActionResult Insert() 
        {
            return View();
        }
        public ActionResult Update()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }

    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerceEntities;

namespace EcommerceWebApp.Controllers
{
    public class ProductController : Controller
    {

        private List<Product> products = new List<Product>();

        public ProductController()
        {
            products.Add(new Product { ProductId = 1, Title = "Jasmine", Description = "Fragnance", UnitPrice = 32, Quantity = 30, ImageUrl = "/Images/j.jpg" });
            products.Add(new Product { ProductId = 2, Title = "gerbera", Description = "Wedding Flower", UnitPrice = 12, Quantity = 2000, ImageUrl = "/Images/gerbera.jpg" });
            products.Add(new Product { ProductId = 3, Title = "rose", Description = "Valentine Flower", UnitPrice = 23, Quantity = 9000, ImageUrl = "/images/rose.jpg" });
            products.Add(new Product { ProductId = 4, Title = "lily", Description = "Delicate Flower", UnitPrice = 2, Quantity = 7000, ImageUrl = "/images/lily.jpg" });

        }


        // GET: Product
        public ActionResult Index()
        {
            ViewData["list"] = products;
            //IProductService svc = new ProductService();
            //List<Product> products = svc.GetAll();
            //return View(products);
            //List<Product> products = new List<Product>();



            return View(products);
        }
        public ActionResult Details(int id) 
        {
            Product product =products.Find(x => x.ProductId == id);
            ViewData["product"]=product;
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
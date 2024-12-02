using Microsoft.AspNetCore.Mvc;
using Catalog.Services;
using Catalog.Entities;
using Microsoft.Extensions.Configuration;

namespace ECommerceWeb.Controllers
{
    public class ProductsController : Controller
    {
        IProductService _service;

        
        public ProductsController(IProductService service){
            this._service = service;
        }

        public IActionResult Index()
        {
            List<Product> products = _service.GetAll();
            ViewData["products"] = products;
            return View();
        }
    }
}

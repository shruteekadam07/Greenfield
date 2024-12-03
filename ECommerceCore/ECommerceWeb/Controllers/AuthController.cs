using CRM.Services;
using Microsoft.AspNetCore.Mvc;
using CRM.Entities;
namespace ECommerceWeb.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            List<User> users = _service.GetAllUsers();
            ViewData["users"] = users;
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            bool result = _service.Login(email, password);
            if (result)
            {
                return RedirectToAction("Welcome", "Auth");
            }
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string firstname, string lastname, string email, string password)
        {

            User u = new User { FirstName = firstname, LastName = lastname, Email = email, Password = password };
            if (_service.Register(u))
            {
                return RedirectToAction("Welcome", "Auth");
            }
            else
            {
                return View();
            }

        }

        public ActionResult Welcome()
        {
            return View();
        }
    }
}
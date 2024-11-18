using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Models;

namespace HRPortal.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        { 
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]  
        public ActionResult Create(FormCollection collection)
        {
            string firstname=collection["firstname"] as string;
            string lastname = collection["lastname"] as string;
            string email = collection["email"] as string;
            string Contactno = collection["contactnumber"] as string;
            return View();
        }

        
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Employee emp)
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            Employee employee = new Employee();
            employee.Id = id;
            employee.Name = "Shruti";
            employee.IsConfirmed = true;
            employee.BasicSalary = 10000;
            employee.DailyAllowance = 200;
            employee.Workingdays = 10;
            employee.JoinDate = DateTime.Now;
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {

            return View();
        }

    }
}
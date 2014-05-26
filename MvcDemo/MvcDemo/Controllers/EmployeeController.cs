using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using businesLayer;
namespace MvcDemo.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

        public ActionResult Index()
        {

            EmployeebusinessLayer obj = new EmployeebusinessLayer();
            List<Employee> employee = obj.Employee.ToList();
            return View(employee);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            EmployeebusinessLayer obj = new EmployeebusinessLayer();
            Employee employee = obj.Employee.Single(x=>x.ID==id);
            return View(employee);
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(int id)
        {

            Employee employee = new Employee();
            TryUpdateModel(employee);
            if (ModelState.IsValid)
            {
                EmployeebusinessLayer objbus = new EmployeebusinessLayer();
                objbus.updateEmployee(employee);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Edit");
            }
        }
        [HttpGet]
        public ActionResult Create(FormCollection formcollection)
        {
            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreateEmployee()
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee();
                UpdateModel(employee);
                EmployeebusinessLayer objbus = new EmployeebusinessLayer();
                objbus.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

    }
}

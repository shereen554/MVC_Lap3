using Microsoft.AspNetCore.Mvc;
using MVC_Lap2.Models;

namespace MVC_Lap3
{
    public class EmployeeController : Controller
    {
        private EmployeeContext context;
        public EmployeeController()
        {
                context = new EmployeeContext();
        }
        public IActionResult Index()
        {
            List<Employee> employees = context.Employees.ToList();
            return View(employees);
        }
        public IActionResult Details(int id)
        {
            Employee employee=context.Employees.Where(e=>e.id==id).SingleOrDefault();
            if(employee==null) { 
          return Content("Error");
            }
            return View(employee);
        }
        public IActionResult AddForm()
        {
            List<Office> offices = context.Office.ToList();
            ViewBag.Office = offices;
             return View();
        }
        public IActionResult AddInDB(Employee employee)
        {
            context.Employees.Add(employee);
          
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult EditForm(int id)
        {
         
            Employee employee = context.Employees.SingleOrDefault(e => e.id == id);
            ViewBag.office = context.Office.ToList();
           return View(employee);
        }
        public IActionResult EditInDB(Employee employee)
        {
            Employee oldemployee = context.Employees.SingleOrDefault(c =>c.id == employee.id);

            oldemployee.name= employee.name;
            oldemployee.age = employee.age;
            oldemployee.address = employee.address;
            oldemployee.salary = employee.salary;
            oldemployee.email = employee.email;
            oldemployee.office_id = employee.office_id;
            oldemployee.password = employee.password;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Employee emplyee = context.Employees.SingleOrDefault(c => c.id == id);
            context.Employees.Remove(emplyee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

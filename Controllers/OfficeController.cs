using Microsoft.AspNetCore.Mvc;
using MVC_Lap2.Models;

namespace MVC_Lap3.Controllers
{
    
    public class OfficeController : Controller
    {
        private EmployeeContext context;
        public OfficeController()
        {
            context = new EmployeeContext();
        }
        public IActionResult View_office()
        {
           // List<Office> office = context.Office.ToList();
           List<Office> officeList =context.Office.ToList();
            return View(officeList);
        }
    }
}

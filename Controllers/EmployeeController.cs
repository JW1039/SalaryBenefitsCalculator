using Microsoft.AspNetCore.Mvc;
using LeasePlus_DevTest.Models;

namespace LeasePlus_DevTest.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new Employee());
        }

        [HttpPost]
        public IActionResult Index(Employee employee)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "There was an error with your submission.");
                return View(employee);
            }
            // Calculate salary based on employee details
            decimal calculatedSalary = employee.CalculateSalary();
            ViewBag.CalculatedSalary = calculatedSalary;

            return View(employee);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FactoryDemo.Models;
using FactoryDemo.AppDbContext;
using FactoryDemo.Factory;
using FactoryDemo.Managers;
using Microsoft.EntityFrameworkCore;
using FactoryDemo.Services;

namespace FactoryDemo.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IEmployeeRepository _employeeRepository;

        public HomeController(ILogger<HomeController> logger,
                              IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var employeeList = await _employeeRepository.GetEmployeesAsync();
            return View(employeeList);
        }

        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Save(Employee newEmployee)
        {
            ModelState.Remove("newEmployee.Id");
            if (!ModelState.IsValid)
                return BadRequest();

            EmployeeManagerFactory employeeManagerFactory = new EmployeeManagerFactory();
            employeeManagerFactory.ApplyHourlyPayAndBonus(newEmployee);

            await _employeeRepository.CreateEmployeeAsync(newEmployee);

           
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

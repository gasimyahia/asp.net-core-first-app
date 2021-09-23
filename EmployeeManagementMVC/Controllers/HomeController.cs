using EmployeeManagementMVC.Models;
using EmployeeManagementMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(ILogger<HomeController> logger,IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        public ViewResult Index()
        {
            ViewData["Title"] = "Employee List";
            var employees = _employeeRepository.getAllEmployee();
            return View(employees);
        }

        public ViewResult details(int id)
        {
            ViewData["Title"] = "Employee Details";
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(id),
                PageTitle = "Employee Details"
           };
            
            // pass data to view
            //ViewBag.Employee = employee;

            return View(homeDetailsViewModel);
        }

        public ViewResult create()
        {
            ViewData["Title"] = "Create New Employee";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

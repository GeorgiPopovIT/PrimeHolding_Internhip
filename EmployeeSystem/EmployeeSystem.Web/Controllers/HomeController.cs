using EmployeeSystem.Core.Contracts;
using EmployeeSystem.Core.Employees.Models;
using EmployeeSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeSystem.Web.Controllers;

public class HomeController : Controller
{
    private readonly IEmployeeService _employeeService;

    public HomeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }
   

    public async Task<IActionResult> Index()
    {
        var employees = await this._employeeService.GetTop5Workers();
        var avgSalary = this._employeeService.AverageMonthlySalary();

        return View(new ListingEmployeesModel
        {
            Employees = employees,
            AverageSalary = avgSalary
		});
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
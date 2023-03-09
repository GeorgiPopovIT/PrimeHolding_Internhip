using EmployeeSystem.Core.Contracts;
using EmployeeSystem.Core.Employees.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSystem.Web.Controllers;

public class EmployeeController : Controller
{
	private readonly IEmployeeService _employeeService;

	public EmployeeController(IEmployeeService employeeService)
	{
		_employeeService = employeeService;
	}

	[HttpGet]
	public IActionResult Create()
	{
		return View(new EmployeeInputModel());
	}

	[HttpPost]
	public IActionResult Create(EmployeeInputModel model)
	{
		return View(new EmployeeInputModel());
	}
}

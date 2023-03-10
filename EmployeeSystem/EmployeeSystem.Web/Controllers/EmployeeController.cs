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
	public async Task<IActionResult> Create(EmployeeInputModel model)
	{
		if (!ModelState.IsValid)
		{
			return View(new EmployeeInputModel());
		}

		await this._employeeService.CreateEmployee(model);

		return RedirectToAction(nameof(Index), "Home");
	}

	[HttpGet]
	public async Task<IActionResult> Edit(int id)
	{
		var currentEmployee = await this._employeeService.GetEmployee(id);

		return View(currentEmployee);
	}

	[HttpPut]
	public async Task<IActionResult> Edit(EmployeeInputModel model)
	{
		if (!ModelState.IsValid)
		{
			return View(model);
		}

		await this._employeeService.UpdateEmployee(model);

		return RedirectToAction(nameof(Index), "Home");
	}


	[HttpDelete]
	public IActionResult Delete(int id)
	{
		this._employeeService.DeleteEmployee(id);

		return RedirectToAction(nameof(Index), "Home");
	}
}

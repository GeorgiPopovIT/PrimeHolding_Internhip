using EmployeeSystem.Core.Contracts;
using EmployeeSystem.Core.Tasks.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSystem.Web.Controllers;

public class TaskController : Controller
{
	private readonly ITaskService _taskService;

	public TaskController(ITaskService taskService)
	{
		_taskService = taskService;
	}

	[HttpGet]
	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Create(int employeeId, TaskInputModel model)
	{
		if (!ModelState.IsValid)
		{
			return View(model);
		}

		await this._taskService.CreateTask(employeeId, model);

		return RedirectToAction(nameof(Index), "Home");
	}

	[HttpGet]
	public IActionResult Edit(int id)
	{
		var currentTask = this._taskService.GetTask(id);

		return View(currentTask);
	}

	[HttpPost]
	public async Task<IActionResult> Edit(TaskInputModel model)
	{
		if (!ModelState.IsValid)
		{
			return View(model);
		}

		await this._taskService.UpdateTask(model);

		return RedirectToAction(nameof(Index), "Home");
	}

	[HttpPost]
	public IActionResult Delete(int id)
	{
		this._taskService.DeleteTask(id);

		return RedirectToAction(nameof(Index), "Home");
	}
}

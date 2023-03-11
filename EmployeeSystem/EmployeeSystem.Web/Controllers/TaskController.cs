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
	public IActionResult Create(int employeeId)
	{

		return View(new TaskInputModel { AssigneeId = employeeId});
	}

	[HttpPost]
	public async Task<IActionResult> Create(TaskInputModel model)
	{
		if (!ModelState.IsValid)
		{
			return View(model);
		}

		await this._taskService.CreateTask(model);

		return RedirectToAction(nameof(Index), "Home");
	}

	[HttpGet]
	public IActionResult Edit(int id)
	{
		var currentTask = this._taskService.GetTask(id);

		return View(currentTask);
	}

	[HttpPut]
	public async Task<IActionResult> Edit(TaskInputModel model)
	{
		if (!ModelState.IsValid)
		{
			return View(model);
		}

		await this._taskService.UpdateTask(model);

		return RedirectToAction(nameof(AllForEmployee), "Task");
	}

	[HttpGet]
	public IActionResult AllForEmployee(int employeeId)
	{
		var tasks = this._taskService.GetAllForEmployee(employeeId);

		return View(tasks);
	}

	[HttpPost]
	public IActionResult Delete(int id)
	{
		this._taskService.DeleteTask(id);

		return RedirectToAction(nameof(AllForEmployee), "Task");
	}
}

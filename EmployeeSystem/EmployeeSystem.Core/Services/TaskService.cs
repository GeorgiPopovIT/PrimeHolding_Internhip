using EmployeeSystem.Core.Contracts;
using EmployeeSystem.Core.Tasks.Models;
using EmployeeSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Task = EmployeeSystem.Infrastructure.Models.Task;

namespace EmployeeSystem.Core.Services;

public class TaskService : ITaskService
{
	private readonly EmployeeSystemDbContext _dbContext;

	public TaskService(EmployeeSystemDbContext _dbContext)
	{
		this._dbContext = _dbContext;
	}

	public async System.Threading.Tasks.Task CreateTask(TaskInputModel model)
	{
		var taskToCreate = new Task
		{
			Description = model.Description,
			AssigneeId = model.AssigneeId,
			DueDate = model.DueDate,
			Title = model.Title,
		};

		await this._dbContext.Tasks.AddAsync(taskToCreate);

		await this._dbContext.SaveChangesAsync();

	}

	public void DeleteTask(int id)
	{
		var taskToRemove = this._dbContext.Tasks.FirstOrDefault(t => t.Id == id);

		if (taskToRemove is null)
		{
			throw new ArgumentNullException("Invalid task.");
		}

		this._dbContext.Tasks.Remove(taskToRemove);

		this._dbContext.SaveChanges();
	}

	public TaskInputModel GetTask(int id)
	{
		var currentTask = this._dbContext.Tasks.FirstOrDefault(t => t.Id == id);

		if (currentTask is null)
		{
			throw new ArgumentNullException("Invalid task.");
		}

		return new TaskInputModel
		{
			Description = currentTask.Description,
			Title = currentTask.Title,
			DueDate = Convert.ToDateTime(currentTask.DueDate.ToShortTimeString()),
			AssigneeId = currentTask.AssigneeId
		};
	}

	public async System.Threading.Tasks.Task UpdateTask(TaskInputModel model)
	{
		var currentToEdit = await this._dbContext.Tasks
		   .FirstOrDefaultAsync(t => t.Id == model.Id);

		if (currentToEdit is null)
		{
			throw new ArgumentNullException("Invalid task.");
		}

		//should use Automapper

		currentToEdit.Title = model.Title;
		currentToEdit.Description = model.Description;
		currentToEdit.DueDate = model.DueDate;

		await this._dbContext.SaveChangesAsync();
	}

	public TaskForEmployeeViewModel GetAllForEmployee(int employeeId)
	{
		var tasksForEmployee = this._dbContext.Tasks
			.Where(t => t.AssigneeId == employeeId).Select(t => new TaskForEmployeeViewModel
			{
				EmployeeName = t.Assignee.FullName,
				Tasks = this._dbContext.Tasks.Select(t => new TaskInputModel
				{
					Id = t.Id,
					Description = t.Description,
					Title = t.Title,
					DueDate = t.DueDate,
				}).ToList()
			}).FirstOrDefault();

		return tasksForEmployee;
	}
}

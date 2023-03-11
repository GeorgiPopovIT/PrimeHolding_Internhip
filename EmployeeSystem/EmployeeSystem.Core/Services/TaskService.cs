using EmployeeSystem.Core.Contracts;
using EmployeeSystem.Core.Tasks.Models;
using EmployeeSystem.Infrastructure;
using Task = EmployeeSystem.Infrastructure.Models.Task;

namespace EmployeeSystem.Core.Services;

public class TaskService : ITaskService
{
	private readonly EmployeeSystemDbContext _dbContext;

	public TaskService(EmployeeSystemDbContext _dbContext)
	{
		this._dbContext = _dbContext;
	}

	public async System.Threading.Tasks.Task CreateTask(int employeeId,TaskInputModel model)
	{
		var taskToCreate = new Task
		{
			Description = model.Description,
			AssigneeId = employeeId,
			DueDate = model.DueDate,
			Title = model.Title,
		};

		await this._dbContext.Tasks.AddAsync(taskToCreate);

		await this._dbContext.SaveChangesAsync();

	}

	public void DeleteEmployee(int id)
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
			DueDate = currentTask.DueDate,
			AssigneeId = currentTask.AssigneeId
		};
	}

	public System.Threading.Tasks.Task UpdateTask(TaskInputModel model)
	{
		throw new NotImplementedException();
	}
}

using EmployeeSystem.Core.Contracts;
using EmployeeSystem.Infrastructure;

namespace EmployeeSystem.Core.Services;

public class TaskService : ITaskService
{
	private readonly EmployeeSystemDbContext _employeeSystemDbContext;

	public TaskService(EmployeeSystemDbContext employeeSystemDbContext)
	{
		_employeeSystemDbContext = employeeSystemDbContext;
	}

	public Task CreateTask()
	{
		throw new NotImplementedException();
	}

	public void DeleteTask(int id)
	{
		throw new NotImplementedException();
	}

	public Task GetTask(int id)
	{
		throw new NotImplementedException();
	}

	public Task UpdateTask()
	{
		throw new NotImplementedException();
	}
}

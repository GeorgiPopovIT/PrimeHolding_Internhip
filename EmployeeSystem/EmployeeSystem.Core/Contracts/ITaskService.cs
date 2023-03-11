using EmployeeSystem.Core.Tasks.Models;

namespace EmployeeSystem.Core.Contracts;

public interface ITaskService
{
    Task CreateTask(TaskInputModel model);

	TaskInputModel GetTask(int id);

    Task UpdateTask(TaskInputModel model);

    void DeleteTask(int id);

    TaskForEmployeeViewModel GetAllForEmployee(int employeeId);

}

using EmployeeSystem.Core.Models;

namespace EmployeeSystem.Core.Contracts;

public interface ITaskService
{
    Task CreateTask();

    //Task GetEmployee(int id);

    Task UpdateTask();

    void DeleteTask(int id);

}

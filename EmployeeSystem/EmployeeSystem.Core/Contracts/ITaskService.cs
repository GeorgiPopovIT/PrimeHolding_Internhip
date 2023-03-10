namespace EmployeeSystem.Core.Contracts;

public interface ITaskService
{
    Task CreateTask();

    Task GetTask(int id);

    Task UpdateTask();

    void DeleteTask(int id);

}

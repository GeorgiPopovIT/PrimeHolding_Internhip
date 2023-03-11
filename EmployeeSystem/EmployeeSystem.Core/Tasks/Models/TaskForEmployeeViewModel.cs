namespace EmployeeSystem.Core.Tasks.Models;

public class TaskForEmployeeViewModel
{
    public string EmployeeName { get; init; }

    public IEnumerable<TaskInputModel> Tasks { get; init; }
}

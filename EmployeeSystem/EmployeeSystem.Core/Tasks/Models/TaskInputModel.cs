using System.ComponentModel.DataAnnotations;

namespace EmployeeSystem.Core.Tasks.Models;

public class TaskInputModel
{
    [Required]
    public string Title { get; init; }

    [Required]
    public string Description { get; init; }

    [Required]
    public DateTime DueDate { get; init; }
}

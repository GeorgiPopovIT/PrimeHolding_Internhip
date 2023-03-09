using System.ComponentModel.DataAnnotations;

namespace EmployeeSystem.Infrastructure.Models;

public class Task : BaseModel
{
    [Required]
    public string Title { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public int AssigneeId { get; set; }

    public Employee Assignee { get; set; }

    [Required]
    public DateTime DueDate { get; set; } 
}

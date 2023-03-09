using System.ComponentModel.DataAnnotations;
using static EmployeeSystem.Infrastructure.ModelConstants.Task;

namespace EmployeeSystem.Infrastructure.Models;

public class Task : BaseModel
{
    [Required]
    [MaxLength(TITLE_MAX_LENGTH)]
    public string Title { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    [Required]
    public int AssigneeId { get; set; }

    public Employee Assignee { get; set; }

}

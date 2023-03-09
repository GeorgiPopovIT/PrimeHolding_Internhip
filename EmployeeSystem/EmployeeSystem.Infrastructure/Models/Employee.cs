using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static EmployeeSystem.Infrastructure.ModelConstants.Employee;

namespace EmployeeSystem.Infrastructure.Models;

public class Employee : BaseModel
{
    [Required]
    [MaxLength(FULL_NAME_MAX_LENGTH)]
    public string FullName { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string PhoneNumber  { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required]
    [Precision(14, 2)]
    public decimal MonthlySalary { get; set; }

    public ICollection<Task> Tasks { get; init; } = new HashSet<Task>();
}

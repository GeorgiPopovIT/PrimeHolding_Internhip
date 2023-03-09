using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static EmployeeSystem.Infrastructure.Constants.ModelConstantsValidation;

namespace EmployeeSystem.Infrastructure.Models;

public class Employee : BaseModel
{
    [Required(ErrorMessage = FULL_NAME_REQUIRED)]
    [MaxLength(FULL_NAME_MAX_LENGTH)]
    public string FullName { get; set; }

    [Required(ErrorMessage = EMAIL_REQUIRED)]
    public string Email { get; set; }

    public string PhoneNumber  { get; set; }

    public DateTime DateOfBirth { get; set; }

    [Precision(14, 2)]
    public decimal MonthlySalary { get; set; }

    public ICollection<Task> Tasks { get; init; } = new HashSet<Task>();
}

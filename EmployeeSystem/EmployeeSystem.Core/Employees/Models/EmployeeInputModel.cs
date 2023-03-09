using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static EmployeeSystem.Core.ModelsConstants.Employee;

namespace EmployeeSystem.Core.Employees.Models;

public class EmployeeInputModel
{
    public int Id { get; init; }

    [Required(ErrorMessage = FULL_NAME_REQUIRED)]
    [StringLength(FULL_NAME_MAX_LENGTH, ErrorMessage = FULL_NAME_LENGTH, MinimumLength = FULL_NAME_MIN_LENGTH)]
    public string FullName { get; set; }

    [Required(ErrorMessage = EMAIL_REQUIRED)]
    [EmailAddress(ErrorMessage = EMAIL_INVALID)]
    public string Email { get; set; }

    [Required(ErrorMessage = PHONE_REQUIRED)]
    [Phone]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = DATE_OF_BIRTH_REQUIRED)]
    public DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage = MONTHLY_SALARY_REQUIRED)]
    public decimal MonthlySalary { get; set; }
}

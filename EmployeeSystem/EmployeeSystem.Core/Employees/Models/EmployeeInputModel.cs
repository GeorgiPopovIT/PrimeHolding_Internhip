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
	[RegularExpression(@"^(\+359|0)\s?8(\d{2}\s\d{3}\d{3}|[789]\d{7})$", ErrorMessage = PHONE_INVALID)]
	public string PhoneNumber { get; set; }

    [Required(ErrorMessage = DATE_OF_BIRTH_REQUIRED)]
	[DataType(DataType.Date,ErrorMessage ="Invalid date.")]
	[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
    public DateTime DateOfBirth { get; set; } 

    [Required(ErrorMessage = MONTHLY_SALARY_REQUIRED)]

	public double MonthlySalary { get; set; }
	
}

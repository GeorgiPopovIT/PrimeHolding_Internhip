namespace EmployeeSystem.Core.Employees.Models;

public class ListingEmployeesModel
{
	public IEnumerable<EmployeeInputModel> Employees { get; init; }

    public decimal AverageSalary { get; init; }
}

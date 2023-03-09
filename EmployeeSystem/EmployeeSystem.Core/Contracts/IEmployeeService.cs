using EmployeeSystem.Core.Models;

namespace EmployeeSystem.Core.Contracts;

public interface IEmployeeService
{
    Task CreateEmployee(EmployeeInputModel model);

    Task GetEmployee(int id);

    Task UpdateEmployee(EmployeeInputModel model);

    Task DeleteEmployee(int id);

    Task<IEnumerable<EmployeeInputModel>> GetAll();
}

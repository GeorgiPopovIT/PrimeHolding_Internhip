using EmployeeSystem.Core.Employees.Models;

namespace EmployeeSystem.Core.Contracts;

public interface IEmployeeService
{
    Task CreateEmployee(EmployeeInputModel model);

    Task<EmployeeInputModel> GetEmployee(int id);

    Task UpdateEmployee(EmployeeInputModel model);

    void DeleteEmployee(int id);

    Task<IEnumerable<EmployeeInputModel>> GetAll();
}

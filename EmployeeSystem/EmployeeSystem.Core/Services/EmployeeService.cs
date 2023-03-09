using EmployeeSystem.Core.Contracts;
using EmployeeSystem.Core.Models;
using EmployeeSystem.Infrastructure;

namespace EmployeeSystem.Core.Services;

public class EmployeeService : IEmployeeService
{
    private readonly EmployeeSystemDbContext _dbContext;

    public EmployeeService(EmployeeSystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task CreateEmployee(EmployeeInputModel model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteEmployee(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<EmployeeInputModel>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task GetEmployee(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateEmployee(EmployeeInputModel model)
    {
        throw new NotImplementedException();
    }
}

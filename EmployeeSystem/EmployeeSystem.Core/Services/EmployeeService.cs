using EmployeeSystem.Core.Contracts;
using EmployeeSystem.Core.Employees.Models;
using EmployeeSystem.Infrastructure;
using EmployeeSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace EmployeeSystem.Core.Services;

public class EmployeeService : IEmployeeService
{
    private readonly EmployeeSystemDbContext _dbContext;

    public EmployeeService(EmployeeSystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateEmployee(EmployeeInputModel model)
    {
        var employeeToAdd = new Employee
        {
            FullName = model.FullName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            DateOfBirth = model.DateOfBirth,
            MonthlySalary = (decimal)model.MonthlySalary,
        };

        await this._dbContext.Employees.AddAsync(employeeToAdd);

        await this._dbContext.SaveChangesAsync();
    }

    public void DeleteEmployee(int id)
    {
        var employeeToRemove = this._dbContext.Employees.FirstOrDefault(e => e.Id == id);

        if (employeeToRemove is null)
        {
            throw new ArgumentNullException("Invalid employee.");
        }

        this._dbContext.Employees.Remove(employeeToRemove);

        this._dbContext.SaveChanges();
    }

    public async Task<IEnumerable<EmployeeInputModel>> GetTop5Workers()
        => await this._dbContext.Employees
        .OrderByDescending(x => x.Tasks.Count()).Select(e => new EmployeeInputModel
        {
            Id = e.Id,
            Email = e.Email,
            FullName = e.FullName,
            DateOfBirth = e.DateOfBirth,
            MonthlySalary = (double)e.MonthlySalary,
            PhoneNumber = e.PhoneNumber,
            TasksCount = e.Tasks.Count()
		}).ToListAsync();

    public async Task<EmployeeInputModel> GetEmployee(int id)
    {
        var currentEmployee = await this._dbContext.Employees
            .FirstOrDefaultAsync(e => e.Id == id);

        if (currentEmployee is null)
        {
            throw new ArgumentNullException("Invalid ID.");
        }

        return new EmployeeInputModel
        {
            Id = id,
            Email = currentEmployee.Email,
            FullName = currentEmployee.FullName,
            DateOfBirth = currentEmployee.DateOfBirth,
            PhoneNumber = currentEmployee.PhoneNumber,
            MonthlySalary = (double)currentEmployee.MonthlySalary,
            TasksCount = currentEmployee.Tasks.Count()
        };
    }

    public async Task UpdateEmployee(EmployeeInputModel model)
    {
        var currentToEdit = await this._dbContext.Employees
            .FirstOrDefaultAsync(e => e.Id == model.Id);

        if (currentToEdit is null)
        {
            throw new ArgumentNullException("Invalid employee.");
        }

        //should use Automapper

        currentToEdit.FullName = model.FullName;
        currentToEdit.PhoneNumber = model.PhoneNumber;
        currentToEdit.Email = model.Email;
        currentToEdit.DateOfBirth = model.DateOfBirth;
        currentToEdit.MonthlySalary = (decimal)model.MonthlySalary;

        await this._dbContext.SaveChangesAsync();
    }

    public decimal AverageMonthlySalary()
        => this._dbContext.Employees.Average(e => e.MonthlySalary);
}

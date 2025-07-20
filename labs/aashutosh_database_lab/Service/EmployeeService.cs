using aashutosh_database_lab.Data;
using aashutosh_database_lab.Models;
using Microsoft.EntityFrameworkCore;

namespace aashutosh_database_lab.Service;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetEmployeesAsync();
    Task<Employee?> GetEmployeeAsync(int id);
    Task<Employee> CreateEmployeeAsync(Employee employee);
    Task<Employee> UpdateEmployeeAsync(Employee employee);
    Task DeleteEmployeeAsync(int id);
    Task<int> GetCountEmployeesAsync(Employee conditions);
    Task<List<Employee>> GetEmployeesOrderedByBalanceAsync(int count = 5);
    Task<decimal> GetTotalBalanceAsync(int count = 5);
    Task<(decimal totalBalance, List<Employee> employees)> GetAggregateBalanceWithEmployeesAsync(int count = 5);

}

public class EmployeeService : IEmployeeService
{
    private readonly AppDbContext _context;

    public EmployeeService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee?> GetEmployeeAsync(int id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public async Task<Employee> CreateEmployeeAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee> UpdateEmployeeAsync(Employee employee)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null) return;
        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
    }

    public async Task<int> GetCountEmployeesAsync(Employee conditions)
    {
        return await _context.Employees.CountAsync(emp => conditions.Equals(emp));
    }


    public async Task<List<Employee>> GetEmployeesOrderedByBalanceAsync(int count = 5)
    {
        return await _context.Employees
            .OrderByDescending(e => e.Salary)
            .Take(count)
            .ToListAsync();
    }
    public async Task<decimal> GetTotalBalanceAsync(int count = 5)
    {
        return await _context.Employees
            .OrderByDescending(e => e.Salary)
            .Take(count)
            .SumAsync(e => e.Salary);
    }

    public async Task<(decimal totalBalance, List<Employee> employees)> GetAggregateBalanceWithEmployeesAsync(int count = 5)
    {
        var employees = await GetEmployeesOrderedByBalanceAsync(count);
        var totalBalance = employees.Sum(e => e.Salary);

        return (totalBalance, employees);
    }

}
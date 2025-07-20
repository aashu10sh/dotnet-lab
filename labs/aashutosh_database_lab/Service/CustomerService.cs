using aashutosh_database_lab.Data;
using aashutosh_database_lab.Models;
using Microsoft.EntityFrameworkCore;

namespace aashutosh_database_lab.Service;


public interface ICustomerService
{
    public Task<Customer?> GetEmployeeAsync(int id);
    public Task<List<Customer>> GetCustomerWithConditionsAsync(Customer conditions);
    public Task<Customer> CreateCustomerAsync(Customer customer);
}
public class CustomerService: ICustomerService
{
    private readonly AppDbContext _context;

    public CustomerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Customer?> GetEmployeeAsync(int id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task<List<Customer>> GetCustomerWithConditionsAsync(Customer conditions)
    {
        return await _context.Customers.Where(c => c.Balance > conditions.Balance).ToListAsync();
    }

    public async Task<Customer> CreateCustomerAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
        return customer;
    }


}
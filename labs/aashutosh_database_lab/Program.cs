// See https://aka.ms/new-console-template for more information

using aashutosh_database_lab.Data;
using aashutosh_database_lab.Models;
using aashutosh_database_lab.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace aashutosh_database_lab
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var connectionString =
                "Server=localhost,1433;Database=UserCrudDb;User Id=sa;Password=Contraseña12345678;TrustServerCertificate=true;";
            var options = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(connectionString).Options;

            using var context = new AppDbContext(options);

            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            var customerService = new CustomerService(context);
            
            await CreateCustomer(customerService, "Aashutosh", "LogPoint", 7700);
            await CreateCustomer(customerService, "Krish", "SpaceX", 7100);
            await CreateCustomer(customerService, "Pranjal", "Mad Yeti Games", 2100);
            await CreateCustomer(customerService, "Samrat", "Vercel", 4900);
            await CreateCustomer(customerService, "Newton", "Valve", 6100);
                
            List<Customer> richCustomers = await customerService.GetCustomerWithConditionsAsync(
                new Customer
                {
                    Name = "",
                    Company = "",
                    AccountNumber = Guid.Empty,
                    Balance = 5000
                }
            );
            
            Console.WriteLine("Customers with Balance greater than 5000: ");

            foreach (var richCustomer in richCustomers)
            {
                Console.WriteLine(richCustomer.TOString());
            }
            

            Console.WriteLine("Created by Aashutosh Pudasaini - 1202");


        }

        static async Task<Customer> CreateCustomer(ICustomerService customerService, string name, string company,
            int balance)
        {
            var customer = new Customer
            {
                Name = name,
                Company = company,
                Balance = balance,
                AccountNumber = Guid.NewGuid()
            };
            return await customerService.CreateCustomerAsync(customer);

        }

        static async Task<Employee> CreateEmployee(EmployeeService es, string first_name, string last_name, string company, int salary)
        {
            var employee = new Employee
            {
                FirstName = first_name,
                LastName = last_name,
                Salary = salary,
                Company = company
            };
            return await es.CreateEmployeeAsync(employee);
        }
        static async Task ComputeAggregateBalanceAndDisplay(IEmployeeService employeeService)
        {
            Console.WriteLine("=== Employee Balance Analysis ===\n");

            var (totalBalance, employees) = await employeeService.GetAggregateBalanceWithEmployeesAsync(5);

            Console.WriteLine($"Aggregate Balance of Top 5 Employees: ${totalBalance:N2}\n");

            Console.WriteLine("Employee Records (Ordered by Balance - Descending):");
            Console.WriteLine(new string('-', 80));
            Console.WriteLine($"{"ID",-5} {"Name",-20} {"Department",-15} {"Balance",-15} {"Hire Date",-12}");
            Console.WriteLine(new string('-', 80));

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Id,-5} {employee.FirstName,-20} {employee.Company,-15} ${employee.Salary,-14:N2} {employee.CreatedAt:MM/dd/yyyy}");
            }

            Console.WriteLine(new string('-', 80));
            Console.WriteLine($"Total Records: {employees.Count}");
            Console.WriteLine($"Average Balance: ${employees.Average(e => e.Salary):N2}");
        }
    }

}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserCrudConsole.Data;
using UserCrudConsole.Models;
using UserCrudConsole.Services;
using System.ComponentModel.DataAnnotations;

namespace UserCrudConsole
{
    class Program
    {
        private static UserService? _userService;

        static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? 
                "Server=localhost,1433;Database=UserCrudDb;User Id=sa;Password=Contraseña12345678;TrustServerCertificate=true;";

            var options = new DbContextOptionsBuilder<UserDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            using var context = new UserDbContext(options);
            
            await context.Database.EnsureCreatedAsync();
            
            _userService = new UserService(context);

            Console.WriteLine("=== User CRUD Console Application ===");
            Console.WriteLine("Done by Aashutosh Pudasaini 1202");
            Console.WriteLine();

            bool exit = false;
            while (!exit)
            {
                ShowMenu();
                var choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            await ListAllUsers();
                            break;
                        case "2":
                            await GetUserById();
                            break;
                        case "3":
                            await CreateUser();
                            break;
                        case "4":
                            await UpdateUser();
                            break;
                        case "5":
                            await DeleteUser();
                            break;
                        case "6":
                            exit = true;
                            Console.WriteLine("Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. List all users");
            Console.WriteLine("2. Get user by ID");
            Console.WriteLine("3. Create new user");
            Console.WriteLine("4. Update user");
            Console.WriteLine("5. Delete user");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice (1-6): ");
        }

        static async Task ListAllUsers()
        {
            Console.WriteLine("\n=== All Users ===");
            var users = await _userService!.GetAllUsersAsync();
            
            if (users.Count == 0)
            {
                Console.WriteLine("No users found.");
                return;
            }

            foreach (var user in users)
            {
                Console.WriteLine(user.ToString());
            }
        }

        static async Task GetUserById()
        {
            Console.Write("\nEnter User ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var user = await _userService!.GetUserByIdAsync(id);
                if (user != null)
                {
                    Console.WriteLine($"\n=== User Details ===");
                    Console.WriteLine(user.ToString());
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
        }

        static async Task CreateUser()
        {
            Console.WriteLine("\n=== Create New User ===");
            
            var user = new User();
            
            Console.Write("First Name: ");
            user.FirstName = Console.ReadLine() ?? "";
            
            Console.Write("Last Name: ");
            user.LastName = Console.ReadLine() ?? "";
            
            Console.Write("Email: ");
            user.Email = Console.ReadLine() ?? "";
            
            Console.Write("Phone Number (optional): ");
            var phone = Console.ReadLine();
            user.PhoneNumber = string.IsNullOrWhiteSpace(phone) ? null : phone;

            // Validate user input
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(user);
            
            if (!Validator.TryValidateObject(user, validationContext, validationResults, true))
            {
                Console.WriteLine("Validation errors:");
                foreach (var error in validationResults)
                {
                    Console.WriteLine($"- {error.ErrorMessage}");
                }
                return;
            }

            // Check if email already exists
            if (await _userService!.EmailExistsAsync(user.Email))
            {
                Console.WriteLine("A user with this email already exists.");
                return;
            }

            try
            {
                var createdUser = await _userService.CreateUserAsync(user);
                Console.WriteLine($"User created successfully with ID: {createdUser.Id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating user: {ex.Message}");
            }
        }

        static async Task UpdateUser()
        {
            Console.Write("\nEnter User ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            var existingUser = await _userService!.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Console.WriteLine($"\n=== Updating User: {existingUser.FirstName} {existingUser.LastName} ===");
            Console.WriteLine("(Press Enter to keep current value)");

            var updatedUser = new User { Id = id };

            Console.Write($"First Name [{existingUser.FirstName}]: ");
            var firstName = Console.ReadLine();
            updatedUser.FirstName = string.IsNullOrWhiteSpace(firstName) ? existingUser.FirstName : firstName;

            Console.Write($"Last Name [{existingUser.LastName}]: ");
            var lastName = Console.ReadLine();
            updatedUser.LastName = string.IsNullOrWhiteSpace(lastName) ? existingUser.LastName : lastName;

            Console.Write($"Email [{existingUser.Email}]: ");
            var email = Console.ReadLine();
            updatedUser.Email = string.IsNullOrWhiteSpace(email) ? existingUser.Email : email;

            Console.Write($"Phone Number [{existingUser.PhoneNumber ?? "None"}]: ");
            var phone = Console.ReadLine();
            updatedUser.PhoneNumber = string.IsNullOrWhiteSpace(phone) ? existingUser.PhoneNumber : phone;

            // Validate user input
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(updatedUser);
            
            if (!Validator.TryValidateObject(updatedUser, validationContext, validationResults, true))
            {
                Console.WriteLine("Validation errors:");
                foreach (var error in validationResults)
                {
                    Console.WriteLine($"- {error.ErrorMessage}");
                }
                return;
            }

            // Check if email already exists (excluding current user)
            if (await _userService.EmailExistsAsync(updatedUser.Email, id))
            {
                Console.WriteLine("A user with this email already exists.");
                return;
            }

            try
            {
                var success = await _userService.UpdateUserAsync(id, updatedUser);
                if (success)
                {
                    Console.WriteLine("User updated successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to update user.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating user: {ex.Message}");
            }
        }

        static async Task DeleteUser()
        {
            Console.Write("\nEnter User ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            var user = await _userService!.GetUserByIdAsync(id);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Console.WriteLine($"\nAre you sure you want to delete this user?");
            Console.WriteLine(user.ToString());
            Console.Write("Type 'yes' to confirm: ");
            
            var confirmation = Console.ReadLine();
            if (confirmation?.ToLower() == "yes")
            {
                try
                {
                    var success = await _userService.DeleteUserAsync(id);
                    if (success)
                    {
                        Console.WriteLine("User deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to delete user.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting user: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Delete operation cancelled.");
            }
        }
    }
}
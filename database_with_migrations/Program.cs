using database_with_migrations.Data;
using database_with_migrations.Models;
using Microsoft.EntityFrameworkCore;

namespace database_with_migrations
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello Wordl");
            var connectionString = "Server=localhost,1433;Database=UserCrudDb;User Id=sa;Password=YourPassword123!;TrustServerCertificate=true";
            var options = new DbContextOptionsBuilder<UserModelDbContext>().UseSqlServer(connectionString).Options;
        }

    }
}
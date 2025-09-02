using Microsoft.EntityFrameworkCore;

namespace auth_and_authorization.Models;

public class AppDbContext: DbContext
{
    AppDbContext(DbContextOptions<AppDbContext> options): base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Console.Write("ModelBuilder.OnModelCreating");
        base.OnModelCreating(modelBuilder);
    }
    
}
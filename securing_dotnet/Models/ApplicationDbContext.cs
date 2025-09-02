using Microsoft.EntityFrameworkCore;

namespace securing_dotnet.Models;

public class ApplicationDbContext: DbContext
{
    public DbSet<Todo> Todos { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=securing_dotnet.db");
    }
}
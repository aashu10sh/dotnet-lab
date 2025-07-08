using database_with_migrations.Models;
using Microsoft.EntityFrameworkCore;

namespace database_with_migrations.Data
{
public class UserModelDbContext : DbContext
{
    public UserModelDbContext(DbContextOptions<UserModelDbContext> options) : base(options)
    {
        
    }
    public DbSet<UserModel> Users { get; set; }
    
    public UserModelDbContext(){}
    protected override void onConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=UserCrudDb;User Id=sa;Password=YourPassword123!;TrustServerCertificate=true;");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.HasIndex(e => e.Email).IsUnique();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
        });
        base.OnModelCreating(modelBuilder);
    }
}
}


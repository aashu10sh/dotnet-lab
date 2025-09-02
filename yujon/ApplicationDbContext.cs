using yujon.Models;

namespace yujon;

using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}
    public DbSet<Dancer> Dancers { get; set; }
    
}
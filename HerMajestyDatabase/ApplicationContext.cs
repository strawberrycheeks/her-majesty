namespace HerMajestyDatabase;

using Microsoft.EntityFrameworkCore;
 
public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
 
    public ApplicationContext()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=hermajesty;Username=admin;Password=1234");
    }
}
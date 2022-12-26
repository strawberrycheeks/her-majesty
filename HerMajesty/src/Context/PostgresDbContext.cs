using Microsoft.EntityFrameworkCore;

using HerMajesty.DbModel;

namespace HerMajesty.Context;

public class PostgresDbContext : DbContext
{
    public DbSet<ContenderEntity> Contenders => Set<ContenderEntity>();
    public DbSet<AttemptEntity> Attempts => Set<AttemptEntity>();

    public PostgresDbContext(DbContextOptions<PostgresDbContext> options) :
        base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
    }
}
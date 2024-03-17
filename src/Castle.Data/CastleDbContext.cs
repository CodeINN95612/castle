using Microsoft.EntityFrameworkCore;

namespace Castle.Data;

public class CastleDbContext(DbContextOptions<CastleDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CastleDbContext).Assembly);
    }
}

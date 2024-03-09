using Castle.Domain.Entities.Parties;

using Microsoft.EntityFrameworkCore;

namespace Castle.Infrastructure.Data;

public class CastleDbContext(DbContextOptions<CastleDbContext> options) : DbContext(options)
{
    public virtual DbSet<Party> Parties { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CastleDbContext).Assembly);
    }
}

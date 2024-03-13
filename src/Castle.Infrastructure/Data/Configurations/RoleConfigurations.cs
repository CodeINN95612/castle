using Castle.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Castle.Infrastructure.Data.Configurations;

public class RoleConfigurations : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");

        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => new RoleId(value)
            );

        builder.Property(r => r.Name)
            .HasMaxLength(32);

        builder.HasMany(c => c.ElectionEntries)
            .WithOne(e => e.Role)
            .HasForeignKey(e => e.IdRole);
    }
}

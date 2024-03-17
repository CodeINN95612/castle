using Castle.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Castle.Data.Configurations;

public class LocationConfigurations : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("Locations");

        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => new LocationId(value)
            );

        builder.Property(l => l.Name)
            .IsUnicode()
            .HasMaxLength(32);

        builder.HasMany(c => c.ElectionEntries)
            .WithOne(e => e.Location)
            .HasForeignKey(e => e.IdLocation);
    }
}
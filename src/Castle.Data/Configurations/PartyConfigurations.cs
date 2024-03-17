using Castle.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Castle.Data.Configurations;

public sealed class PartyConfigurations : IEntityTypeConfiguration<Party>
{
    public void Configure(EntityTypeBuilder<Party> builder)
    {
        builder.ToTable("Parties");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => new PartyId(value)
            );

        builder.Property(p => p.Name)
            .IsUnicode()
            .HasMaxLength(128);

        builder.Property(p => p.Initials)
            .IsUnicode()
            .HasMaxLength(8);

        builder.Property(p => p.Number)
            .HasMaxLength(8);

        builder.HasIndex(p => p.Initials)
            .IsUnique();

        builder.HasMany(c => c.ElectionEntries)
            .WithOne(e => e.Party)
            .HasForeignKey(e => e.IdParty);
    }
}
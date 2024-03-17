using Castle.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Castle.Data.Configurations;

public class ElectionConfigurations : IEntityTypeConfiguration<Election>
{
    public void Configure(EntityTypeBuilder<Election> builder)
    {
        builder.ToTable("Elections");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasMaxLength(32)
            .HasConversion(
                id => id.Value,
                value => new ElectionId(value)
            );

        builder.Property(e => e.IdWinnerResult)
            .IsRequired(false)
            .ValueGeneratedNever()
            .HasConversion<Guid?>(
                id => id == null ? null : id.Value,
                value => value == null ? null : new RoundResultId(value!.Value)
            );

        builder.HasOne(e => e.WinnerResult)
            .WithOne(e => e.WonElection)
            .HasForeignKey<Election>(e => e.IdWinnerResult);

        builder.HasMany(e => e.Rounds)
            .WithOne(e => e.Election)
            .HasForeignKey(e => e.IdElection);

        builder.HasMany(e => e.ElectionEntries)
            .WithOne(e => e.Election)
            .HasForeignKey(e => e.IdElection);
    }
}

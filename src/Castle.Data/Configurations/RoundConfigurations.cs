using Castle.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Castle.Data.Configurations;

public class RoundConfigurations : IEntityTypeConfiguration<Round>
{
    public void Configure(EntityTypeBuilder<Round> builder)
    {
        builder.ToTable("Rounds");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => new RoundId(value)
            );

        builder.Property(e => e.IdElection)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => new ElectionId(value)
            );

        builder.HasOne(e => e.Election)
            .WithMany(e => e.Rounds)
            .HasForeignKey(e => e.IdElection);

        builder.HasMany(e => e.RoundResults)
            .WithOne(e => e.Round)
            .HasForeignKey(e => e.IdRound);

        builder.HasMany(e => e.Votes)
            .WithOne(e => e.Round)
            .HasForeignKey(e => e.IdRound);
    }
}
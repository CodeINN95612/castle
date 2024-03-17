using Castle.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Castle.Data.Configurations;

public class RoundResultConfigurations : IEntityTypeConfiguration<RoundResult>
{
    public void Configure(EntityTypeBuilder<RoundResult> builder)
    {
        builder.ToTable("RoundResults");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => new RoundResultId(value)
            );

        builder.Property(e => e.IdRound)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => new RoundId(value)
            );

        builder.Property(e => e.IdElectionEntry)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => new ElectionEntryId(value)
            );

        builder.HasOne(e => e.WonElection)
            .WithOne(e => e.WinnerResult)
            .HasForeignKey<Election>(e => e.IdWinnerResult);

        builder.HasOne(e => e.Round)
            .WithMany(e => e.RoundResults)
            .HasForeignKey(e => e.IdRound);

        builder.HasOne(e => e.ElectionEntry)
            .WithMany(e => e.RoundResults)
            .HasForeignKey(e => e.IdElectionEntry);
    }
}
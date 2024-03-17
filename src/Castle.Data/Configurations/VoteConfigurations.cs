using Castle.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Castle.Data.Configurations;

public class VoteConfigurations : IEntityTypeConfiguration<Vote>
{
    public void Configure(EntityTypeBuilder<Vote> builder)
    {
        builder.ToTable("Votes");

        builder.HasKey(v => v.Id);
        builder.Property(v => v.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => new VoteId(value)
            );

        builder.Property(v => v.IdentificationVoter)
            .HasConversion(
                id => id.Value,
                value => new VoterId(value)
            );

        builder.Property(v => v.IdElectionEntry)
            .HasConversion(
                id => id.Value,
                value => new ElectionEntryId(value)
            );

        builder.Property(v => v.IdRound)
            .HasConversion(
                id => id.Value,
                value => new RoundId(value)
            );

        builder.HasOne(v => v.Voter)
            .WithMany()
            .HasForeignKey(v => v.IdentificationVoter);

        builder.HasOne(v => v.Round)
            .WithMany()
            .HasForeignKey(v => v.IdRound);

        builder.HasOne(v => v.ElectionEntry)
            .WithMany()
            .HasForeignKey(v => v.IdElectionEntry);
    }
}

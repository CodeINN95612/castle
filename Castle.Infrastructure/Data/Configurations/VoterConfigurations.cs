using Castle.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Castle.Infrastructure.Data.Configurations;

public class VoterConfigurations : IEntityTypeConfiguration<Voter>
{
    public void Configure(EntityTypeBuilder<Voter> builder)
    {
        builder.ToTable("Voters");

        builder.HasKey(v => v.Id);
        builder.Property(v => v.Id)
            .ValueGeneratedNever()
            .HasMaxLength(32)
            .HasConversion(
                id => id.Value,
                value => new VoterId(value)
            );

        builder.Property(v => v.DateOfBirthBytes)
            .HasMaxLength(32);


        builder.Property(v => v.SignCodebytes)
            .HasMaxLength(32);

        builder.HasMany(v => v.Votes)
            .WithOne(v => v.Voter)
            .HasForeignKey(v => v.IdentificationVoter);
    }
}
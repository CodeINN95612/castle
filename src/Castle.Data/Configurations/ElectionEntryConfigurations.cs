using Castle.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Castle.Data.Configurations;

public class ElectionEntryConfigurations : IEntityTypeConfiguration<ElectionEntry>
{
    public void Configure(EntityTypeBuilder<ElectionEntry> builder)
    {
        builder.ToTable("ElectionEntries");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => new ElectionEntryId(value)
            );

        builder.Property(e => e.IdElection)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => new ElectionId(value)
            );

        builder.Property(e => e.IdCandidate)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => new CandidateId(value)
            );

        builder.Property(e => e.IdParty)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => new PartyId(value)
            );

        builder.Property(e => e.IdRole)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => new RoleId(value)
            );

        builder.Property(e => e.IdLocation)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => new LocationId(value)
            );

        builder.HasIndex(e => new { e.IdElection, e.IdCandidate })
            .IsUnique();

        builder.HasOne(e => e.Election)
            .WithMany(e => e.ElectionEntries)
            .HasForeignKey(e => e.IdElection);

        builder.HasOne(e => e.Candidate)
            .WithMany(e => e.ElectionEntries)
            .HasForeignKey(e => e.IdCandidate);

        builder.HasOne(e => e.Party)
            .WithMany(e => e.ElectionEntries)
            .HasForeignKey(e => e.IdParty);

        builder.HasOne(e => e.Role)
            .WithMany(e => e.ElectionEntries)
            .HasForeignKey(e => e.IdRole);

        builder.HasOne(e => e.Location)
            .WithMany(e => e.ElectionEntries)
            .HasForeignKey(e => e.IdLocation);

    }
}
using Castle.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Castle.Infrastructure.Data.Configurations;

public sealed class CandidateConfigurations : IEntityTypeConfiguration<Candidate>
{
    public void Configure(EntityTypeBuilder<Candidate> builder)
    {
        builder.ToTable("Candidates");
        
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => new CandidateId(value)
            );

        builder.Property(c => c.Name)
            .IsUnicode()
            .HasMaxLength(32);

        builder.Property(c => c.Identification)
            .HasMaxLength(32);        

        builder.HasMany(c => c.ElectionEntries)
            .WithOne(e => e.Candidate)
            .HasForeignKey(e => e.IdCandidate);
    }
}
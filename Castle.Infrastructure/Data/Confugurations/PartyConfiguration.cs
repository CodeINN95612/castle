using Castle.Domain.Entities.Parties;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Castle.Infrastructure.Data.Confugurations;
public class PartyConfiguration : IEntityTypeConfiguration<Party>
{
    public void Configure(EntityTypeBuilder<Party> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.ToTable(nameof(Party));

        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id).HasConversion(
            id => id.Value,
            value => new PartyId(value));

        builder.Property(p => p.Name)
            .HasMaxLength(128)
            .IsRequired();
    }
}

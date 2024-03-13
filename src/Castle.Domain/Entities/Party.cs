namespace Castle.Domain.Entities;

public record PartyId(Guid Value);

public class Party : BaseEntity<PartyId>
{
    public required string Name { get; set; }
    public required string Initials { get; set; }
    public required string Number { get; set; }
    
    public required ICollection<ElectionEntry> ElectionEntries { get; set; }
}

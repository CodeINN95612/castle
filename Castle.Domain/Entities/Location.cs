namespace Castle.Domain.Entities;

public record LocationId(Guid Value);


public class Location : BaseEntity<LocationId>
{
    public required string Name { get; set; }
    
    public required ICollection<ElectionEntry> ElectionEntries { get; set; }
}
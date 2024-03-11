namespace Castle.Domain.Entities;

public record RoleId(Guid Value);

public class Role : BaseEntity<RoleId>
{
    public required string Name { get; set; }
    
    public required ICollection<ElectionEntry> ElectionEntries { get; set; }
}

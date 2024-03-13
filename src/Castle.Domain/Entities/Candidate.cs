namespace Castle.Domain.Entities;

public record CandidateId(Guid Value);

public class Candidate : BaseEntity<CandidateId>
{
    public required string Name { get; set; }
    public required string Identification { get; set; }
    public required DateTime DateOfBirth { get; set; }
    
    public required ICollection<ElectionEntry> ElectionEntries { get; set; }
}

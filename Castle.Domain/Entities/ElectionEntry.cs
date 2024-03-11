namespace Castle.Domain.Entities;

public record ElectionEntryId(Guid Value);

public class ElectionEntry : BaseEntity<ElectionEntryId>
{
    public required ElectionId IdElection { get; set; }
    public required CandidateId IdCandidate { get; set; }
    public required PartyId IdParty { get; set; }
    public required RoleId IdRole { get; set; }
    public required LocationId IdLocation { get; set; }
    public required DateTime Date { get; set; }

    public required Election Election { get; set; }
    public required Candidate Candidate { get; set; }
    public required ICollection<RoundResult> RoundResults { get; set; }
    public required ICollection<Vote> Votes { get; set; }
}

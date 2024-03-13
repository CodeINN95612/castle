namespace Castle.Domain.Entities;

public record VoteId(Guid Value);

public class Vote : BaseEntity<VoteId>
{
    public required VoterId IdentificationVoter { get; set; }
    public required RoundId IdRound { get; set; }
    public required ElectionEntryId IdElectionEntry { get; set; }
    public required DateTime DateUtc { get; set; }

    public required Voter Voter { get; set; }
    public required Round Round { get; set; }
    public required ElectionEntry ElectionEntry { get; set; }
}

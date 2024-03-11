namespace Castle.Domain.Entities;

public record VoteId(Guid Value);

public class Vote : BaseEntity<VoteId>
{
    public required VoterId IdVoter { get; set; }
    public required RoundId IdRound { get; set; }
    public required ElectionEntryId IdElectionEntry { get; set; }
    public required DateTime Date { get; set; }

    public required Voter Voter { get; set; }
    public required Round Round { get; set; }
    public required ElectionEntry ElectionEntry { get; set; }
}

namespace Castle.Domain.Entities;

public record RoundResultId(Guid Value);

public class RoundResult : BaseEntity<RoundResultId>
{
    public required RoundId IdRound { get; set; }
    public required ElectionEntryId IdElectionEntry { get; set; }
    public required int Votes { get; set; }

    public required Election? WonElection {get;set;}
    public required Round Round { get; set; }
    public required ElectionEntry ElectionEntry { get; set; }
}

namespace Castle.Domain.Entities;

public record RoundId(Guid Value);

public class Round : BaseEntity<RoundId>
{
    public required ElectionId IdElection { get; set; }

    public required int Number { get; set; }
    public required DateTime VoteDate { get; set; }
    public required bool IsClosed { get; set; }

    public required Election Election { get; set; }
    public required ICollection<RoundResult> RoundResults { get; set; }
    public required ICollection<Vote> Votes { get; set; }
}

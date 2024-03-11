namespace Castle.Domain.Entities;

public record ElectionId(Guid Value);

public class Election : BaseEntity<ElectionId>
{
    public required RoundResultId? IdWinnerResult { get; set; }
    public required int RoundCount { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime? EndDate { get; set; }

    public required RoundResult? WinnerResult { get; set; }
    public required ICollection<Round> Rounds { get; set; }
    public required ICollection<ElectionEntry> ElectionEntries { get; set; }
}
namespace Castle.Data.Entities;

public record VoterId(byte[] Value);

public class Voter : BaseEntity<VoterId>
{
    public required byte[] DateOfBirthBytes { get; set; }
    public required byte[] SignCodebytes { get; set; }

    public required ICollection<Vote> Votes { get; set; }
}

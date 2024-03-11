namespace Castle.Domain.Entities;

public record VoterId(byte[] Value);

public class Voter : BaseEntity<VoterId>
{
    public required byte[]  DateOfBirthBytes { get; set; }
    public required byte[]  SignCodebytes { get; set; }
}

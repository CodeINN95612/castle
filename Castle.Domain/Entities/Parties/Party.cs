namespace Castle.Domain.Entities.Parties;

public class Party
{
    public PartyId Id { get; }
    public string Name { get; }

    private Party(PartyId id, string name)
    {
        Id = id;
        Name = name;
    }

    public static Party Create(PartyId id, string name)
    {
        return new Party(id, name);
    }
}

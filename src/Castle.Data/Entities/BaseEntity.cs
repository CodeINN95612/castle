namespace Castle.Data.Entities;

public abstract class BaseEntity<TId>
{
    public required TId Id { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public required DateTime UpdatedAtUtc { get; set; }
}
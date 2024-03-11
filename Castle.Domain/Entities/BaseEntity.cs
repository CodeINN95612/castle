namespace Castle.Domain.Entities;

public abstract class BaseEntity<TId>
{
    public required TId Id { get; set; }
    public required bool IsDeleted { get; set; }
    public required DateTime CreatedAtDate { get; set; }
    public required DateTime UpdatedAtDate { get; set; }
}
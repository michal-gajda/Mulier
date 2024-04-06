namespace Mulier.Domain.Events;

public sealed class ToDoItemUpserted : IDomainEvent
{
    public required ToDoItemId Id { get; init; }
    public required string Description { get; init; }
    public required DateTime? ExpirationDateTime { get; init; }
    public required string Title { get; init; }
}

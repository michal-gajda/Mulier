namespace Mulier.Domain.Events;

public sealed class ToDoItemRemoved : IDomainEvent
{
    public required ToDoItemId Id { get; init; }
}

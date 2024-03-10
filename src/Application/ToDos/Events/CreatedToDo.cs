namespace Mulier.Application.ToDos.Events;

public sealed record class CreatedToDo : INotification
{
    public required ToDoId Id { get; init; }
}

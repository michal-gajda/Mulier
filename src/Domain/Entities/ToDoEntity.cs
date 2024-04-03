namespace Mulier.Domain.Entities;

using Mulier.Domain.Exceptions;
using Mulier.Domain.Events;

public sealed class ToDoEntity
{
    private readonly Dictionary<ToDoItemId, ToDoItemEntity> items = new();

    public ToDoId Id { get; private init; }
    public string Title { get; private set; } = string.Empty;
    
    private IList<IDomainEvent> events = new List<IDomainEvent>();
    
    public ToDoEntity(ToDoId id, string title)
    {
        this.Id = id;
        this.SetTile(title);
    }

    public void RemoveToDoItem(ToDoItemId itemId)
    {
        if (!this.items.ContainsKey(itemId))
        {
            throw new ToDoItemNotFoundException(itemId);
        }

        this.items.Remove(itemId);
    }

    public void SetTile(string title)
    {
        var trimmedTitle = title.Trim();

        if (string.IsNullOrWhiteSpace(trimmedTitle))
        {
            throw new InvalidTitleException(title);
        }

        this.Title = title;
    }

    public void UpsertToDoItem(ToDoItemEntity entity)
    {
        this.items[entity.Id] = entity;
    }
}

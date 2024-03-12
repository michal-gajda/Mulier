namespace Mulier.Domain.Entities;

using Mulier.Domain.Exceptions;

public sealed class ToDoEntity
{
    private readonly Dictionary<ToDoItemId, ToDoItemEntity> items = new();

    public ToDoEntity(ToDoId id, string title)
    {
        this.Id = id;
        this.SetTile(title);
    }

    public ToDoId Id { get; private init; }
    public string Title { get; private set; } = string.Empty;

    public void UpsertToDoItem(ToDoItemEntity entity)
    {
        this.items[entity.Id] = entity;
    }

    public void RemoveToDoItem(ToDoItemId itemId)
    {
        if (this.items.ContainsKey(itemId) is false)
        {
            throw new ToDoItemNotFoundException(itemId);
        }

        this.items.Remove(itemId);
    }

    public void SetTile(string title)
    {
        this.Title = title;
    }
}

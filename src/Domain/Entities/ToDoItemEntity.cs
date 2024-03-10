namespace Mulier.Domain.Entities;

public sealed class ToDoItemEntity
{
    public ToDoItemEntity(ToDoItemId id, string title, string description, DateTime? expirationDateTime = default)
    {
        this.Id = id;
        this.SetTitle(title);
        this.SetDescription(description);
        this.SetExpirationDateTime(expirationDateTime);
    }

    public ToDoItemId Id { get; private set; }
    public ToDoItemStatus Status { get; private set; } = ToDoItemStatus.Created;
    public string Description { get; private set; } = string.Empty;
    public DateTime? ExpirationDateTime { get; private set; } = default;
    public string Title { get; private set; } = string.Empty;

    public void SetDescription(string description)
    {
        this.Description = description;
    }

    public void SetExpirationDateTime(DateTime? expirationDateTime)
    {
        this.ExpirationDateTime = expirationDateTime;
    }

    public void SetTitle(string title)
    {
        this.Title = title;
    }

    public void Complete()
    {
        this.Status = ToDoItemStatus.Completed;
    }

    public void Resume()
    {
        this.Status = ToDoItemStatus.Created;
    }

    public void Suspend()
    {
        this.Status = ToDoItemStatus.Suspended;
    }
}

namespace Mulier.Domain.Entities;

using Mulier.Domain.Exceptions;

public sealed class ShoppingListEntity
{
    private readonly Dictionary<ShoppingListItemId, ShoppingListItemEntity> items = new();
    public ShoppingListId Id { get; private init; }

    public IReadOnlyCollection<ShoppingListItemEntity> Items => this.items.Values.ToList().AsReadOnly();
    public string Title { get; private set; } = string.Empty;

    public ShoppingListEntity(ShoppingListId id, string title)
    {
        this.Id = id;
        this.SetTitle(title);
    }

    public void SetTitle(string title)
    {
        var trimmedName = title.Trim();

        if (string.IsNullOrWhiteSpace(trimmedName))
        {
            throw new InvalidTitleException(title);
        }

        this.Title = title;
    }

    public void UpsertItem(ShoppingListItemEntity item)
        => this.items[item.Id] = item;
}

namespace Mulier.Domain.Entities;

using Mulier.Domain.Exceptions;

public sealed class ShoppingListItemEntity
{
    public ShoppingListItemId Id { get; private init; }
    public string Title { get; private set; } = string.Empty;

    public ShoppingListItemEntity(ShoppingListItemId id, string title)
    {
        this.Id = id;
        this.SetTitle(title);
    }

    public void SetTitle(string title)
    {
        var trimmedTitle = title.Trim();

        if (string.IsNullOrWhiteSpace(trimmedTitle))
        {
            throw new InvalidTitleException(title);
        }

        this.Title = title;
    }
}

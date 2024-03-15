using Mulier.Domain.Exceptions;

namespace Mulier.Domain.Entities;

public sealed class ShoppingListEntity
{
    public ShoppingListId Id { get; private init; }
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
}
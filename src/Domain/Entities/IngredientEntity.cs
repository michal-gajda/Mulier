namespace Mulier.Domain.Entities;

using Mulier.Domain.Exceptions;

public sealed class IngredientEntity
{
    public IngredientId Id { get; private init; }
    public string Title { get; private set; } = string.Empty;

    public IngredientEntity(IngredientId id, string title)
    {
        this.Id = id;
        this.SetTitle(title);
    }

    public void SetTitle(string name)
    {
        var trimmedName = name.Trim();

        if (string.IsNullOrWhiteSpace(trimmedName))
        {
            throw new InvalidTitleException(name);
        }

        this.Title = trimmedName;
    }
}

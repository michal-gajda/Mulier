namespace Mulier.Domain.Entities;

using Mulier.Domain.Exceptions;

public sealed class Ingredient
{
    public IngredientId Id { get; private init; }
    public string Name { get; private set; } = string.Empty;

    public Ingredient(IngredientId id, string name)
    {
        this.Id = id;
        this.SetName(name);
    }

    public void SetName(string name)
    {
        var trimmedName = name.Trim();

        if (string.IsNullOrWhiteSpace(trimmedName))
        {
            throw new InvalidNameException();
        }

        this.Name = trimmedName;
    }
}

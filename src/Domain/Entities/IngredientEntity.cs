namespace Mulier.Domain.Entities;

using Mulier.Domain.Exceptions;

public sealed class IngredientEntity
{
    public IngredientId Id { get; private init; }
    public string Name { get; private set; } = string.Empty;

    public IngredientEntity(IngredientId id, string name)
    {
        this.Id = id;
        this.SetName(name);
    }

    public void SetName(string name)
    {
        var trimmedName = name.Trim();

        if (string.IsNullOrWhiteSpace(trimmedName))
        {
            throw new InvalidNameException(name);
        }

        this.Name = trimmedName;
    }
}

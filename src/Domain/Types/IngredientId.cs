namespace Mulier.Domain.Types;

public readonly record struct IngredientId
{
    public Guid Value { get; private init; }

    public IngredientId(Guid value) => this.Value = value;
}

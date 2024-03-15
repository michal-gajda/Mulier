namespace Mulier.Domain.Types;

public readonly record struct ShoppingListItemId
{
    public Guid Value { get; private init; }

    public ShoppingListItemId(Guid value) => this.Value = value;
}

namespace Mulier.Domain.Types;

public readonly record struct ShoppingListId
{
    public Guid Value { get; private init; }

    public ShoppingListId(Guid value) => this.Value = value;
}

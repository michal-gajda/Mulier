namespace Mulier.Domain.Events;

public sealed record class ShoppingListItemSelected : IDomainEvent
{
    public required ShoppingListItemId Id { get; init; }
}

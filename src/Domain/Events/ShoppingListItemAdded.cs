namespace Mulier.Domain.Events;

public sealed record class ShoppingListItemAdded : IDomainEvent
{
    public required ShoppingListItemId Id { get; init; }
}

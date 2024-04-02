namespace Mulier.Domain.Events;

public sealed record class ShoppingListItemMarked : IDomainEvent
{
    public required ShoppingListItemId Id { get; init; }
}

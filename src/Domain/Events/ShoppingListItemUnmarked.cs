namespace Mulier.Domain.Events;

public sealed record class ShoppingListItemUnmarked : IDomainEvent
{
    public required ShoppingListItemId Id { get; init; }
}

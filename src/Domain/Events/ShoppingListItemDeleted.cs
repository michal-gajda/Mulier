namespace Mulier.Domain.Events;

public sealed record class ShoppingListItemDeleted : IDomainEvent
{
    public required ShoppingListItemId Id { get; init; }
}

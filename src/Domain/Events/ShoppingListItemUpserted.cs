namespace Mulier.Domain.Events;

public sealed record class ShoppingListItemUpserted : IDomainEvent
{
    public required ShoppingListItemId Id { get; init; }
}

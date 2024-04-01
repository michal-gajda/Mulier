namespace Mulier.Domain.Events;

public sealed record class ShoppingListItemSelected : INotification
{
    public required ShoppingListItemId Id { get; init; }
}

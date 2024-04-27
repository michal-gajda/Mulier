namespace Mulier.Application.Ingredients.Events;

public sealed record class IngredientAdded : INotification
{
    public required IngredientId Id { get; init; }

}

namespace Mulier.Application.ShoppingLists.Commands;

public sealed record class CreateShoppingList : IRequest
{
    [JsonPropertyName("id")] public required Guid Id { get; init; }
    [JsonPropertyName("name")] public required string Name { get; init; }
}

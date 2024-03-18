namespace Mulier.Application.ShoppingLists.ViewModels;

public sealed record class ShoppingList
{
    [JsonPropertyName("id")] public required Guid Id { get; init; }
    [JsonPropertyName("title")] public required string Title { get; init; }
}

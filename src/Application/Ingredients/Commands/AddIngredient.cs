namespace Mulier.Application.Ingredients.Commands;

public sealed record class AddIngredient : IRequest
{
    [JsonPropertyName("id")] public required Guid Id { get; init; }
    [JsonPropertyName("name")] public required string Name { get; init; }
}

namespace Mulier.Application.ToDos.Commands;

public sealed record class AddToDoItem : IRequest
{
    [JsonPropertyName("id")] public required Guid Id { get; init; }
    [JsonPropertyName("title")] public required string Title { get; init; }
    [JsonPropertyName("description")] public string Description { get; init; } = string.Empty;
    [JsonPropertyName("expirationDateTime")] public DateTime? ExpirationDateTime { get; init; } = default;
}

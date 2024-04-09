namespace Mulier.Application.ToDos.Commands;

public sealed record AddToDoItem : IRequest
{
    [JsonPropertyName("description")] public string Description { get; init; } = string.Empty;
    [JsonPropertyName("expirationDateTime")] public DateTime? ExpirationDateTime { get; init; } = default;
    [JsonPropertyName("id")] public required Guid Id { get; init; }
    [JsonPropertyName("title")] public required string Title { get; init; }
}

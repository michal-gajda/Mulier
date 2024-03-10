namespace Mulier.Application.ToDos.Commands;

public sealed record class CreateToDo : IRequest
{
    [JsonPropertyName("id")] public required Guid Id { get; init; }
    [JsonPropertyName("title")] public required string Title { get; init; }
}

namespace Mulier.Application.ToDos.Commands;

public sealed record class RemoveToDoItem : IRequest
{
    [JsonPropertyName("id")] public required Guid Id { get; init; }
    [JsonPropertyName("item_id")] public required Guid ItemId { get; init; }
}

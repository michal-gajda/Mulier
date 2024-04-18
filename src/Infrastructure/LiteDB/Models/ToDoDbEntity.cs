namespace Mulier.Infrastructure.LiteDb.Models;

internal sealed class ToDoDbEntity
{
    public ToDoId Id { get; set; } = default;
    public string Title { get; set; } = string.Empty;
}

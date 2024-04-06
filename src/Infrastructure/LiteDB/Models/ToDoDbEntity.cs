namespace Mulier.Infrastructure.LiteDb.Models;

internal sealed class ToDoDbEntity
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Title { get; set; } = string.Empty;
}

namespace Mulier.Infrastructure.LiteDB.Models;

internal sealed class ToDoDbEntity
{
    public IngredientId Id { get; set; } = default;
    public string Title { get; set; } = string.Empty;
}

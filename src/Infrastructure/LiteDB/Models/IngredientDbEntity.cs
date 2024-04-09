namespace Mulier.Infrastructure.LiteDb.Models;

internal sealed class IngredientDbEntity
{
    public IngredientId Id { get; set; } = default;
    public string Title { get; set; } = string.Empty;
}

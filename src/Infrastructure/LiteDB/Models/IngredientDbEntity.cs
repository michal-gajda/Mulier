namespace Mulier.Infrastructure.LiteDb.Models;

using Mulier.Domain.Types;

internal sealed class IngredientDbEntity
{
    public IngredientId Id { get; set; } = default;
    public string Title { get; set; } = string.Empty;
}

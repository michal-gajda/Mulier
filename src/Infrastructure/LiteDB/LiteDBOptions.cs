namespace Mulier.Infrastructure.LiteDb;

public sealed record class LiteDbOptions
{
    public static readonly string SectionName = "LiteDB";
    public string FileName { get; init; } = string.Empty;
}


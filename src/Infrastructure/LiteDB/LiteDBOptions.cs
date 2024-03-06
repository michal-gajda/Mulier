namespace Mulier.Infrastructure.LiteDB;

public sealed record class LiteDBOptions
{
    public static readonly string SectionName = "LiteDB";
    public string FileName { get; init; } = string.Empty;
}


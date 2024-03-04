namespace Mulier.Infrastructure.LiteDB;

public sealed record class LiteDBOptions
{
    public readonly static string SECTION = "LiteDB";
    public string FileName { get; init; } = string.Empty;
}


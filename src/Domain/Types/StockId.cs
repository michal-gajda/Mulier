namespace Mulier.Domain.Types;

public readonly record struct StockId
{
    public Guid Value { get; private init; }

    public StockId(Guid value) => this.Value = value;
}

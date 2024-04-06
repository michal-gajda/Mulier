namespace Mulier.Domain.Types;

public readonly record struct ElementId
{
    public Guid Value { get; private init; }

    public ElementId(Guid value) => this.Value = value;
}

namespace Mulier.Domain.Types;

public readonly record struct HouseholdMemberId
{
    public Guid Value { get; private init; }

    public HouseholdMemberId(Guid value) => this.Value = value;
}

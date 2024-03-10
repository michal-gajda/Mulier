namespace Mulier.Domain.Types;

public readonly record struct ToDoId
{
    public Guid Value { get; private init; }

    public ToDoId(Guid value) => this.Value = value;
}

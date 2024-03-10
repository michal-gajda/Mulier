namespace Mulier.Domain.Types;

public readonly record struct ToDoItemId
{
    public Guid Value { get; private init; }

    public ToDoItemId(Guid value) => this.Value = value;
}

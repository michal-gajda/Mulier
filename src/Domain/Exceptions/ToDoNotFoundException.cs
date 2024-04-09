namespace Mulier.Domain.Exceptions;

public sealed class ToDoNotFoundException : DomainException
{
    public override string Code => DomainErrorCode.NOT_FOUND;

    public ToDoNotFoundException(ToDoId id) : base($"ToDo '{id.Value}' not found")
    {
    }
}

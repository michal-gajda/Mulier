namespace Mulier.Domain.Exceptions;

public abstract class DomainException : Exception
{
    public abstract string Code { get; }
    public Guid Id { get; protected set; } = Guid.Empty;

    protected DomainException(string message, Exception? innerException = default)
    {
    }
}

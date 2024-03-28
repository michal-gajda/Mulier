namespace Mulier.Domain.Exceptions;

public abstract class DomainException : Exception
{
    protected DomainException(string message, Exception? innerException = default)
        : base(message, innerException)
    {
    }

    public abstract string Code { get; }
    public Guid Id { get; protected set; } = Guid.Empty;
}

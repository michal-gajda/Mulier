namespace Mulier.Application.Common.Exceptions;

public abstract class ApplicationException : Exception
{
    public abstract string Code { get; }
    public Guid Id { get; protected init; } = Guid.Empty;

    protected ApplicationException(string message, Exception? innerException = default)
        : base(message, innerException)
    {
    }
}

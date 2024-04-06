namespace Mulier.Application.Common.Exceptions;

public sealed class ValidationException : ApplicationException
{
    public override string Code => ErrorCode.VALIDATION_FAILURE;

    public ValidationException(string message, Exception? innerException = default)
        : base(message, innerException)
    {
    }
}

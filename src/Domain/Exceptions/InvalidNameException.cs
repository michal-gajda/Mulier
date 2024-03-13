namespace Mulier.Domain.Exceptions;

public sealed class InvalidNameException : Exception
{
    public InvalidNameException(string name) : base($"Name '{name}' is not valid")
    {
    }
}

namespace Sa.Core.ErrorHandling.Exceptions;

public class ConflitException : ApiException
{
    public ConflitException() : base(NotFound)
    {
    }

    public ConflitException(string message) : base(NotFound, message)
    {
    }
}
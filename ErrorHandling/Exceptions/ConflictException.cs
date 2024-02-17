namespace Sa.Core.ErrorHandling.Exceptions;

public class ConflictException : ApiException
{
    public ConflictException() : base(Conflict)
    {
    }

    public ConflictException(string message) : base(Conflict, message)
    {
    }
}
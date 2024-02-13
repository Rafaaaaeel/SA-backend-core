namespace Sa.Core.ErrorHandling.Exceptions;

public class NotFoundException : ApiException
{
    public NotFoundException() : base(NotFound)
    {
    }

    public NotFoundException(string message) : base(NotFound, message)
    {
    }
}
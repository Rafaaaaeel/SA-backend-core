namespace Sa.Core.ErrorHandling.Exceptions;

public class UnathorizedException : ApiException
{
    public UnathorizedException() : base(Unauthorized)
    {
    }

    public UnathorizedException(string message) : base(Unauthorized, message)
    {
    }
}
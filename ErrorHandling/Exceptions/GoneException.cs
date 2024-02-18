namespace Sa.Core.ErrorHandling.Exceptions;

public class GoneException : ApiException
{
    public GoneException() : base(Gone)
    {
    }

    public GoneException(string message) : base(Gone, message)
    {
    }
}
namespace Sa.Core.ErrorHandling.Exceptions;

public class BadRequestException : ApiException
{
    public BadRequestException() : base(BadRequest)
    {
    }

    public BadRequestException(string message) : base(BadRequest, message)
    {
    }
}
namespace Sa.Core.ErrorHandling.Exceptions;

public abstract class ApiException : Exception
{
    public IEnumerable<string>? LogMessages { get; set; }

    public int StatusCode { get; private set;}

    protected ApiException(int status, string message = ApiErrorMessages.GenericError, IEnumerable<string>? logMessages = null) : base(message)
    {
        StatusCode = status;
        LogMessages = logMessages;
    }

    protected ApiException(HttpStatusCode status, string message = ApiErrorMessages.GenericError, IEnumerable<string>? logMessages = null) : this((int) status, message, logMessages)
    {
    }

}
namespace Sa.Core.Middlewares;

public static class MiddlewareLoggerExtension
{
    public static MiddlewareLogger ExceptionLogger(this ErrorHandling.Exceptions.ApiException exception, HttpContext context) => new(context)
    {
        StatusCode = exception.StatusCode,
        Message = exception.Message
    };
}
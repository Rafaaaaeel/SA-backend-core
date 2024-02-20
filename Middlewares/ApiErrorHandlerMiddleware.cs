namespace Sa.Core.Middlewares;

public class ApiErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    public ApiErrorHandlerMiddleware(AppSettings appSettings, RequestDelegate next)
    {
        _appSettings = appSettings;
        _next = next;
    }

    public async Task Invoke(HttpContext context) 
    {
        bool requestFailed = true; 
        MiddlewareLogger logger = new();
        try 
        {
            await _next(context);

            requestFailed = false;
        }
        catch(ErrorHandling.Exceptions.ApiException exception) 
        {
            logger = exception.ExceptionLogger(context);
        }
        finally
        {
            if(requestFailed)
            {
                await ExceptionManager(context, logger);
            }
            
        }
    }

    private async Task ExceptionManager(HttpContext context, MiddlewareLogger logger)
    {
        int statusCode = logger.StatusCode ?? 500;
        context.Response.StatusCode = statusCode;
        logger.Message = ApiErrorMessages.Message(statusCode);

        await context.Response.WriteAsync(SerializedErrorResponse(logger.Message, statusCode));
    }

    private string SerializedErrorResponse(string message, int statusCode) => System.Text.Json.JsonSerializer.Serialize<ApiErrorResponse>(new() { Message = message, StatusCode = statusCode});
}
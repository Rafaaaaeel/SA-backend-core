namespace Sa.Core.Middlewares;

public class MiddlewareLogger
{
    public MiddlewareLogger()
    {
    }

    public MiddlewareLogger(HttpContext httpContext)
    {
        SetContextInfo(httpContext);
    }

    [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]    
    public string? Source { get; set; }

    public string? Method { get; set; }

    public int? StatusCode { get; set; }

    public string? Message { get; set; }

    private void SetContextInfo(HttpContext context)
    {
        Source = context.Request?.Path;
        Method = context.Request?.Method;
    }

}
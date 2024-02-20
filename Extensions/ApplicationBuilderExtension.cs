namespace Sa.Core.Extensions;

public static class ApplicationnBuilderExtension
{
    public static IApplicationBuilder UseApiErrorHandlerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ApiErrorHandlerMiddleware>();
    }
}
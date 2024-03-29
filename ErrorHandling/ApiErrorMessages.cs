namespace Sa.Core.ErrorHandling;

public static class ApiErrorMessages 
{
    public const string GenericError = "There was an error processing the request.";
    public const string BadRequestError = "There was something wrong in the request.";
    public const string NotFoundError = "Entity not found or non exist.";
    public const string NotAuthorized = "Does not have permission to proceed.";

    public static string Message(int statusCode) => (statusCode) switch
    {
        StatusCodes.Status400BadRequest => ApiErrorMessages.BadRequestError,
        StatusCodes.Status404NotFound => ApiErrorMessages.NotFoundError,
        StatusCodes.Status401Unauthorized => ApiErrorMessages.NotAuthorized,
        _ => ApiErrorMessages.GenericError
    };
}
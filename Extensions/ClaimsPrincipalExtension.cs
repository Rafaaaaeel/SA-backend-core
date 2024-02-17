namespace Sa.Core.Extensions;

public static class ClaimsPrincipalExtension
{
    public static string GetEmail(this ClaimsPrincipal claims)
    {
        string? token = claims.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

        if (token is null) throw new NullReferenceException("Jwt token not found");

        return token;
    }
}
namespace Sa.Core.Configurations;

public class JwtConfiguration
{
    public bool ValidateIssuerSigningKey { get; set; }
    public string IssuerSigningKey { get; set; } = string.Empty;
    public bool ValidateIssuer { get; set; }
    public bool ValidateAudience { get; set; }
}
namespace Bloggy.Infrastructure.Services.Authorization;

public class JwtSettings
{
    public const string SectionName = "JwtSettings";
    public string AccessSecret { get; set; }
    public string RefreshSecret { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int AccessExpiryMinutes { get; set; }
    public int RefreshExpiryMinutes { get; set; }
}
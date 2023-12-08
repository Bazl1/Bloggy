namespace Bloggy.Infrastructure.Services.Authorization;

public class JwtSettings
{
    public const string SectionName = "JwtSettings";
    public string Secret { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int ExpiryMinutes { get; set; }
}
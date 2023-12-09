using System.Security.Cryptography;
using Bloggy.Application.Services.Authorization;

namespace Bloggy.Infrastructure.Services.Authorization;

public class RefreshTokenGenerator : IRefreshTokenGenerator
{
    public string GenerateRefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(128));
    }
}
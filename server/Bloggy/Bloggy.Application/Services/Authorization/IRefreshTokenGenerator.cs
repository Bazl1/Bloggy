namespace Bloggy.Application.Services.Authorization;

public interface IRefreshTokenGenerator
{
    string GenerateRefreshToken();
}
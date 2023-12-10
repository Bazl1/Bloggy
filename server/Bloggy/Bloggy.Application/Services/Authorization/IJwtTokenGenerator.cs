using Bloggy.Domain.Entites;

namespace Bloggy.Application.Services.Authorization;

public interface IJwtTokenGenerator
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken(User user);
}
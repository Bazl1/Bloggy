using Bloggy.Domain.Entites;

namespace Bloggy.Application.Services.Authorization;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
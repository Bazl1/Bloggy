using System.Security.Claims;
using Bloggy.Application.Persistense;
using Bloggy.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Bloggy.Application.Commands.Authorization.Logout;

public class LogoutHandler(
    IRefreshTokenRepository _refreshTokenRepository,
    IHttpContextAccessor _httpContextAccessor
) : IRequestHandler<LogoutRequest, LogoutResponse>
{
    public Task<LogoutResponse> Handle(LogoutRequest request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid userId))
        {
            throw new ApplicationException("Unauthorized");
        }

        if (_refreshTokenRepository.GetByUserId(userId) is not RefreshToken refreshToken)
        {
            throw new ApplicationException("Unauthorized");
        }
        
        _refreshTokenRepository.Remove(refreshToken);
        _httpContextAccessor.HttpContext.Response.Cookies.Delete("refreshToken");

        return Task.FromResult(
            new LogoutResponse()
        );
    }
}

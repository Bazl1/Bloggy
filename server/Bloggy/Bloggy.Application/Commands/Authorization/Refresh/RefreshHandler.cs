using Bloggy.Application.Common;
using Bloggy.Application.Common.Dots;
using Bloggy.Application.Persistense;
using Bloggy.Application.Services.Authorization;
using Bloggy.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Bloggy.Application.Commands.Authorization.Refresh;

public class RefreshHandler(
    IRefreshTokenRepository _refreshTokenRepository,
    IUserRepository _userRepository,
    IJwtTokenGenerator _jwtTokenGenerator,
    IRefreshTokenGenerator _refreshTokenGenerator,
    IHttpContextAccessor _httpContextAccessor
) : IRequestHandler<RefreshRequest, RefreshResponse>
{
    public Task<RefreshResponse> Handle(RefreshRequest request, CancellationToken cancellationToken)
    {
        if (_refreshTokenRepository.GetByValue(_httpContextAccessor.HttpContext.Request.Cookies["refreshToken"]) is not RefreshToken refreshToken)
        {
            throw new ApplicatioException("Refresh token not found");
        }
        
        if (refreshToken.Expiry < DateTime.UtcNow)
        {
            throw new ApplicationException("Token expired");
        }

        if (_userRepository.GetById(refreshToken.UserId) is not User user)
        {
            throw new ApplicatioException("User not found");
        }

        refreshToken.Value = _refreshTokenGenerator.GenerateRefreshToken();
        refreshToken.Created = DateTime.UtcNow;
        refreshToken.Expiry = DateTime.UtcNow.AddMinutes(2);
        _refreshTokenRepository.Update(refreshToken);

        // Set refresh token to cookie
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = refreshToken.Expiry
        };
        _httpContextAccessor.HttpContext.Response.Cookies.Append("refreshToken", refreshToken.Value, cookieOptions);
        
        var accessToken = _jwtTokenGenerator.GenerateToken(user);

        return Task.FromResult(
            new RefreshResponse(
                AccessToken: accessToken,
                RefreshToken: refreshToken.Value,
                User: new UserDto
                {
                    Id = user.Id.ToString(),
                    ImageUri = user.ImageUri,
                    Name = user.Name,
                    Email = user.Email
                }
            )
        );
    }
}

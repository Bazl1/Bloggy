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
    IHttpContextAccessor _httpContextAccessor
) : IRequestHandler<RefreshRequest, RefreshResponse>
{
    public Task<RefreshResponse> Handle(RefreshRequest request, CancellationToken cancellationToken)
    {
        if (_refreshTokenRepository.GetByValue(_httpContextAccessor.HttpContext.Request.Cookies["refreshToken"]) is not RefreshToken refreshToken)
        {
            throw new ApplicatioException("Refresh token not found");
        }

        if (_userRepository.GetById(refreshToken.UserId) is not User user)
        {
            throw new ApplicatioException("User not found");
        }

        var accessToken = _jwtTokenGenerator.GenerateToken(user);
        
        refreshToken.Value = _jwtTokenGenerator.GenerateToken(user);
        refreshToken.ExpiryDate = DateTime.UtcNow.AddDays(1);
        _refreshTokenRepository.Update(refreshToken);

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

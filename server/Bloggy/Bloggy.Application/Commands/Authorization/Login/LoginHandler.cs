using Bloggy.Application.Common;
using Bloggy.Application.Common.Dots;
using Bloggy.Application.Persistense;
using Bloggy.Application.Services.Authorization;
using Bloggy.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Bloggy.Application.Commands.Authorization.Login;

public class LoginHandler(
    IUserRepository _userRepository,
    IRefreshTokenRepository _refreshTokenRepository,
    IPasswordHasher _passwordHasher,
    IJwtTokenGenerator _jwtTokenGenerator,
    IHttpContextAccessor _httpContextAccessor
) : IRequestHandler<LoginRequest, LoginResponse>
{
    public Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        if (_userRepository.GetByEmail(request.Email) is not User user)
        {
            throw new ApplicatioException("User wiht given email not found");
        }

        if (!_passwordHasher.Verify(request.Password, user.Password))
        {
            throw new ApplicatioException("Password mismatch");
        }

        var accessToken = _jwtTokenGenerator.GenerateToken(user);
        var refreshToken = _jwtTokenGenerator.GenerateToken(user);

        var userRefreshToken = _refreshTokenRepository.GetByUserId(user.Id);
        userRefreshToken.Value = refreshToken;
        userRefreshToken.ExpiryDate = DateTime.UtcNow.AddDays(1);
        _refreshTokenRepository.Update(userRefreshToken);

        _httpContextAccessor.HttpContext.Response.Cookies.Append("refreshToken", userRefreshToken.Value);

        return Task.FromResult(
            new LoginResponse(
                AccessToken: accessToken,
                RefreshToken: refreshToken,
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

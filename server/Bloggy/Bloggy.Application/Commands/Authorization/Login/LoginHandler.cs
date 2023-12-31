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

        var refreshToken = _refreshTokenRepository.GetByUserId(user.Id);
        if (refreshToken == null)
        {
            refreshToken = new RefreshToken
            {
                UserId = user.Id,
                Created = DateTime.UtcNow,
                Expiry = DateTime.UtcNow.AddMinutes(60),
                Value = _jwtTokenGenerator.GenerateRefreshToken(user),
            };
            _refreshTokenRepository.Add(refreshToken);
        }
        else
        {
            refreshToken.Value = _jwtTokenGenerator.GenerateRefreshToken(user);
            refreshToken.Created = DateTime.UtcNow;
            refreshToken.Expiry = DateTime.UtcNow.AddMinutes(60);
            _refreshTokenRepository.Update(refreshToken);
        }


        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = refreshToken.Expiry,
        };
        _httpContextAccessor.HttpContext.Response.Cookies.Append("refreshToken", refreshToken.Value, cookieOptions);

        var accessToken = _jwtTokenGenerator.GenerateAccessToken(user);

        return Task.FromResult(
            new LoginResponse(
                AccessToken: accessToken,
                RefreshToken: refreshToken.Value,
                User: new UserDto
                {
                    Id = user.Id.ToString(),
                    ImageUri = user.ImageUri,
                    Name = user.Name,
                    Email = user.Email,
                    Password = user.Password
                }
            )
        );
    }
}

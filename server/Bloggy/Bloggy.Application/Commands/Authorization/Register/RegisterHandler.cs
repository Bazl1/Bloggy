using Bloggy.Application.Common.Dots;
using Bloggy.Application.Persistense;
using Bloggy.Application.Services.Authorization;
using Bloggy.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Bloggy.Application.Commands.Authorization.Register;

public class RegisterHandler(
    IUserRepository _userRepository,
    IRefreshTokenRepository _refreshTokenRepository,
    IJwtTokenGenerator _jwtTokenGenerator,
    IRefreshTokenGenerator _refreshTokenGenerator,
    IPasswordHasher _passwordHasher,
    IHttpContextAccessor _httpContextAccessor
) : IRequestHandler<RegisterRequest, RegisterResponse>
{
    public Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        if (_userRepository.GetByName(request.Username) is not null)
        {
            throw new ApplicationException("User with given username already exists");
        }

        if (_userRepository.GetByEmail(request.Email) is not null)
        {
            throw new ApplicationException("User with given email already exists");
        }

        // Create user
        var user = new User
        {
            Name = request.Username,
            Email = request.Email,
            Password = _passwordHasher.Hash(request.Password)
        };
        _userRepository.Add(user);

        // Create refresh token
        var refreshToken = new RefreshToken
        {
            UserId = user.Id,
            Value = _refreshTokenGenerator.GenerateRefreshToken(),
            Created = DateTime.UtcNow,
            Expiry = DateTime.UtcNow.AddMinutes(2)
        };
        _refreshTokenRepository.Add(refreshToken);

        // Set refresh token to cookie
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = refreshToken.Expiry
        };
        _httpContextAccessor.HttpContext.Response.Cookies.Append("refreshToken", refreshToken.Value, cookieOptions);

        // Create access token
        var accessToken = _jwtTokenGenerator.GenerateToken(user);

        return Task.FromResult(
            new RegisterResponse(
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

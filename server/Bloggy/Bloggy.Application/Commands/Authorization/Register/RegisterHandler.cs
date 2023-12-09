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

        var user = new User
        {
            Name = request.Username,
            Email = request.Email,
            Password = _passwordHasher.Hash(request.Password)
        };
        _userRepository.Add(user);

        var accessToken = _jwtTokenGenerator.GenerateToken(user);
        var refreshToken = _jwtTokenGenerator.GenerateToken(user);
        
        var userRefreshToken = new RefreshToken
        {
            UserId = user.Id,
            Value = refreshToken,
            ExpiryDate = DateTime.UtcNow.AddDays(1)
        };
        _refreshTokenRepository.Add(userRefreshToken);

        _httpContextAccessor.HttpContext.Response.Cookies.Append("refreshToken", userRefreshToken.Value);

        return Task.FromResult(
            new RegisterResponse(
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

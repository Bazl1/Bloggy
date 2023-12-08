using Bloggy.Application.Common.Dots;

namespace Bloggy.Application.Commands.Authorization.Login;

public record LoginResponse(
    string AccessToken,
    string RefreshToken,
    UserDto User
);
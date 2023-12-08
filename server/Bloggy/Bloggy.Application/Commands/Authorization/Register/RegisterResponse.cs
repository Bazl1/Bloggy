using Bloggy.Application.Common.Dots;

namespace Bloggy.Application.Commands.Authorization.Register;

public record RegisterResponse(
    string AccessToken,
    string RefreshToken,
    UserDto User
);
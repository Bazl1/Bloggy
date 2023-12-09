using Bloggy.Application.Common.Dots;

namespace Bloggy.Application.Commands.Authorization.Refresh;

public record RefreshResponse(
    string AccessToken,
    string RefreshToken,
    UserDto User
);
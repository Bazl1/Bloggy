using Bloggy.Application.Common.Dots;

namespace Bloggy.Application.Commands.Accounts.ChangePassword;

public record ChangePasswordResponse(
    UserDto User
);
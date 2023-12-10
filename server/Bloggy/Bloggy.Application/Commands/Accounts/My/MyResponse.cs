using Bloggy.Application.Common.Dots;

namespace Bloggy.Application.Commands.Accounts.My;

public record MyResponse(
    UserDto User
);
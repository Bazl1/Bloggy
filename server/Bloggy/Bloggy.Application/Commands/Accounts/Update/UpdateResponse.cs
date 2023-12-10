using Bloggy.Application.Common.Dots;

namespace Bloggy.Application.Commands.Accounts.Update;

public record UpdateResponse(
    UserDto User
);
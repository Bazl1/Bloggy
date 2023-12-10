using Bloggy.Application.Common.Dots;

namespace Bloggy.Application.Commands.Accounts.GetById;

public record GetByIdResponse(
    UserDto User
);
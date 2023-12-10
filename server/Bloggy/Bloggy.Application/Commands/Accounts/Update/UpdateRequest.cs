using MediatR;

namespace Bloggy.Application.Commands.Accounts.Update;

public record UpdateRequest(
    Guid Id,
    string Username
) : IRequest<UpdateResponse>;
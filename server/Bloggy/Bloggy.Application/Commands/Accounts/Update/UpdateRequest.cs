using MediatR;

namespace Bloggy.Application.Commands.Accounts.Update;

public record UpdateRequest(
    string Username
) : IRequest<UpdateResponse>;
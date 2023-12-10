using MediatR;

namespace Bloggy.Application.Commands.Accounts.Update;

public record UpdateRequest(
    string Name
) : IRequest<UpdateResponse>;
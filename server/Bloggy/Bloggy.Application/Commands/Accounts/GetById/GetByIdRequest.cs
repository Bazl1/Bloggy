using MediatR;

namespace Bloggy.Application.Commands.Accounts.GetById;

public record GetByIdRequest(
    Guid Id
) : IRequest<GetByIdResponse>;
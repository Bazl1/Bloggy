using MediatR;

namespace Bloggy.Application.Commands.Posts.GetById;

public record GetByIdRequest(
    Guid Id
) : IRequest<GetByIdResponse>;
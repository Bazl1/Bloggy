using MediatR;

namespace Bloggy.Application.Commands.PostsImage.Delete;

public record DeleteRequest(
    Guid Id
) : IRequest<DeleteResponse>;
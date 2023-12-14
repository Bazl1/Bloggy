using MediatR;

namespace Bloggy.Application.Commands.Posts.Create;

public record CreateRequest(
    string Title,
    string Description,
    IEnumerable<int> Topics
) : IRequest<CreateResponse>;
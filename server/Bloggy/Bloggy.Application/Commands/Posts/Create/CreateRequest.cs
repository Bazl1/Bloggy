using MediatR;

namespace Bloggy.Application.Commands.Posts.Create;

public record CreateRequest(
    string Document,
    IEnumerable<int> Topics
) : IRequest<CreateResponse>;
using Bloggy.Application.Common.Dots;

namespace Bloggy.Application.Commands.Posts.Create;

public record CreateResponse(
    string Id,
    AuthorPostDto Author,
    string Document,
    IEnumerable<int> Topics
);
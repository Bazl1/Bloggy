using Bloggy.Application.Common.Dots;

namespace Bloggy.Application.Commands.Posts.Create;

public record CreateResponse(
    PostDto Post
);
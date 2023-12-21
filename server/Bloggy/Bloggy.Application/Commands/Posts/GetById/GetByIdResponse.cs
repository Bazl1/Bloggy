using Bloggy.Application.Common.Dots;

namespace Bloggy.Application.Commands.Posts.GetById;

public record GetByIdResponse(
    PostDto Post
);
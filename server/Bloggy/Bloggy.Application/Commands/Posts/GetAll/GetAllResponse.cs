using Bloggy.Application.Common.Dots;

namespace Bloggy.Application.Commands.Posts.GetAll;

public record GetAllResponse(
    IEnumerable<PostDto> Posts
);
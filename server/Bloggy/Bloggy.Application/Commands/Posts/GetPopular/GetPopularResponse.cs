using Bloggy.Application.Common.Dots;

namespace Bloggy.Application.Commands.Posts.GetPopular;

public record GetPopularResponse(
    IEnumerable<PostDto> Posts
);
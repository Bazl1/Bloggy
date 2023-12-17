using Bloggy.Application.Common.Dots;

namespace Bloggy.Application.Commands.Posts.GetByTopic;

public record GetByTopicResponse(
    IEnumerable<PostDto> Posts
);
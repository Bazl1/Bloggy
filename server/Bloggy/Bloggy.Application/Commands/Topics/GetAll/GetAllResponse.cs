using Bloggy.Application.Common.Dots;

namespace Bloggy.Application.Commands.Topics.GetAll;

public record GetAllResponse(
    IEnumerable<TopicDto> Topics
);
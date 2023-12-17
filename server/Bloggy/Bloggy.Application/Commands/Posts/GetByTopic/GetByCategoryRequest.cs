using MediatR;

namespace Bloggy.Application.Commands.Posts.GetByTopic;

public record GetByTopicRequest(
    int CategoryId
) : IRequest<GetByTopicResponse>;
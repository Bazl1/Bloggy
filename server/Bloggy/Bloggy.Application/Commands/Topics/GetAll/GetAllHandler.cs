using Bloggy.Application.Common.Dots;
using Bloggy.Application.Persistense;
using MediatR;

namespace Bloggy.Application.Commands.Topics.GetAll;

public class GetAllHandler(
    ITopicRepository _topicRepository
) : IRequestHandler<GetAllRequest, GetAllResponse>
{
    public Task<GetAllResponse> Handle(GetAllRequest request, CancellationToken cancellationToken)
    {
        var topics = _topicRepository.GetAll()
            .Select(topic => new TopicDto
            {
                Id = topic.Id,
                Name = topic.Name
            });

        return Task.FromResult(new GetAllResponse(topics));
    }
}

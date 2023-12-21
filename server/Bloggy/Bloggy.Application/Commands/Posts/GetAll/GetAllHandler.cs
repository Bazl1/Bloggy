using Bloggy.Application.Common.Dots;
using Bloggy.Application.Persistense;
using MediatR;

namespace Bloggy.Application.Commands.Posts.GetAll;

public class GetAllHandler(
    IPostRepository _postRepository
) : IRequestHandler<GetAllRequest, GetAllResponse>
{
    public Task<GetAllResponse> Handle(GetAllRequest request, CancellationToken cancellationToken)
    {
        var posts = _postRepository.GetAll()
            .Select(p => new PostDto
            {
                Id = p.Id.ToString(),
                Author = new UserWithoutPasswordDto
                {
                    Id = p.Author.Id.ToString(),
                    ImageUri = p.Author.ImageUri,
                    Name = p.Author.Name,
                    Email = p.Author.Email,
                },
                ImageUri = p.ImageUri,
                Title = p.Title,
                Description = p.Description,
                DateCreated = p.DateCreated.ToString("dd/MM/yyyy HH:mm"),
                Topics = p.Topics.Select(t => new TopicDto
                {
                    Id = t.Id,
                    Name = t.Name
                })
            });

        return Task.FromResult(new GetAllResponse(posts));
    }
}

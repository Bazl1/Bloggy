using Bloggy.Application.Common.Dots;
using Bloggy.Application.Persistense;
using MediatR;

namespace Bloggy.Application.Commands.Posts.GetPopular;

public class GetPopularHandler(
    IPostRepository _postRepository
) : IRequestHandler<GetPopularRequest, GetPopularResponse>
{
    public Task<GetPopularResponse> Handle(GetPopularRequest request, CancellationToken cancellationToken)
    {
        var posts = _postRepository.GetPopular(request.Page, request.Limit)
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
                Views = p.Views,
                Topics = p.Topics.Select(t => new TopicDto
                {
                    Id = t.Id,
                    Name = t.Name
                })
            });

        return Task.FromResult(new GetPopularResponse(posts));
    }
}

using Bloggy.Application.Commands.Posts.GetById;
using Bloggy.Application.Common.Dots;
using Bloggy.Application.Persistense;
using Bloggy.Domain.Entites;
using MediatR;

namespace Bloggy.Application.Commands.Posts;

public class GetByIdHandler(
    IPostRepository _postRepository
) : IRequestHandler<GetByIdRequest, GetByIdResponse>
{
    public Task<GetByIdResponse> Handle(GetByIdRequest request, CancellationToken cancellationToken)
    {
        if (_postRepository.GetById(request.Id) is not Post post)
        {
            throw new ApplicationException("Post with given id not found");
        }

        return Task.FromResult(
            new GetByIdResponse(
                Post: new PostDto
                {
                    Id = post.Id.ToString(),
                    Author = new UserWithoutPasswordDto
                    {
                        Id = post.Author.Id.ToString(),
                        ImageUri = post.ImageUri,
                        Name = post.Author.Name,
                        Email = post.Author.Email,
                    },
                    ImageUri = post.ImageUri,
                    Title = post.Title,
                    Description = post.Description,
                    DateCreated = post.DateCreated.ToString("dd/MM/yyyy HH:mm"),
                    Topics = post.Topics.Select(t => new TopicDto
                    {
                        Id = t.Id,
                        Name = t.Name
                    })
                }
            )
        );
    }
}

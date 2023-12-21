using System.Security.Claims;
using Bloggy.Application.Common.Dots;
using Bloggy.Application.Persistense;
using Bloggy.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Bloggy.Application.Commands.Posts.Create;

public class CreateHandler(
    IHttpContextAccessor _httpContextAccessor,
    IPostRepository _postRepository,
    ITopicRepository _topicRepository
) : IRequestHandler<CreateRequest, CreateResponse>
{
    public Task<CreateResponse> Handle(CreateRequest request, CancellationToken cancellationToken)
    {
        var userId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

        var post = new Post
        {
            AuthorId = userId,
            Title = request.Title,
            Description = request.Description,
            DateCreated = DateTime.UtcNow,
        };
        post.Topics = _topicRepository.GetAll().Where(t => request.Topics.Contains(t.Id)).ToList();
        _postRepository.Add(post);

        post = _postRepository.GetById(post.Id);
        return Task.FromResult(
            new CreateResponse(
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

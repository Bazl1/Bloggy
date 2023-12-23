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
        IEnumerable<PostDto> posts;
        if (request.Search != string.Empty)
        {
            if (request.Search == "Popular")
            {
                posts = _postRepository.GetPopular(request.Page, request.Limit)
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
            }
            else
            {
                posts = _postRepository.Search(request.Page, request.Limit, request.Search)
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
            }
        }
        else if (request.Category != string.Empty)
        {
            posts = _postRepository.GetByTopic(request.Page, request.Limit, request.Category)
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
        }
        else
        {
            posts = _postRepository.GetAll(request.Page, request.Limit)
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
        }

        return Task.FromResult(new GetAllResponse(posts));
    }
}

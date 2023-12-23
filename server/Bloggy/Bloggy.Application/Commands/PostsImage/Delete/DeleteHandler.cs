using System.Security.Claims;
using Bloggy.Application.Common.Dots;
using Bloggy.Application.Persistense;
using Bloggy.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Bloggy.Application.Commands.PostsImage.Delete;

public class DeleteHandler(
    IPostRepository _postRepository,
    IHttpContextAccessor _httpContextAccessor,
    IHostingEnvironment _hostingEnvironment
) : IRequestHandler<DeleteRequest, DeleteResponse>
{
    public Task<DeleteResponse> Handle(DeleteRequest request, CancellationToken cancellationToken)
    {   
        if (!Guid.TryParse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid userId))
        {
            throw new ApplicationException("Unauthorized");
        }

        if (_postRepository.GetById(request.Id) is not Post post)
        {
            throw new ApplicationException("Post with given id not found");
        }

        if (post.AuthorId != userId)
        {
            throw new ApplicationException("Permission denied");
        }

        string path = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", "images", post.ImageUri.Split('/').Last());
        if (!File.Exists(path))
        {
            throw new ApplicationException("Image not found");
        }

        post.ImageUri = string.Empty;
        _postRepository.Update(post);

        return Task.FromResult(
            new DeleteResponse(
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
                    Views = post.Views,
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

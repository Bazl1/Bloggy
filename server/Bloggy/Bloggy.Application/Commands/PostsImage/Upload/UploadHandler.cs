using System.Security.Claims;
using System.Security.Cryptography;
using Bloggy.Application.Common.Dots;
using Bloggy.Application.Persistense;
using Bloggy.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Bloggy.Application.Commands.PostsImage.Upload;

public class UploadHandler(
    IHttpContextAccessor _httpContextAccessor,
    IHostingEnvironment _hostingEnvironment,
    IPostRepository _postRepository
) : IRequestHandler<UploadRequest, UploadResponse>
{
    public Task<UploadResponse> Handle(UploadRequest request, CancellationToken cancellationToken)
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

        FileInfo fileInfo = new FileInfo(request.Image.FileName);
        string path = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", "images", $"post_image_{post.Id}{fileInfo.Extension}");
        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            request.Image.CopyTo(fileStream);
        }

        post.ImageUri = $"http://localhost:5010/images/post_image_{post.Id}{fileInfo.Extension}";
        _postRepository.Update(post);

        return Task.FromResult(
            new UploadResponse(
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
                    DateCreated = post.DateCreated,
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

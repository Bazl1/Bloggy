using System.Security.Claims;
using Bloggy.Application.Common.Dots;
using Bloggy.Application.Persistense;
using Bloggy.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Bloggy.Application.Commands.AccountsImage.Delete;

public class DeleteHandler(
    IUserRepository _userRepository,
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

        if (_userRepository.GetById(userId) is not User user)
        {
            throw new ApplicationException("Unauthorized");
        }

        string path = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", "images", user.ImageUri.Split('/').Last());
        if (!File.Exists(path))
        {
            throw new ApplicationException("Image not found");
        }
        
        File.Delete(path);

        user.ImageUri = null;
        _userRepository.Update(user);

        return Task.FromResult(
            new DeleteResponse(
                User: new UserDto
                {
                    Id = user.Id.ToString(),
                    ImageUri = user.ImageUri,
                    Name = user.Name,
                    Email = user.Email
                }
            )
        );
    }
}

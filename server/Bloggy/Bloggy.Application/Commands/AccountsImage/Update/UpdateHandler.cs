using System.Security.Claims;
using Bloggy.Application.Persistense;
using Bloggy.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Bloggy.Application.Commands.AccountsImage.Update;

public class UpdateHandler(
    IUserRepository _userRepository,
    IHttpContextAccessor _httpContextAccessor,
    IHostingEnvironment _hostingEnvironment
) : IRequestHandler<UpdateRequest, UpdateResponse>
{
    public Task<UpdateResponse> Handle(UpdateRequest request, CancellationToken cancellationToken)
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

        FileInfo fileInfo = new FileInfo(request.Image.FileName);
        path = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", "images", $"user_image_{user.Id}{fileInfo.Extension}");
        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            request.Image.CopyTo(fileStream);
        }

        user.ImageUri = $"http://localhost:5010/images/user_image_{user.Id}{fileInfo.Extension}";
        _userRepository.Update(user);

        return Task.FromResult(new UpdateResponse());
    }
}

using System.Security.Claims;
using Bloggy.Application.Persistense;
using Bloggy.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Bloggy.Application.Commands.Accounts.My;

public class MyHandler(
    IUserRepository _userRepository,
    IHttpContextAccessor _httpContextAccessor
) : IRequestHandler<MyRequest, MyResponse>
{
    public Task<MyResponse> Handle(MyRequest request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid userId))
        {
            throw new ApplicationException("Unauthorized");
        }

        if (_userRepository.GetById(userId) is not User user)
        {
            throw new ApplicationException("Unauthorized");
        }

        return Task.FromResult(
            new MyResponse(
                Id: user.Id.ToString(),
                ImageUri: user.ImageUri,
                Name: user.Name,
                Email: user.Email
            )
        );
    }
}

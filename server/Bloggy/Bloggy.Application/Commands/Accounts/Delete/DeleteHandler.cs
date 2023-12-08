using System.Security.Claims;
using Bloggy.Application.Persistense;
using Bloggy.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Bloggy.Application.Commands.Accounts.Delete;

public class DeleteHandler(
    IUserRepository _userRepository,
    IHttpContextAccessor _httpContextAccessor
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

        _userRepository.Remove(user);

        return Task.FromResult(new DeleteResponse());
    }
}

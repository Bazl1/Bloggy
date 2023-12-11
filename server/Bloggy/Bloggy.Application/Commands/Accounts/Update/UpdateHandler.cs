using System.Security.Claims;
using Bloggy.Application.Common.Dots;
using Bloggy.Application.Persistense;
using Bloggy.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Bloggy.Application.Commands.Accounts.Update;

public class UpdateHandler(
    IUserRepository _userRepository,
    IHttpContextAccessor _httpContextAccessor
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
            throw new ApplicationException("User with given id not found");
        }

        user.Name = request.Username;
        _userRepository.Update(user);
        
        return Task.FromResult(
            new UpdateResponse(
                User: new UserDto
                {
                    Id = user.Id.ToString(),
                    ImageUri = user.ImageUri,
                    Name = user.Name,
                    Email = user.Email,
                    Password = user.Password
                }
            )
        );
    }
}

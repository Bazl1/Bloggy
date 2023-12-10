using System.Security.Claims;
using Bloggy.Application.Common.Dots;
using Bloggy.Application.Persistense;
using Bloggy.Application.Services.Authorization;
using Bloggy.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Bloggy.Application.Commands.Accounts.ChangePassword;

public class ChangePasswordHandler(
    IUserRepository _userRepository,
    IPasswordHasher _passwordHasher,
    IHttpContextAccessor _httpContextAccessor
) : IRequestHandler<ChangePasswordRequest, ChangePasswordResponse>
{
    public Task<ChangePasswordResponse> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid userId))
        {
            throw new ApplicationException("Unauthorized");
        }

        if (_userRepository.GetById(userId) is not User user)
        {
            throw new ApplicationException("Unauthorized");
        }

        if (!_passwordHasher.Verify(request.OldPassword, user.Password))
        {
            throw new ApplicationException("Password mismatch");
        }

        user.Password = _passwordHasher.Hash(request.NewPassword);
        _userRepository.Update(user);

        return Task.FromResult(
            new ChangePasswordResponse(
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

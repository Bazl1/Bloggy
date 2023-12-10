using Bloggy.Application.Common.Dots;
using Bloggy.Application.Persistense;
using Bloggy.Domain.Entites;
using MediatR;

namespace Bloggy.Application.Commands.Accounts.Update;

public class UpdateHandler(
    IUserRepository _userRepository
) : IRequestHandler<UpdateRequest, UpdateResponse>
{
    public Task<UpdateResponse> Handle(UpdateRequest request, CancellationToken cancellationToken)
    {
        if (_userRepository.GetById(request.Id) is not User user)
        {
            throw new ApplicationException("User with given id not found");
        }

        user.Name = request.Name;
        _userRepository.Update(user);
        
        return Task.FromResult(
            new UpdateResponse(
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

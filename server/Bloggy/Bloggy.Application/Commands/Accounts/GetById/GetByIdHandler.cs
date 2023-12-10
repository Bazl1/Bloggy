using Bloggy.Application.Common.Dots;
using Bloggy.Application.Persistense;
using Bloggy.Domain.Entites;
using MediatR;

namespace Bloggy.Application.Commands.Accounts.GetById;

public class GetByIdHandler(
    IUserRepository _userRepository
) : IRequestHandler<GetByIdRequest, GetByIdResponse>
{
    public Task<GetByIdResponse> Handle(GetByIdRequest request, CancellationToken cancellationToken)
    {
        if (_userRepository.GetById(request.Id) is not User user)
        {
            throw new ApplicationException("User with given id not found");
        }

        return Task.FromResult(
            new GetByIdResponse(
                User: new UserWithoutPasswordDto
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

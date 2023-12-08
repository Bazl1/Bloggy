using Bloggy.Application.Common;
using Bloggy.Application.Persistense;
using Bloggy.Application.Services.Authorization;
using Bloggy.Domain.Entites;
using MediatR;

namespace Bloggy.Application.Commands.Authorization.Refresh;

public class RefreshHandler(
    IRefreshTokenRepository _refreshTokenRepository,
    IUserRepository _userRepository,
    IJwtTokenGenerator _jwtTokenGenerator
) : IRequestHandler<RefreshRequest, RefreshResponse>
{
    public Task<RefreshResponse> Handle(RefreshRequest request, CancellationToken cancellationToken)
    {
        if (_refreshTokenRepository.GetByValue(request.RefreshToken) is not RefreshToken refreshToken)
        {
            throw new ApplicatioException("Refresh token not found");
        }

        if (_userRepository.GetById(refreshToken.UserId) is not User user)
        {
            throw new ApplicatioException("User not found");
        }

        var accessToken = _jwtTokenGenerator.GenerateToken(user);

        return Task.FromResult(
            new RefreshResponse(
                AccessToken: accessToken
            )
        );
    }
}

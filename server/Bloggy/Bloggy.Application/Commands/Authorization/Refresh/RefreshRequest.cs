using MediatR;

namespace Bloggy.Application.Commands.Authorization.Refresh;

public record RefreshRequest(
    string RefreshToken
) : IRequest<RefreshResponse>;
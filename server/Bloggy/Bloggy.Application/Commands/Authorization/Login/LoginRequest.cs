using MediatR;

namespace Bloggy.Application.Commands.Authorization.Login;

public record LoginRequest(
    string Email,
    string Password
) : IRequest<LoginResponse>;
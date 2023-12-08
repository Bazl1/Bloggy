using MediatR;

namespace Bloggy.Application.Commands.Authorization.Register;

public record RegisterRequest(
    string Username,
    string Email,
    string Password
) : IRequest<RegisterResponse>;
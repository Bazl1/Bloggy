using MediatR;

namespace Bloggy.Application.Commands.Authorization.Logout;

public record LogoutRequest() : IRequest<LogoutResponse>;
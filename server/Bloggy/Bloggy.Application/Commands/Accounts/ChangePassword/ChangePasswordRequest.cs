using MediatR;

namespace Bloggy.Application.Commands.Accounts.ChangePassword;
public record ChangePasswordRequest(
    string Password
) : IRequest<ChangePasswordResponse>;
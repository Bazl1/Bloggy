using MediatR;

namespace Bloggy.Application.Commands.Accounts.ChangePassword;
public record ChangePasswordRequest(
    string OldPassword,
    string NewPassword
) : IRequest<ChangePasswordResponse>;
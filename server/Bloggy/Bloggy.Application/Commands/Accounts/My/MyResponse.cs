namespace Bloggy.Application.Commands.Accounts.My;

public record MyResponse(
    string Id,
    string? ImageUri,
    string Name,
    string Email
);
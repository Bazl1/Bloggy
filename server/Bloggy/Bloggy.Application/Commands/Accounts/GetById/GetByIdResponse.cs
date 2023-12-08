namespace Bloggy.Application.Commands.Accounts.GetById;

public record GetByIdResponse(
    string Id,
    string? ImageUri,
    string Name,
    string Email
);
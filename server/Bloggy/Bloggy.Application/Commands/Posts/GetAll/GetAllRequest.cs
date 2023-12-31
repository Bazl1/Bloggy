using MediatR;

namespace Bloggy.Application.Commands.Posts.GetAll;

public record GetAllRequest(
    int Page,
    int Limit,
    string Category,
    string Search
) : IRequest<GetAllResponse>;
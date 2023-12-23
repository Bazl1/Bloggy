using MediatR;

namespace Bloggy.Application.Commands.Posts.GetPopular;

public record GetPopularRequest(
    int Page,
    int Limit
) : IRequest<GetPopularResponse>;
using Bloggy.Domain.Entites;

namespace Bloggy.Application.Persistense;

public interface IRefreshTokenRepository
{
    void Add(RefreshToken refreshToken);
    RefreshToken? GetByUserId(Guid refreshTokenUserId);
    RefreshToken? GetByValue(string refreshTokenValue);
    void Remove(RefreshToken refreshToken);
    void Update(RefreshToken refreshToken);
}
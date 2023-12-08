using Bloggy.Application.Persistense;
using Bloggy.Domain.Entites;

namespace Bloggy.Infrastructure.Persistense;

public class RefreshTokenRepository(
    AppDbContext _appDbContext
) : IRefreshTokenRepository
{
    public void Add(RefreshToken refreshToken)
    {
        _appDbContext.RefreshTokens.Add(refreshToken);
        _appDbContext.SaveChanges();
    }

    public RefreshToken? GetByUserId(Guid refreshTokenUserId)
    {
        return _appDbContext.RefreshTokens
            .FirstOrDefault(refreshToken => refreshToken.UserId == refreshTokenUserId);
    }

    public RefreshToken? GetByValue(string refreshTokenValue)
    {
        return _appDbContext.RefreshTokens
            .FirstOrDefault(refreshToken => refreshToken.Value == refreshTokenValue);
    }

    public void Remove(RefreshToken refreshToken)
    {
        _appDbContext.RefreshTokens.Remove(refreshToken);
        _appDbContext.SaveChanges();
    }

    public void Update(RefreshToken refreshToken)
    {
        _appDbContext.SaveChanges();
    }
}

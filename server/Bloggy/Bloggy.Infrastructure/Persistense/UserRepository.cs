using Bloggy.Application.Persistense;
using Bloggy.Domain.Entites;

namespace Bloggy.Infrastructure.Persistense;

public class UserRepository(
    AppDbContext _appDbContext
) : IUserRepository
{
    public void Add(User user)
    {
        _appDbContext.Users.Add(user);
        _appDbContext.SaveChanges();
    }

    public User? GetByEmail(string userEmail)
    {
        return _appDbContext.Users
            .FirstOrDefault(user => user.Email == userEmail);
    }

    public User? GetById(Guid userId)
    {
        return _appDbContext.Users
            .FirstOrDefault(user => user.Id == userId);
    }

    public User? GetByName(string userName)
    {
        return _appDbContext.Users
            .FirstOrDefault(user => user.Name == userName);
    }

    public void Remove(User user)
    {
        _appDbContext.Users.Remove(user);
        _appDbContext.SaveChanges();
    }

    public void Update(User user)
    {
        _appDbContext.SaveChanges();
    }
}

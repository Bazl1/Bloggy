using Bloggy.Domain.Entites;

namespace Bloggy.Application.Persistense;

public interface IUserRepository
{
    void Add(User user);
    void Remove(User user);
    void Update(User user);
    User? GetById(Guid userId);
    User? GetByName(string userName);
    User? GetByEmail(string userEmail);
}
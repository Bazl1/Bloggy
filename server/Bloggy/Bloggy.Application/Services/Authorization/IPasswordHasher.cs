namespace Bloggy.Application.Services.Authorization;

public interface IPasswordHasher
{
    string Hash(string password);
    bool Verify(string password, string passwordHash);
}
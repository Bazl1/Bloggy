using Bloggy.Application.Persistense;
using Bloggy.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Bloggy.Infrastructure.Persistense;

public class PostRepository(
    AppDbContext _appDbContext
) : IPostRepository
{
    public void Add(Post post)
    {
        _appDbContext.Posts.Add(post);
        _appDbContext.SaveChanges();
    }

    public IEnumerable<Post> GetAll()
    {
        return _appDbContext.Posts
            .Include(p => p.Author)
            .Include(p => p.Topics)
            .ToList();
    }

    public Post? GetById(Guid postId)
    {
        return _appDbContext.Posts
            .Include(p => p.Author)
            .Include(p => p.Topics)
            .FirstOrDefault(p => p.Id == postId);
    }

    public void Remove(Post post)
    {
        _appDbContext.Posts.Remove(post);
        _appDbContext.SaveChanges();
    }

    public void Update(Post post)
    {
        _appDbContext.SaveChanges();
    }
}

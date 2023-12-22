using Bloggy.Domain.Entites;

namespace Bloggy.Application.Persistense;

public interface IPostRepository
{
    void Add(Post post);
    void Remove(Post post);
    void Update(Post post);
    Post? GetById(Guid postId);
    IEnumerable<Post> GetAll();
    IEnumerable<Post> Search(string searchString);
    IEnumerable<Post> GetByTopicId(int topicId);
    IEnumerable<Post> GetByTopic(string topic);
}
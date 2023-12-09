using Bloggy.Application.Persistense;
using Bloggy.Domain.Entites;

namespace Bloggy.Infrastructure.Persistense;

public class TopicRepository(
    AppDbContext _appDbContext
) : ITopicRepository
{
    public void Add(Topic topic)
    {
        _appDbContext.Topics.Add(topic);
        _appDbContext.SaveChanges();
    }

    public IEnumerable<Topic> GetAll()
    {
        return _appDbContext.Topics;
    }

    public Topic? GetById(int topicId)
    {
        return _appDbContext.Topics
            .FirstOrDefault(topic => topic.Id == topicId);
    }

    public void Remove(Topic topic)
    {
        _appDbContext.Topics.Remove(topic);
        _appDbContext.SaveChanges();
    }

    public void Update(Topic topic)
    {
        _appDbContext.SaveChanges();
    }
}
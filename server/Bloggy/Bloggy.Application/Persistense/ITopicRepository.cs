using Bloggy.Domain.Entites;

namespace Bloggy.Application.Persistense;

public interface ITopicRepository
{
    void Add(Topic topic);
    void Remove(Topic topic);
    void Update(Topic topic);
    Topic? GetById(int topicId);
    IEnumerable<Topic> GetAll();
}
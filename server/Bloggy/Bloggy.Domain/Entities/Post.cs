namespace Bloggy.Domain.Entites;

public class Post
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    public User Author { get; set; }
    public string Document { get; set; }
    public DateTime DateCreated { get; set; }
    public IEnumerable<Topic> Topics { get; set; } = new List<Topic>();
}
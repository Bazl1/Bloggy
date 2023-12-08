namespace Bloggy.Domain.Entites;

public class Post
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    public User Author { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DateCreated { get; set; }
    public IEnumerable<Topic> Topics {get;set;} = new List<Topic>();
}
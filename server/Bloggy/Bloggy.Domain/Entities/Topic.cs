namespace Bloggy.Domain.Entites;

public class Topic
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Post> Posts { get; } = new List<Post>();
}
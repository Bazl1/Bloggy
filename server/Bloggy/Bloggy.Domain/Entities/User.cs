namespace Bloggy.Domain.Entites;

public class User
{
    public Guid Id { get; set; }
    public RefreshToken RefreshToken { get; set; }
    public string ImageUri { get; set; } = string.Empty;
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public IEnumerable<Post> Posts { get; } = new List<Post>();
}
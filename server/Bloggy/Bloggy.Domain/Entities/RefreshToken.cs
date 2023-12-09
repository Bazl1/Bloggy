namespace Bloggy.Domain.Entites;

public class RefreshToken
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public string Value { get; set; }
    public DateTime Created { get; set; }
    public DateTime Expiry { get; set; }
}
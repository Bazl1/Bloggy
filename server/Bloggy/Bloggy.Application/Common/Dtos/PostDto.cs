namespace Bloggy.Application.Common.Dots;

public class PostDto
{
    public string Id { get; set; }
    public UserWithoutPasswordDto Author { get; set; }
    public string ImageUri { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DateCreated { get; set; }
    public IEnumerable<TopicDto> Topics { get; set; }
}
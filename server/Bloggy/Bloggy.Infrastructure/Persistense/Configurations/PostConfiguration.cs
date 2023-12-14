using Bloggy.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bloggy.Infrastructure.Persistense.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasMany(e => e.Topics)
            .WithMany(e => e.Posts);
            // .UsingEntity<PostTopics>(
            //     l => l.HasOne<Topic>().WithMany().HasForeignKey(e => e.TopicId),
            //     r => r.HasOne<Post>().WithMany().HasForeignKey(e => e.PostId)
            // );
    }
}

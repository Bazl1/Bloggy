using Bloggy.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bloggy.Infrastructure.Persistense.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(user => user.Posts)
            .WithOne(post => post.Author)
            .HasForeignKey(post => post.AuthorId);

        builder.HasOne(user => user.RefreshToken)
            .WithOne(refreshToken => refreshToken.User)
            .HasForeignKey<RefreshToken>(refreshToken => refreshToken.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
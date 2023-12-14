using Bloggy.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bloggy.Infrastructure.Persistense.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(e => e.Posts)
            .WithOne(e => e.Author)
            .HasForeignKey(e => e.AuthorId);

        builder.HasOne(e => e.RefreshToken)
            .WithOne(e => e.User)
            .HasForeignKey<RefreshToken>(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
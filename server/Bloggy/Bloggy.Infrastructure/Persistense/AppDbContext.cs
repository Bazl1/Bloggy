using Bloggy.Domain.Entites;
using Bloggy.Infrastructure.Persistense.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Bloggy.Infrastructure.Persistense;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Topic> Topics { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfigurations());
        modelBuilder.ApplyConfiguration(new PostConfiguration());

        modelBuilder.Entity<Topic>()
            .HasData(
                new Topic { Id = 1, Name = "Gaming" },
                new Topic { Id = 1, Name = "Sports" },
                new Topic { Id = 1, Name = "Business" },
                new Topic { Id = 1, Name = "Crypto" },
                new Topic { Id = 1, Name = "Television" },
                new Topic { Id = 1, Name = "Celebrity" },
                new Topic { Id = 1, Name = "Animals and Pets" },
                new Topic { Id = 1, Name = "Anime" },
                new Topic { Id = 1, Name = "Art" },
                new Topic { Id = 1, Name = "Cars and Motor Vehicles" },
                new Topic { Id = 1, Name = "Crafts and DIY" },
                new Topic { Id = 1, Name = "Culture, Race, and Ethnicity" },
                new Topic { Id = 1, Name = "Ethics and Philosophy" },
                new Topic { Id = 1, Name = "Fashion" },
                new Topic { Id = 1, Name = "Food and Drink" },
                new Topic { Id = 1, Name = "History" },
                new Topic { Id = 1, Name = "Hobbies" },
                new Topic { Id = 1, Name = "Law" },
                new Topic { Id = 1, Name = "Learning and Education" },
                new Topic { Id = 1, Name = "Military" },
                new Topic { Id = 1, Name = "Movies" },
                new Topic { Id = 1, Name = "Music" },
                new Topic { Id = 1, Name = "Place" },
                new Topic { Id = 1, Name = "Podcasts and Streamers" },
                new Topic { Id = 1, Name = "Politics" },
                new Topic { Id = 1, Name = "Programming" },
                new Topic { Id = 1, Name = "Reading, Writing and Literature" },
                new Topic { Id = 1, Name = "Relogion and Spirituality" },
                new Topic { Id = 1, Name = "Science" },
                new Topic { Id = 1, Name = "Tabletop Games" },
                new Topic { Id = 1, Name = "Technology" },
                new Topic { Id = 1, Name = "Teacnology" },
                new Topic { Id = 1, Name = "Travel" }
            );
    }
}
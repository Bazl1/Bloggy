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

        // modelBuilder.Entity<Topic>()
        //     .HasData(
        //         new Topic { Id = 1, Name = "Gaming" },
        //         new Topic { Id = 2, Name = "Sports" },
        //         new Topic { Id = 3, Name = "Business" },
        //         new Topic { Id = 4, Name = "Crypto" },
        //         new Topic { Id = 5, Name = "Television" },
        //         new Topic { Id = 6, Name = "Celebrity" },
        //         new Topic { Id = 7, Name = "Animals and Pets" },
        //         new Topic { Id = 8, Name = "Anime" },
        //         new Topic { Id = 9, Name = "Art" },
        //         new Topic { Id = 10, Name = "Cars and Motor Vehicles" },
        //         new Topic { Id = 11, Name = "Crafts and DIY" },
        //         new Topic { Id = 12, Name = "Culture, Race, and Ethnicity" },
        //         new Topic { Id = 13, Name = "Ethics and Philosophy" },
        //         new Topic { Id = 14, Name = "Fashion" },
        //         new Topic { Id = 15, Name = "Food and Drink" },
        //         new Topic { Id = 16, Name = "History" },
        //         new Topic { Id = 17, Name = "Hobbies" },
        //         new Topic { Id = 18, Name = "Law" },
        //         new Topic { Id = 19, Name = "Learning and Education" },
        //         new Topic { Id = 20, Name = "Military" },
        //         new Topic { Id = 21, Name = "Movies" },
        //         new Topic { Id = 22, Name = "Music" },
        //         new Topic { Id = 23, Name = "Place" },
        //         new Topic { Id = 24, Name = "Podcasts and Streamers" },
        //         new Topic { Id = 25, Name = "Politics" },
        //         new Topic { Id = 26, Name = "Programming" },
        //         new Topic { Id = 27, Name = "Reading, Writing and Literature" },
        //         new Topic { Id = 28, Name = "Relogion and Spirituality" },
        //         new Topic { Id = 29, Name = "Science" },
        //         new Topic { Id = 30, Name = "Tabletop Games" },
        //         new Topic { Id = 31, Name = "Technology" },
        //         new Topic { Id = 32, Name = "Teacnology" },
        //         new Topic { Id = 33, Name = "Travel" }
        //     );
    }
}
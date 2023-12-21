using Bloggy.Domain.Entites;
using Bloggy.Infrastructure;
using Bloggy.Infrastructure.Persistense;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc(
            "v1",
            new OpenApiInfo
            {
                Title = "Bloggy",
                Version = "v1"
            }
        );

        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey
        });

        var securityRequirement = new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        };

        options.AddSecurityRequirement(securityRequirement);
    });

    builder.Services.AddControllers();

    builder.Services.AddHttpContextAccessor();
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}
var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        var appDbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
        appDbContext.Topics.AddRange(
            new Topic { Id = 1, Name = "Gaming" },
            new Topic { Id = 2, Name = "Sports" },
            new Topic { Id = 3, Name = "Business" },
            new Topic { Id = 4, Name = "Crypto" },
            new Topic { Id = 5, Name = "Television" },
            new Topic { Id = 6, Name = "Celebrity" },
            new Topic { Id = 7, Name = "Animals and Pets" },
            new Topic { Id = 8, Name = "Anime" },
            new Topic { Id = 9, Name = "Art" },
            new Topic { Id = 10, Name = "Cars and Motor Vehicles" },
            new Topic { Id = 11, Name = "Crafts and DIY" },
            new Topic { Id = 12, Name = "Culture, Race, and Ethnicity" },
            new Topic { Id = 13, Name = "Ethics and Philosophy" },
            new Topic { Id = 14, Name = "Fashion" },
            new Topic { Id = 15, Name = "Food and Drink" },
            new Topic { Id = 16, Name = "History" },
            new Topic { Id = 17, Name = "Hobbies" },
            new Topic { Id = 18, Name = "Law" },
            new Topic { Id = 19, Name = "Learning and Education" },
            new Topic { Id = 20, Name = "Military" },
            new Topic { Id = 21, Name = "Movies" },
            new Topic { Id = 22, Name = "Music" },
            new Topic { Id = 23, Name = "Place" },
            new Topic { Id = 24, Name = "Podcasts and Streamers" },
            new Topic { Id = 25, Name = "Politics" },
            new Topic { Id = 26, Name = "Programming" },
            new Topic { Id = 27, Name = "Reading, Writing and Literature" },
            new Topic { Id = 28, Name = "Relogion and Spirituality" },
            new Topic { Id = 29, Name = "Science" },
            new Topic { Id = 30, Name = "Tabletop Games" },
            new Topic { Id = 31, Name = "Technology" },
            new Topic { Id = 32, Name = "Teacnology" },
            new Topic { Id = 33, Name = "Travel" }
        );
        appDbContext.SaveChanges();
        var user = new User
        {
            Name = "Test",
            Email = "test@mail.com",
            Password = "test"
        };
        appDbContext.Users.Add(user);
        appDbContext.SaveChanges();
        appDbContext.Posts.Add(
            new Post
            {
                AuthorId = user.Id,
                Title = "Lorem Ipsum",
                ImageUri = "http://localhost:5010/images/lorem-ipsum.jpg",
                Description = """
Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam metus nibh, volutpat id tellus non, imperdiet vehicula sapien. Vivamus venenatis cursus mi, vitae tincidunt sapien tempus vitae. Donec pellentesque efficitur ex quis posuere. Donec bibendum massa eu sapien scelerisque tristique. Curabitur in semper libero, at ultrices tortor. Vestibulum consequat ligula felis, sit amet sodales nibh lobortis sed. Duis porta, nisi non aliquam facilisis, arcu ante sollicitudin ligula, ut hendrerit lorem lorem id ex. Donec at accumsan ipsum. Proin nisl quam, tincidunt ornare cursus ac, imperdiet id lectus. Aenean blandit odio at cursus semper. Ut tristique mollis tempor. Nam iaculis augue sed elementum feugiat. Donec tristique ut nulla laoreet tristique.

Duis varius neque vitae velit dapibus, eu eleifend quam pulvinar. Nam dictum mi eu justo pellentesque sagittis. Aenean convallis nunc non ipsum facilisis, ut convallis enim vulputate. Nullam sed risus a risus porttitor ultricies. In hac habitasse platea dictumst. Etiam vel condimentum lectus. Vestibulum ut leo id massa egestas finibus. Suspendisse dui erat, cursus sed suscipit et, pulvinar sed purus. In et elementum felis. Vivamus cursus tincidunt fermentum. Integer tellus lacus, cursus vitae vulputate eu, volutpat ut nisi. Integer luctus, arcu a finibus pulvinar, augue ante pellentesque diam, et vulputate nisl ligula at eros. Aenean condimentum nunc sem, porttitor elementum metus blandit sit amet. Pellentesque quam ante, efficitur quis mi ut, sollicitudin dignissim orci.

Morbi mattis tristique purus, non commodo orci iaculis sed. Nullam tempus odio vitae massa volutpat, et accumsan purus lacinia. Morbi faucibus at arcu vehicula accumsan. Mauris at arcu ac metus bibendum maximus. In sollicitudin nec lectus et consequat. Vivamus nec congue sem. Nullam vulputate, mauris et sollicitudin hendrerit, tellus nunc gravida purus, in pulvinar felis felis et mauris. Maecenas ornare nisl turpis. Aliquam id sem odio. In nec eros et lectus vestibulum posuere sed vel leo.

Aliquam dapibus, risus at venenatis tincidunt, metus risus interdum sapien, at sodales odio sapien quis lectus. Etiam est risus, egestas vel dui id, imperdiet varius dui. Nulla a facilisis tortor, nec tempor erat. Suspendisse porttitor est quis ipsum dictum finibus. Sed blandit suscipit magna eu rhoncus. Etiam ante risus, dapibus non mi et, feugiat bibendum sapien. Etiam consequat risus at nisl congue feugiat. Aliquam sit amet porttitor augue. Nulla odio velit, aliquet et tincidunt eu, porttitor sit amet mi. Duis sodales porttitor mauris, quis pharetra nulla ultrices dignissim. Vivamus eleifend urna vel cursus laoreet. Donec tortor enim, sodales id imperdiet iaculis, egestas id sem. Praesent a interdum nunc.

Donec aliquam neque sed urna malesuada pellentesque commodo in diam. Aenean ligula sem, euismod non scelerisque quis, suscipit laoreet massa. Nullam tellus velit, accumsan eu ex suscipit, consectetur eleifend est. Nam elementum dapibus condimentum. Pellentesque aliquet mi vitae mauris cursus rutrum. Aliquam pellentesque maximus congue. Vestibulum enim ipsum, mollis malesuada semper id, placerat eu nulla. Vestibulum finibus dui purus, at varius libero mollis ac. Aliquam tempus ante ac tellus imperdiet luctus. Maecenas et suscipit erat. Morbi venenatis consequat arcu a commodo.
""",
                Topics = appDbContext.Topics.Where(t => t.Id == 1).ToList()
            }
        );
        appDbContext.SaveChanges();
    }
    app.UseCors(options =>
        options.WithOrigins("http://localhost:5173")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
    );
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
}
app.Run();
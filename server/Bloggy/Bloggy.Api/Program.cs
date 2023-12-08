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
    }
    app.UseCors(options =>
        options.WithOrigins("http://localhost:5173")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
    );
    app.UseHttpsRedirection();
    app.UseExceptionHandler("/error");
    app.UseStaticFiles();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
}
app.Run();
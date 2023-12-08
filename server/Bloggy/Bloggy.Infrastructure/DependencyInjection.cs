using System.Text;
using Bloggy.Application.Persistense;
using Bloggy.Application.Services.Authorization;
using Bloggy.Infrastructure.Persistense;
using Bloggy.Infrastructure.Services.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Bloggy.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddTransient<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddTransient<IPasswordHasher, PasswordHasher>();

        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();

        services.AddAuthentication(configuration);
        services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("Bloggy.Db"));

        return services;
    }

    private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        
        configuration.Bind(JwtSettings.SectionName, jwtSettings);
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(jwtBearerOptions => jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret)
                )
            });
        
        return services;
    }
}
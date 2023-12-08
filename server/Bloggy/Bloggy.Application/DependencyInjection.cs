using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Bloggy.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options => options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}
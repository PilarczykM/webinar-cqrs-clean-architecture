using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class ApplicationInstalation
{
    public static IServiceCollection AddWebinarApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(assemblies: Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}

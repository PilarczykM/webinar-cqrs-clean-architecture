using Application.Contracts.Persistence;
using InfrastructureWithEFRegistration.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfrastructureWithEFRegistration
{
    public static class InfrastructureWithEFRegistration
    {
        public static IServiceCollection AddInfrastructureWithEFRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EFContext>(options =>
                options.UseSqlServer(configuration.
                GetConnectionString("WebinarConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IWebinarRepository, WebinaryRepository>();
            services.AddScoped<IPostRepository, PostRepository>();

            return services;
        }
    }
}
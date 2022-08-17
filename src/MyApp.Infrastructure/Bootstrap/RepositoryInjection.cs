using Microsoft.Extensions.DependencyInjection;
using MyApp.Domain;
using MyApp.Domain.Games;
using MyApp.Domain.Publishers;
using MyApp.Infrastructure.Repositories;

namespace MyApp.Infrastructure.Bootstrap
{
    public static class RepositoryInjection
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IGamesRepository, GamesRepository>();
            services.AddScoped<IPublishersRepository, PublishersRepository>();
        }
    }
}
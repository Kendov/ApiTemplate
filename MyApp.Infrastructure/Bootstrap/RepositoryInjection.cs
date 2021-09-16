using Microsoft.Extensions.DependencyInjection;
using MyApp.Domain;
using MyApp.Domain.Characters;
using MyApp.Infrastructure;
using MyApp.Infrastructure.Repositories;

namespace MyApp.Infrastructure.Bootstrap
{
    public static class RepositoryInjection
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
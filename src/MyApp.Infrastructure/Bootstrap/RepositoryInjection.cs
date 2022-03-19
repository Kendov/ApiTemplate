using Microsoft.Extensions.DependencyInjection;
using MyApp.Domain;
using MyApp.Domain.Characters;
using MyApp.Domain.Dapper;
using MyApp.Domain.Items;
using MyApp.Infrastructure.Dapper;
using MyApp.Infrastructure.Repositories;

namespace MyApp.Infrastructure.Bootstrap
{
    public static class RepositoryInjection
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICharactersRepository, CharactersRepository>();
            services.AddScoped<IItemsRepository, ItemsRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // services.AddScoped<IDapperContext, DapperContext>();
            services.AddScoped<IDapperContext, DapperContext>();
        }
    }
}
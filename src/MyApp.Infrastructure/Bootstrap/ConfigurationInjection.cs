using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application;
using MyApp.Domain;
using MyApp.Infrastructure;
using MyApp.Infrastructure.Data;
using MyApp.Infrastructure.GraphQL;

namespace MyApp.Infrastructure.Bootstrap
{
    public static class ConfigurationInjection
    {
        public static void AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers()
            .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ApplicationEntryPoint>());
            services.AddSwaggerGen();

            services.AddDbContextPool<AppDbContext>(options =>
                options.UseNpgsql(
                        configuration.GetConnectionString("database")
                    ).UseSnakeCaseNamingConvention());

            // services.AddDbContext<AppDbContext>(options =>
            //     options
            //         .UseNpgsql(configuration.GetConnectionString("database"))
            //         .UseSnakeCaseNamingConvention());


            services.AddMediatR(typeof(ApplicationEntryPoint).Assembly);


            services
                .AddGraphQLServer()
                .AddProjections()
                //.AddFiltering()
                //.AddSorting()
                .AddQueryType<Query>();
            //.AddMutationType<Mutation>();
        }
    }
}
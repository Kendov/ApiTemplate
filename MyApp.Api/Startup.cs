using GraphQL.Server.Ui.Voyager;
using HotChocolate;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyApp.Domain;
using MyApp.Infrastructure;
using MyApp.Infrastructure.Data;
using MyApp.Infrastructure.GraphQL;

namespace MyApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
            .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen();

            services.AddPooledDbContextFactory<ApiContext>(options =>
                options
                    .UseNpgsql(Configuration.GetConnectionString("database")));
            

            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services
                .AddGraphQLServer()
                .AddProjections()
                .AddFiltering()
                .AddSorting()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGraphQL();
            });

            app.UseGraphQLVoyager(new VoyagerOptions(){
                GraphQLEndPoint = "/graphql"
            });

        }
    }
}

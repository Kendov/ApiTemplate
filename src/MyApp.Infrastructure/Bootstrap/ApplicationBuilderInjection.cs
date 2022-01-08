using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using MyApp.Infrastructure.Hub;

namespace MyApp.Infrastructure.Bootstrap
{
    public static class ApplicationBuilderInjection
    {
        public static void AddApplications(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseGraphQLVoyager(new VoyagerOptions()
            {
                GraphQLEndPoint = "/graphql"
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chatHub");
            });

        }
    }
}
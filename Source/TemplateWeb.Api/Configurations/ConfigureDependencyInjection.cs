using TemplateWeb.Domain.Repositories.Interfaces;
using TemplateWeb.Infrastructure.MongoDB;
using TemplateWeb.Infrastructure.MongoDB.Repositories;

namespace TemplateWeb.Api.Configurations
{
    public static class ConfigureDependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.Configure<MongoDBSettings>(configurationManager.GetSection("DbSettings:Mongo"));
            services.AddSingleton<MongoDBContext>();

            services.AddScoped<IPeopleMongoRepository, PeopleRepositoryMongoDB>();
        }
    }
}

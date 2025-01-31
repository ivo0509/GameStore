using GameStore.BL.Interfaces;
using GameStore.BL.Services;
using GameStore.DL.Interfaces;
using GameStore.DL.Repositories.MongoDb;
using GameStore.Models.Configurations;

namespace GameStore.ServiceExtensions
{
    public static class ServiceConfigurationsExtensions
    {
        public static IServiceCollection AddConfigurations(
           this IServiceCollection services,
           IConfiguration configuration)
        {
            return services.Configure<MongoDbConfiguration>(
                configuration.GetSection(nameof(MongoDbConfiguration)));
        }

        public static IServiceCollection RegisterDataLayer(this IServiceCollection services)
        {
          
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            return services;
        }


        public static IServiceCollection RegisterBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IPublisherService, PublisherService>();
            return services;
        }
    }
}

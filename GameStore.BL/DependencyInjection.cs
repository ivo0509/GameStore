using Microsoft.Extensions.DependencyInjection;
using GameStore.BL.Interfaces;
using GameStore.BL.Services;
using GameStore.DL;

namespace GameStore.BL
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterBusinessLayer(this IServiceCollection services)
        {
            services.AddSingleton<IGameService, GameService>();
            services.AddSingleton<IPublisherService, PublisherService>();

            return services;
        }


        public static IServiceCollection RegisterDataLayer(this IServiceCollection services)
        {
            services.RegisterRepositories();

            return services;
        }

    }
}

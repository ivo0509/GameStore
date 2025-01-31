using Microsoft.Extensions.DependencyInjection;
using GameStore.DL.Interfaces;
using GameStore.DL.Repositories;
using GameStore.DL.Repositories.MongoDb;

namespace GameStore.DL
{
    public static class DependencyInjection
    {
        public static IServiceCollection 
            RegisterRepositories(this IServiceCollection services)
        {
            return
                 services
                .AddSingleton<IGameRepository, GameRepository>()
                .AddSingleton<IPublisherRepository, PublisherRepository>();
        }
    }
}

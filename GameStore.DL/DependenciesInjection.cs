using Microsoft.Extensions.DependencyInjection;
using GameStore.DL.Interfaces;
using GameStore.DL.Repositories;
using GameStore.DL.Repositories.MongoDb;

namespace GameStore.DL
{
    public static class DependenciesInjection
    {
        public static IServiceCollection 
            RegisterRepositories(this IServiceCollection services)
        {
            return
                services
                    .AddSingleton<IGameRepository,
                        GamesMongoRepository>()
                    .AddSingleton<IPlayerRepository,
                        PlayerRepository>();
        }
    }
}

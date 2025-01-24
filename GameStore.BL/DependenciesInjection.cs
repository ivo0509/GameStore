using Microsoft.Extensions.DependencyInjection;
using GameStore.BL.Interfaces;
using GameStore.BL.Services;

namespace GameStore.BL
{
    public static class DependenciesInjection
    {
        public static IServiceCollection
            RegisterServices(this IServiceCollection services)
        {
            return services
                        .AddSingleton<IGamesService, GamesService>()
                        .AddSingleton<IBusinessService, BusinessService>();
        }
    }
}

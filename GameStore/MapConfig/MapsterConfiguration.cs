using Mapster;
using GameStore.Models.DTO;
using GameStore.Models.Requests;

namespace GameStore.MapConfig
{
    public class MapsterConfiguration
    {
        public static void Configure()
        {
            TypeAdapterConfig<Game, GetAllGamesByPublisherRequest>
                .NewConfig()
                .TwoWays();
        }
    }
}

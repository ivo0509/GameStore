using GameStore.Models.DTO;

namespace GameStore.BL.Interfaces
{
    public interface IGamesService
    {
        List<Game> GetAll();

        Game? GetById(string id);

        void Add(Game game);

        void AddPlayerToGame(string gameId, string player);
    }
}

using GameStore.Models.DTO;

namespace GameStore.DL.Interfaces
{
    public interface IGameRepository
    {
        List<Game> GetAll();

        Game? GetById(string id);

        void Add(Game game);

        void Update(Game game);
    }
}

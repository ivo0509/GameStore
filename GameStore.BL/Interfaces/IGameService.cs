using GameStore.Models.DTO;
using GameStore.Models.Requests;


namespace GameStore.BL.Interfaces
{
    public interface IGameService
    {
       List<Game> GetAllGames();

        Game? GetById(string id);

        Game Add(Game game);

        Game Delete(string id);

        Game Update(string id ,Game game);
    }
}

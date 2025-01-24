using GameStore.Models.DTO;

namespace GameStore.DL.Interfaces
{
    public interface IPlayerRepository
    {
        List<Player> GetAll();

        Player? GetById(string id);
    }
}

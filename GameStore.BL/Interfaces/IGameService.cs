using GameStore.Models.DTO;
using GameStore.Models.Requests;
using GameStore.Models.Views;

namespace GameStore.BL.Interfaces
{
    public interface IGameService
    {
       List<Game> GetAllGamesBySeller(int sellerId);
    }
}
